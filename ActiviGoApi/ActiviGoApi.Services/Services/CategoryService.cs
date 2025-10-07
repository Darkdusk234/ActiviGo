using ActiviGoApi.Core.Models;
using ActiviGoApi.Infrastructur.Repositories;
using ActiviGoApi.Services.DTOs.CategpryDtos;
using ActiviGoApi.Services.Interfaces;
using AutoMapper;

namespace ActiviGoApi.Services.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        /// <inheritdoc />
        public async Task<CategoryReadDto> AddAsync(CategoryCreateDto createDto, CancellationToken ct)
        {
            var newCategory = _mapper.Map<Category>(createDto);

            await _unitOfWork.Categories.AddAsync(newCategory, ct);
            await _unitOfWork.SaveChangesAsync(ct);

            return _mapper.Map<CategoryReadDto>(newCategory);
        }

        /// <inheritdoc />
        public async Task DeleteAsync(int id, CancellationToken ct)
        {
            var category = _unitOfWork.Categories.GetByIdAsync(id, ct);
            if(category == null)
            {
                throw new KeyNotFoundException($"Category with id {id} not found.");
            }

            await _unitOfWork.Categories.DeleteAsync(id, ct);
            await _unitOfWork.SaveChangesAsync(ct);
        }

        /// <inheritdoc />
        public async Task<IEnumerable<CategoryReadDto>> GetAllAsync(CancellationToken ct = default)
        {
            var categories = await _unitOfWork.Categories.GetAllAsync(ct);
            return _mapper.Map<IEnumerable<CategoryReadDto>>(categories);
        }

        /// <inheritdoc />
        public async Task<CategoryReadDto?> GetByIdAsync(int id, CancellationToken ct)
        {
            var category = await _unitOfWork.Categories.GetByIdAsync(id, ct);
            if(category == null)
            {
               throw new KeyNotFoundException($"Booking with id {id} was not found.");
            }

            return _mapper.Map<CategoryReadDto>(category);
        }

        /// <inheritdoc />
        public Task<CategoryReadDto?> UpdateAsync(int id, CategoryUpdateDto updateDto, CancellationToken ct)
        {
            throw new NotImplementedException();
        }
    }
}
