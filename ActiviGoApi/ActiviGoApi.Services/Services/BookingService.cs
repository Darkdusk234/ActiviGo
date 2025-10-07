using ActiviGoApi.Core.Models;

using ActiviGoApi.Services.DTOs;
using ActiviGoApi.Services.Interfaces;
using AutoMapper;
using ActiviGoApi.Core.Interfaces;
using ActiviGoApi.Infrastructur.Repositories;

namespace ActiviGoApi.Services
{
    public class BookingService : IBookingService
    {
        private readonly IGenericRepository<Booking> _repo;
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public BookingService(IGenericRepository<Booking> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        /// <inheritdoc />
        public async Task<IEnumerable<BookingReadDTO>> GetAllAsync(CancellationToken ct)
        {
            var bookings = await _repo.GetAllAsync(ct);
            return _mapper.Map<IEnumerable<BookingReadDTO>>(bookings);
        }

        /// <inheritdoc />
        public async Task<BookingReadDTO?> GetByIdAsync(int id, CancellationToken ct)
        {
            var booking = await _repo.GetByIdAsync(id, ct);
            if (booking == null)
            {
                throw new KeyNotFoundException($"Booking with id {id} was not found.");
            }
            return _mapper.Map<BookingReadDTO>(booking);
        }

        /// <inheritdoc />
        public async Task<BookingReadDTO> AddAsync(BookingCreateDTO createDto, CancellationToken ct)
        {
            if (createDto.Participants <= 0)
                throw new ArgumentException("Number of participants must be greater than zero.");

            var booking = _mapper.Map<Booking>(createDto);

            await _repo.AddAsync(booking, ct);
            await _uow.SaveChangesAsync(ct);

            return _mapper.Map<BookingReadDTO>(booking);
        }

        /// <inheritdoc />
        public async Task<BookingReadDTO> UpdateAsync(int id, BookingUpdateDTO updateDto, CancellationToken ct)
        {
            var existing = await _repo.GetByIdAsync(id, ct);
            if (existing == null)
                throw new KeyNotFoundException($"Booking with id {id} was not found.");

            if (updateDto.Participants <= 0)
                throw new ArgumentException("Number of participants must be greater than zero.");

            _mapper.Map(updateDto, existing);
            await _repo.UpdateAsync(existing, ct);
            await _uow.SaveChangesAsync(ct);

            return _mapper.Map<BookingReadDTO>(existing);
        }

        /// <inheritdoc />
        public async Task DeleteAsync(int id, CancellationToken ct)
        {
            var booking = await _repo.GetByIdAsync(id, ct);
            if (booking == null)
                throw new KeyNotFoundException($"Booking with id {id} was not found.");

            await _repo.DeleteAsync(booking.Id, ct);
            await _uow.SaveChangesAsync(ct);
        }
    }
}
