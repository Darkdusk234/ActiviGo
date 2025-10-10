using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ActiviGoApi.Services.DTOs.LocationDTOs;
using FluentValidation;

namespace ActiviGoApi.Services.Validation.DataValidation.LocationDtoValidators
{
    public class LocationCreateDTOVali : AbstractValidator<CreateLocationDTO>
    {
        public LocationCreateDTOVali() 
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required")
                .MinimumLength(3).WithMessage("Name must be at least 3 characters")
                .MaximumLength(100).WithMessage("Name cannot exceed 100 characters");

            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage("Description cannot exceed 500 characters");

            RuleFor(x => x.Adress)
                .MaximumLength(200).WithMessage("Address cannot exceed 200 characters");

            RuleFor(x => x.Latitude)
                .NotEmpty().WithMessage("Latitude is required")
                .MinimumLength(2).WithMessage("Latitude must be at least 2 characters");

            RuleFor(x => x.Longitude)
                .NotEmpty().WithMessage("Longitude is required")
                .MinimumLength(2).WithMessage("Longitude must be at least 2 characters");

        }
    }
}
