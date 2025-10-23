using ActiviGoApi.Services.DTOs.ActivityDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActiviGoApi.Services.Validation.DataValidation.ActivityDtoValidators
{
    public class UpdateActivityRequest_Validator : AbstractValidator<UpdateActivityRequest>
    {
        public UpdateActivityRequest_Validator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.IsActive).NotNull();
            RuleFor(x => x.CategoryId).NotEmpty();
            RuleFor(x => x.DurationInMinutes).GreaterThanOrEqualTo(30);
            RuleFor(x => x.Price).GreaterThanOrEqualTo(0);

        }
    }
}
