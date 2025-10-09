using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ActiviGoApi.Services.DTOs.ActivityOccurenceDTOs;
using FluentValidation;

namespace ActiviGoApi.Services.Validation.DataValidation.ActivityOccurenceDTOValidators
{
    public class AOCreateDTOVali : AbstractValidator<CreateActivityOccurrenceDTO>
    {
        public AOCreateDTOVali() 
        { 
            RuleFor(x => x.StartTime)
                .NotEmpty().WithMessage("StartTime is required")
                .LessThan(x => x.EndTime).WithMessage("StartTime must be before EndTime");

            RuleFor(x => x.EndTime)
                .NotEmpty().WithMessage("EndTime is required")
                .GreaterThan(x => x.StartTime).WithMessage("EndTime must be after StartTime");

            RuleFor(x => x.Capacity)
                .NotEmpty().WithMessage("Capacity is required")
                .InclusiveBetween(1, 1000).WithMessage("Capacity must be between 1 and 1000");

            RuleFor(x => x.ActivityId)
                .Must(x => x > 0).WithMessage("ActivityId must be a positive integer");

            RuleFor(x => x.LocationId)
                .Must(x => x > 0).WithMessage("LocationId must be a positive integer");
        }
    }
}
