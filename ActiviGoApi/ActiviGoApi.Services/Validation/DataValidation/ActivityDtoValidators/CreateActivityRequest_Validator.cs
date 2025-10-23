using ActiviGoApi.Services.DTOs.ActivityDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActiviGoApi.Services.Validation.DataValidation.ActivityDtoValidators
{
    public class CreateActivityRequest_Validator : AbstractValidator<CreateActivityRequest>
    {
        public CreateActivityRequest_Validator() 
        { 
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.IsActive).NotEmpty();
            RuleFor(x => x.DurationInMinutes).GreaterThan(30);
            RuleFor(x => x.MaxParticipants).GreaterThan(1);
            RuleFor(x => x.Price).GreaterThanOrEqualTo(0);
            RuleFor(x => x.CategoryId).NotEmpty();

        }
    }
}
