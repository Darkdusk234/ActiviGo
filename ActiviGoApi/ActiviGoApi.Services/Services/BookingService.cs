using ActiviGoApi.Core.Models;
using FluentValidation;
using ActiviGoApi.Services.Interfaces;
using AutoMapper;
using ActiviGoApi.Core.Interfaces;
using ActiviGoApi.Infrastructur.Repositories;
using ActiviGoApi.Services.DTOs.BookingDTOs;
using Microsoft.AspNetCore.Identity;

namespace ActiviGoApi.Services
{
    public class BookingService : IBookingService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        private readonly UserManager<User> _userManager;



        public BookingService(
            IUnitOfWork unitOfWork,

            IMapper mapper, UserManager<User> userManager)

        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userManager = userManager;
        }

        /// <inheritdoc />
        public async Task<IEnumerable<BookingReadDTO>> GetAllAsync(CancellationToken ct)
        {
            var bookings = await _unitOfWork.Bookings.GetFilteredAsync(
                includeProperties: "ActivityOccurence.Activity",
                filter: null,
                ct: ct);
            return _mapper.Map<IEnumerable<BookingReadDTO>>(bookings);
        }

        /// <inheritdoc />
        public async Task<BookingReadDTO?> GetByIdAsync(int id, CancellationToken ct)
        {
            var bookings = await _unitOfWork.Bookings.GetFilteredAsync(
                includeProperties: "ActivityOccurence.Activity",
                filter: b => b.Id == id,
                ct: ct);

            var booking = bookings.FirstOrDefault();

            if (booking == null)
            {
                throw new KeyNotFoundException($"Booking with id {id} was not found.");
            }
            return _mapper.Map<BookingReadDTO>(booking);
        }

        /// <inheritdoc />
        public async Task<IEnumerable<BookingReadDTO>> GetBookingsByUserIdAsync(string userId, CancellationToken ct)
        {
            var userExists = await _userManager.FindByNameAsync(userId);

            if (userExists == null)
                throw new KeyNotFoundException($"User with id {userId} was not found.");

            var bookings = await _unitOfWork.Bookings.GetFilteredAsync(
                includeProperties: "ActivityOccurence.Activity",
                filter: b => b.UserId == userExists.Id,
                ct: ct);

            return _mapper.Map<IEnumerable<BookingReadDTO>>(bookings);
        }

        /// <inheritdoc />
        public async Task<BookingReadDTO> AddAsync(BookingCreateDTO createDto, string userName, CancellationToken ct)
        {
            var user = await _userManager.FindByNameAsync(userName);

            if (user == null)
            {
                throw new ArgumentException($"User connected to jwt token not in system anymore.");
            }

            if(user.IsSuspended)     
            {
                throw new ArgumentException("Cannot create booking for a suspended user.");
            }

            var occurrence = await _unitOfWork.ActivityOccurrences.GetByIdAsync(createDto.ActivityOccurenceId, ct); // is occurrence alive?

            if (occurrence == null)
            {
                throw new KeyNotFoundException($"ActivityOccurrence with id {createDto.ActivityOccurenceId} not found");
            }

            if (occurrence.IsCancelled)
            {
                throw new ArgumentException("Cannot book a cancelled activity occurrence");
            }

            if(occurrence.EndTime < DateTime.UtcNow) // has the occurrence already happened?
            {
                throw new ArgumentException("Cannot book an activity occurrence that has already ended.");
            }

            if ((occurrence.StartTime.Date == DateTime.UtcNow.Date) && (occurrence.StartTime.Hour - DateTime.UtcNow.Hour) < 2) // less than 2 hours to start
            {
                throw new ArgumentException("Bookings must be made at least 2 hours before the activity starts.");
            }

            var avaiableSpots = await AvailableSpotsForOccurrence(createDto.ActivityOccurenceId, ct);   // check available spots

            if (avaiableSpots < createDto.Participants)
            {
                throw new ArgumentException($"Not enough available spots. Requested: {createDto.Participants}, Available: {avaiableSpots}");
            }

            var existingBookings = _unitOfWork.Bookings.GetFilteredAsync(
                includeProperties: "",
                filter: b => b.UserId == user.Id && b.ActivityOccurenceId == createDto.ActivityOccurenceId && b.IsActive && !b.IsCancelled,
                ct: ct
            ).Result;

            if(existingBookings.Any()) // user already has an active booking for this occurrence
            {
                throw new ArgumentException("User already has an active booking for this activity occurrence.");
            }

            var sameTimeBookings = _unitOfWork.Bookings.GetFilteredAsync(
                includeProperties: "",
                filter: b => b.UserId == user.Id && b.IsActive && !b.IsCancelled &&
                             ((b.ActivityOccurence.StartTime < occurrence.EndTime && b.ActivityOccurence.StartTime > occurrence.StartTime) ||
                             (b.ActivityOccurence.EndTime > occurrence.StartTime && b.ActivityOccurence.EndTime < occurrence.EndTime) ||
                             (b.ActivityOccurence.StartTime < occurrence.StartTime && b.ActivityOccurence.EndTime > occurrence.EndTime)),
                ct: ct
                );

            if(sameTimeBookings.Result.Any()) // user has another booking that overlaps in time
            {
                throw new ArgumentException("User has another active booking that overlaps in time with this activity occurrence.");
            }

            var booking = _mapper.Map<Booking>(createDto);

            booking.UserId = user.Id;
            booking.CreatedAt = DateTime.UtcNow;
            booking.UpdatedAt = DateTime.UtcNow;

            await _unitOfWork.Bookings.AddAsync(booking, ct);
            await _unitOfWork.SaveChangesAsync(ct);

            // H�mta booking med relaterad data innan vi returnerar
            var createdBookings = await _unitOfWork.Bookings.GetFilteredAsync(
                includeProperties: "ActivityOccurence.Activity",
                filter: b => b.Id == booking.Id,
                ct: ct);

            return _mapper.Map<BookingReadDTO>(createdBookings.First());
        }

        /// <inheritdoc />
        public async Task<BookingReadDTO> UpdateAsync(int id, BookingUpdateDTO updateDto, string userName, CancellationToken ct)
        {
            var existing = await _unitOfWork.Bookings.GetByIdAsync(id, ct);     // is thier a booking?
            if (existing == null)
            {
                throw new KeyNotFoundException($"Booking with id {id} was not found.");
            }

            var user = await _userManager.FindByIdAsync(existing.UserId);   // is user alive?
            if (user == null)
            {
                throw new KeyNotFoundException($"User with id {existing.UserId} was not found.");
            }
            if (user.IsSuspended)   // is user a victim of cancell culture
            {
                throw new InvalidOperationException($"User '{user.FirstName} {user.LastName}' is suspended and cannot modify bookings.");
            }

            if (updateDto.Participants != existing.Participants)    // if number of participants is changing
            {
                var occurrence = await _unitOfWork.ActivityOccurrences.GetByIdAsync(existing.ActivityOccurenceId, ct);
                if (occurrence == null)
                {
                    throw new KeyNotFoundException($"ActivityOccurrence with id {existing.ActivityOccurenceId} not found");
                }

                int difference = updateDto.Participants - existing.Participants;    // count the difference

                if (difference > 0) // if increasing the number of participants
                {
                    var actualAvailableSpots = await AvailableSpotsForOccurrence(existing.ActivityOccurenceId, ct);

                    if (actualAvailableSpots < difference)
                    {
                        throw new ArgumentException($"Not enough available spots. Requested additional: {difference}, Available: {actualAvailableSpots}");
                    }
                }

                occurrence.AvailableSpots -= difference;
                await _unitOfWork.ActivityOccurrences.UpdateAsync(occurrence, ct);
            }

            _mapper.Map(updateDto, existing);

            existing.UpdatedAt = DateTime.UtcNow;

            await _unitOfWork.Bookings.UpdateAsync(existing, ct);
            await _unitOfWork.SaveChangesAsync(ct);

            // H�mta booking med relaterad data innan vi returnerar
            var updatedBookings = await _unitOfWork.Bookings.GetFilteredAsync(
                includeProperties: "ActivityOccurence.Activity",
                filter: b => b.Id == id,
                ct: ct);

            return _mapper.Map<BookingReadDTO>(updatedBookings.First());
        }

        /// <inheritdoc/>
        public async Task CancelBookingAsync(int id, CancellationToken ct)
        {
            var booking = await _unitOfWork.Bookings.GetByIdAsync(id, ct);

            if (booking == null)
                throw new KeyNotFoundException($"Booking with id {id} was not found.");

            if (booking.IsCancelled == true)
                throw new ArgumentException($"Booking with id {id} is already cancelled.");

            booking.IsActive = false;
            booking.IsCancelled = true;
            booking.UpdatedAt = DateTime.UtcNow;
            await _unitOfWork.Bookings.UpdateAsync(booking, ct);
            await _unitOfWork.SaveChangesAsync(ct);
        }

        /// <inheritdoc />
        public async Task DeleteAsync(int id, CancellationToken ct)
        {
            var booking = await _unitOfWork.Bookings.GetByIdAsync(id, ct);
            if (booking == null)
                throw new KeyNotFoundException($"Booking with id {id} was not found.");

            if (!booking.IsCancelled)   // reinstate available spots if booking was not cancelled
            {
                var occurrence = await _unitOfWork.ActivityOccurrences.GetByIdAsync(booking.ActivityOccurenceId, ct);
                if (occurrence != null)
                {
                    occurrence.AvailableSpots += booking.Participants;
                    await _unitOfWork.ActivityOccurrences.UpdateAsync(occurrence, ct);
                }
            }

            await _unitOfWork.Bookings.DeleteAsync(booking.Id, ct);
            await _unitOfWork.SaveChangesAsync(ct);
        }

        public async Task<int> AvailableSpotsForOccurrence(int occurrenceId, CancellationToken ct = default)
        {
            var occurrence = await _unitOfWork.ActivityOccurrences.GetByIdAsync(occurrenceId, ct);
            if (occurrence == null)
            {
                throw new KeyNotFoundException($"ActivityOccurrence with id {occurrenceId} not found"); // if occurrence does not exiwsts
            }

            var activeBookings = await _unitOfWork.Bookings.GetFilteredAsync(
                includeProperties: "",
                filter: b => b.ActivityOccurenceId == occurrenceId && b.IsActive && !b.IsCancelled,
                ct: ct
            );

            int totalBookedSpots = activeBookings.Sum(b => b.Participants); // sum of all active bookings

            int availableSpots = occurrence.Capacity - totalBookedSpots;    // calculate available spots

            return availableSpots >= 0 ? availableSpots : 0;

        }
    }
}
