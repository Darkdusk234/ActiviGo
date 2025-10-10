using ActiviGoApi.Services.DTOs.ActivityOccurenceDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActiviGoApi.Services.Validation.DataValidation.ActivityOccurenceDTOValidators
{
    public class AOSearchDTOVali : AbstractValidator<ActivityOccurenceSearchFilterDTO>
    {
        public AOSearchDTOVali() 
        {
           
            RuleFor(x => x.StartTime)
                .LessThan(x => x.EndTime).WithMessage("Start time must be earlier than end time");

            RuleFor(x => x.EndTime)
                .GreaterThan(x => x.StartTime).WithMessage("End time must be later than start time");

            RuleFor(x => x.EndTime)
                .LessThan(DateTime.Now.AddDays(60)).WithMessage("You can only search 60 days into the future");

        }
    }
}
