using ActiviGoApi.Core.Models;
using FluentValidation;
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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IValidator<BookingCreateDTO> _createValidator;
        private readonly IValidator<BookingUpdateDTO> _updateValidator;


        public BookingService(
            IGenericRepository<Booking> repo,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IValidator<BookingCreateDTO> createValidator,
            IValidator<BookingUpdateDTO> updateValidator)
        {
            _repo = repo;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        /// <inheritdoc />
        public async Task<IEnumerable<BookingReadDTO>> GetAllAsync(CancellationToken ct)
        {
            var bookings = await _unitOfWork.Activities.GetAllAsync(ct);
            return _mapper.Map<IEnumerable<BookingReadDTO>>(bookings);
        }

        /// <inheritdoc />
        public async Task<BookingReadDTO?> GetByIdAsync(int id, CancellationToken ct)
        {
            var booking = await _unitOfWork.Activities.GetByIdAsync(id, ct);
            if (booking == null)
            {
                throw new KeyNotFoundException($"Booking with id {id} was not found.");
            }
            return _mapper.Map<BookingReadDTO>(booking);
        }

        /// <inheritdoc />
        public async Task<BookingReadDTO> AddAsync(BookingCreateDTO createDto, CancellationToken ct)
        {
            var validationResult = await _createValidator.ValidateAsync(createDto, ct);
            if (!validationResult.IsValid)
            {
                var errors = string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage));
                throw new ValidationException($"Validation failed: {errors}");
            }
            var booking = _mapper.Map<Booking>(createDto);

            await _unitOfWork.Activities.AddAsync(booking, ct);
            await _unitOfWork.SaveChangesAsync(ct);

            return _mapper.Map<BookingReadDTO>(booking);
        }

        /// <inheritdoc />
        public async Task<BookingReadDTO> UpdateAsync(int id, BookingUpdateDTO updateDto, CancellationToken ct)
        {
            var validationResult = await _updateValidator.ValidateAsync(updateDto, ct);
            if (!validationResult.IsValid)
            {
                var errors = string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage));
                throw new ValidationException($"Validation failed: {errors}");
            }

            var existing = await _unitOfWork.Activities.GetByIdAsync(id, ct);
            if (existing == null)
                throw new KeyNotFoundException($"Booking with id {id} was not found.");

            
            _mapper.Map(updateDto, existing);
            await _repo.UpdateAsync(existing, ct);
            await _unitOfWork.SaveChangesAsync(ct);

            return _mapper.Map<BookingReadDTO>(existing);
        }

        /// <inheritdoc />
        public async Task DeleteAsync(int id, CancellationToken ct)
        {
            var booking = await _unitOfWork.Activities.GetByIdAsync(id, ct);
            if (booking == null)
                throw new KeyNotFoundException($"Booking with id {id} was not found.");

            await _repo.DeleteAsync(booking.Id, ct);
            await _unitOfWork.SaveChangesAsync(ct);
        }
    }
}
