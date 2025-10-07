using ActiviGoApi.Services.DTOs.SubLocationDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActiviGoApi.Services.Validation.DataValidation.SubLocationDtoValidators
{
    public class CreateSubLocationRequest_Validator : AbstractValidator<CreateSubLocationRequest>
    {
        public CreateSubLocationRequest_Validator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(100).WithMessage("Name cannot exceed 100 characters.");
            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage("Description cannot exceed 500 characters.");
            RuleFor(x => x.MaxCapacity)
                .GreaterThan(0).WithMessage("MaxCapacity must be greater than 0.");
            RuleFor(x => x.LocationId)
                .GreaterThan(0).WithMessage("LocationId must be a positive integer.");
        }
    }
}
