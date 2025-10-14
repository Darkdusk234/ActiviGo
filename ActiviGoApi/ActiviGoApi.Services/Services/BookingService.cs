using ActiviGoApi.Core.Models;
using FluentValidation;
using ActiviGoApi.Services.Interfaces;
using AutoMapper;
using ActiviGoApi.Core.Interfaces;
using ActiviGoApi.Infrastructur.Repositories;
using ActiviGoApi.Services.DTOs.BookingDTOs;

namespace ActiviGoApi.Services
{
    public class BookingService : IBookingService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public BookingService(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
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
            var booking = _mapper.Map<Booking>(createDto);

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

            await _unitOfWork.Bookings.DeleteAsync(booking.Id, ct);
            await _unitOfWork.SaveChangesAsync(ct);
        }
    }
}
