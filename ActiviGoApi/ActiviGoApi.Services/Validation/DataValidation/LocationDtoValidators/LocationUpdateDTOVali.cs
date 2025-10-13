using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ActiviGoApi.Services.DTOs.LocationDTOs;
using FluentValidation;

namespace ActiviGoApi.Services.Validation.DataValidation.LocationDtoValidators
{
    public class LocationUpdateDTOVali : AbstractValidator<UpdateLocationDTO>
    {
        public LocationUpdateDTOVali() 
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
                .MinimumLength(2).WithMessage("Latitude must be at least 2 characters")
                .Must(BeValidLatitude).WithMessage("Latitude must be a valid coordinate between -90 and 90");

            RuleFor(x => x.Longitude)
                .NotEmpty().WithMessage("Longitude is required")
                .MinimumLength(2).WithMessage("Longitude must be at least 2 characters")
                .Must(BeValidLongitude).WithMessage("Longitude must be a valid coordinate between -180 and 180");

        }
        private bool BeValidLatitude(string latitude)
        {
            if (string.IsNullOrWhiteSpace(latitude))
                return false;

            if (double.TryParse(latitude, out var lat))
            {
                return lat >= -90 && lat <= 90;
            }
            return false;
        }

        private bool BeValidLongitude(string longitude)
        {
            if (string.IsNullOrWhiteSpace(longitude))
                return false;

            if (double.TryParse(longitude, out var lon))
            {
                return lon >= -180 && lon <= 180;
            }
            return false;
        }
    }
    
}
