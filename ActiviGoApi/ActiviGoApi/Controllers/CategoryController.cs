using ActiviGoApi.Services.DTOs.CategpryDtos;
using ActiviGoApi.Services.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ActiviGoApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IValidator<CategoryCreateDto> _createValidator;
        private readonly IValidator<CategoryUpdateDto> _updateValidator;

        public CategoryController(ICategoryService categoryService, IValidator<CategoryCreateDto> createValidator,
            IValidator<CategoryUpdateDto> updateValidator)
        {
            _categoryService = categoryService;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll(CancellationToken ct)
        {
                var categories = await _categoryService.GetAllAsync(ct);
                return Ok(categories);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id, CancellationToken ct)
        {
            try
            {
                var category = await _categoryService.GetByIdAsync(id, ct);
                return Ok(category);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] CategoryCreateDto createDto, CancellationToken ct)
        {
            var validationResult = await _createValidator.ValidateAsync(createDto, ct);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            var createdCategory = await _categoryService.AddAsync(createDto, ct);
            return CreatedAtAction(nameof(GetById), new { id = createdCategory.Id }, createdCategory);
        }
    }
}
