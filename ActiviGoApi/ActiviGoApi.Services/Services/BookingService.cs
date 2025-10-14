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
        private readonly UserManager<User> _userManager;    // To find user id with FindByIdAsync


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
            var bookings = await _unitOfWork.Bookings.GetAllAsync(ct);
            return _mapper.Map<IEnumerable<BookingReadDTO>>(bookings);
        }

        /// <inheritdoc />
        public async Task<BookingReadDTO?> GetByIdAsync(int id, CancellationToken ct)
        {
            var booking = await _unitOfWork.Bookings.GetByIdAsync(id, ct);
            if (booking == null)
            {
                throw new KeyNotFoundException($"Booking with id {id} was not found.");
            }
            return _mapper.Map<BookingReadDTO>(booking);
        }

        /// <inheritdoc />
        public async Task<BookingReadDTO> AddAsync(BookingCreateDTO createDto, CancellationToken ct)
        {
            var userIsAlive = await _userManager.FindByIdAsync(createDto.UserId);   // is user alive?   
            if (userIsAlive == null)
            {
                throw new KeyNotFoundException($"User with id {createDto.UserId} was not found.");
            }

            var occurneceExists = await _unitOfWork.ActivityOccurrences.GetByIdAsync(createDto.ActivityOccurenceId, ct);   // does occurnce exiwsts?
            if (occurneceExists == null)
            {
                throw new KeyNotFoundException($"Occurrence with id {createDto.ActivityOccurenceId} was not found.");
            }

            if (occurneceExists.AvailableSpots < createDto.Participants)     // are there enough available spots?
            {
                throw new ArgumentException($"Not enough available spots. Requested: {createDto.Participants}, Available: {occurneceExists.AvailableSpots}");
            }

            if (occurneceExists.IsCancelled)    // is occurnce cancelled?
            {
                throw new ArgumentException("Cannot book a cancelled activity occurrence");
            }

            var booking = _mapper.Map<Booking>(createDto);
            booking.CreatedAt = DateTime.UtcNow;

            await _unitOfWork.Bookings.AddAsync(booking, ct);

            occurneceExists.AvailableSpots -= createDto.Participants;    // Decrease available spots

            await _unitOfWork.Bookings.AddAsync(booking, ct);
            await _unitOfWork.SaveChangesAsync(ct);
            
            return _mapper.Map<BookingReadDTO>(booking);
        }

        /// <inheritdoc />
        public async Task<BookingReadDTO> UpdateAsync(int id, BookingUpdateDTO updateDto, CancellationToken ct)
        {
            var existing = await _unitOfWork.Bookings.GetByIdAsync(id, ct);
            if (existing == null)
                throw new KeyNotFoundException($"Booking with id {id} was not found.");


            if (updateDto.Participants != existing.Participants)        // if number of participants is changing
            {
                var occurrence = await _unitOfWork.ActivityOccurrences.GetByIdAsync(existing.ActivityOccurenceId, ct);
                if (occurrence == null)
                    throw new KeyNotFoundException($"ActivityOccurrence with id {existing.ActivityOccurenceId} not found");

                int difference = updateDto.Participants - existing.Participants;

                if (difference > 0 && occurrence.AvailableSpots < difference)
                {
                    throw new ArgumentException($"Not enough available spots. Requested additional: {difference}, Available: {occurrence.AvailableSpots}");
                }

                occurrence.AvailableSpots -= difference;
                await _unitOfWork.ActivityOccurrences.UpdateAsync(occurrence, ct);
            }

            _mapper.Map(updateDto, existing);
            await _unitOfWork.Bookings.UpdateAsync(existing, ct);
            await _unitOfWork.SaveChangesAsync(ct);

            return _mapper.Map<BookingReadDTO>(existing);
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
    }
}
