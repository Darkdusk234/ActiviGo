using ActiviGoApi.Services.DTOs.CategpryDtos;

namespace ActiviGoApi.Services.Interfaces
{
    public interface ICategoryService
    {
        /// <summary>
        /// Retrieves all categories.
        /// </summary>
        /// <param name="ct">Cancellation token to cancel the operation.</param>
        /// <returns>A collection of category DTOs.</returns>
        Task<IEnumerable<CategoryReadDto>> GetAllAsync(CancellationToken ct = default);

        /// <summary>
        /// Retrieves a single category by its unique identifier.
        /// </summary>
        /// <param name="id">The ID of the category to retrieve.</param>
        /// <param name="ct">Cancellation token to cancel the operation.</param>
        /// <returns>The category DTO if found; otherwise, null.</returns>
        Task<CategoryReadDto?> GetByIdAsync(int id, CancellationToken ct);

        /// <summary>
        /// Creates a new category.
        /// </summary>
        /// <param name="createDto">The data used to create the category.</param>
        /// <param name="ct">Cancellation token to cancel the operation.</param>
        /// <returns>The created category DTO.</returns>
        Task<CategoryReadDto> AddAsync(CategoryCreateDto createDto, CancellationToken ct);

        /// <summary>
        /// Updates an existing category.
        /// </summary>
        /// <param name="id">The ID of the category to update.</param>
        /// <param name="updateDto">The updated category data.</param>
        /// <param name="ct">Cancellation token to cancel the operation.</param>
        /// <returns>The updated category DTO if successful.</returns>
        Task<CategoryReadDto?> UpdateAsync(int id, CategoryUpdateDto updateDto, CancellationToken ct);

        /// <summary>
        /// Deletes a category by its ID.
        /// </summary>
        /// <param name="id">The ID of the category to delete.</param>
        /// <param name="ct">Cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task DeleteAsync(int id, CancellationToken ct);
    }
}
