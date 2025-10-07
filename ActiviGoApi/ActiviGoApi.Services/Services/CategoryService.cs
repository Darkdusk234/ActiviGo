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
        public Task<CategoryReadDto> AddAsync(CategoryCreateDto createDto, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public Task DeleteAsync(int id, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public Task<IEnumerable<CategoryReadDto>> GetAllAsync(CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public Task<CategoryReadDto?> GetByIdAsync(int id, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public Task<CategoryReadDto?> UpdateAsync(int id, CategoryUpdateDto updateDto, CancellationToken ct)
        {
            throw new NotImplementedException();
        }
    }
}
