using ActiviGoApi.Services.DTOs.CategpryDtos;
using FluentValidation;

namespace ActiviGoApi.Services.Validation.DataValidation.CategoryDtoValidotrs
{
    public class CategoryUpdateDto_Validator : AbstractValidator<CategoryUpdateDto>
    {
        public CategoryUpdateDto_Validator()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(100).WithMessage("Name cannot exceed 100 characters.");

            RuleFor(c => c.Description)
                .MaximumLength(500).WithMessage("Description cannot exceed 500 characters.");
        }
    }
}
