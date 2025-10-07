using ActiviGoApi.Services.DTOs;

namespace ActiviGoApi.Services.Interfaces
{
    /// <summary>
    /// Defines the contract for booking-related operations.
    /// </summary>
    public interface IBookingService
    {
        /// <summary>
        /// Retrieves all bookings.
        /// </summary>
        /// <param name="ct">Cancellation token to cancel the operation.</param>
        /// <returns>A collection of booking DTOs.</returns>
        Task<IEnumerable<BookingReadDTO>> GetAllAsync(CancellationToken ct);

        /// <summary>
        /// Retrieves a single booking by its unique identifier.
        /// </summary>
        /// <param name="id">The ID of the booking to retrieve.</param>
        /// <param name="ct">Cancellation token to cancel the operation.</param>
        /// <returns>The booking DTO if found; otherwise, null.</returns>
        Task<BookingReadDTO?> GetByIdAsync(int id, CancellationToken ct);

        /// <summary>
        /// Creates a new booking.
        /// </summary>
        /// <param name="createDto">The data used to create the booking.</param>
        /// <param name="ct">Cancellation token to cancel the operation.</param>
        /// <returns>The created booking DTO.</returns>
        Task<BookingReadDTO> AddAsync(BookingCreateDTO createDto, CancellationToken ct);

        /// <summary>
        /// Updates an existing booking.
        /// </summary>
        /// <param name="id">The ID of the booking to update.</param>
        /// <param name="updateDto">The updated booking data.</param>
        /// <param name="ct">Cancellation token to cancel the operation.</param>
        /// <returns>The updated booking DTO if successful.</returns>
        Task<BookingReadDTO> UpdateAsync(int id, BookingUpdateDTO updateDto, CancellationToken ct);

        /// <summary>
        /// Deletes a booking by its ID.
        /// </summary>
        /// <param name="id">The ID of the booking to delete.</param>
        /// <param name="ct">Cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task DeleteAsync(int id, CancellationToken ct);
    }
}
