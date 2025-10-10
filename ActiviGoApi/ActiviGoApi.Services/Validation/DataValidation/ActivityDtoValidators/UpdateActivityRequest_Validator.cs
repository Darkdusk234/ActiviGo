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
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.Date).GreaterThan(DateTime.Now);
            RuleFor(x => x.Location).NotEmpty();
            RuleFor(x => x.MaxParticipants).GreaterThan(1);
            RuleFor(x => x.Price).GreaterThanOrEqualTo(0);

        }
    }
}
