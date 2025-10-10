using ActiviGoApi.Services.DTOs.ActivityOccurenceDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActiviGoApi.Services.Validation.BusinessValidation
{
    internal interface IOccurence_BusinessValidator :IBusinessValidator<CreateActivityOccurrenceDTO>
    {
        Task<bool> IsSubLocationOccupied(DateTime start, DateTime end, int subLocationId);
        Task<bool> IsSubLocationExists(int id);
        Task<bool> IsActivityOccurrenceExists(int id);
        Task<bool> IsCapacityLargerThanSubLocationMaxCapacity(int subLocationId, int capacity);


    }
}
