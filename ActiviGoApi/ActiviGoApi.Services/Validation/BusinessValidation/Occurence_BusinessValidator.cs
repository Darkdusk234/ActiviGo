using ActiviGoApi.Infrastructur.Repositories;
using ActiviGoApi.Services.DTOs.ActivityOccurenceDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActiviGoApi.Services.Validation.BusinessValidation
{
    public class Occurence_BusinessValidator : IOccurence_BusinessValidator
    {
        private readonly IUnitOfWork _unitOfWork;

        public Occurence_BusinessValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> IsSubLocationOccupied(DateTime start, DateTime end, int subLocationId)
        {
            var list = await _unitOfWork.ActivityOccurrences.GetAllAsync();

            return !list.Any(a =>
                ((start >= a.StartTime && start < a.EndTime) ||
                 (end > a.StartTime && end <= a.EndTime) ||
                 (start <= a.StartTime && end >= a.EndTime))
            );
        }

        public async Task<bool> IsActivityOccurrenceExists(int id)
        {
            var occurrence = await _unitOfWork.ActivityOccurrences.GetByIdAsync(id);
            return occurrence != null;
        }

        public async Task<bool> IsSubLocationExists(int id)
        {
            var subLocation = await _unitOfWork.SubLocations.GetByIdAsync(id);
            return subLocation != null;
        }

        public async Task<bool> IsCapacityLargerThanSubLocationMaxCapacity(int subLocationId, int capacity)
        {
            var subLocation = await _unitOfWork.SubLocations.GetByIdAsync(subLocationId);
            if(subLocation == null)
            {
                throw new KeyNotFoundException($"SubLocation with id {subLocationId} not found");
            }

            return capacity <= subLocation.MaxCapacity;

        }

        public async Task<IEnumerable<string>> ValidateAsync(CreateActivityOccurrenceDTO entity, CancellationToken ct = default)
        {
            var errors = new List<string>();

            if(!await IsSubLocationOccupied(entity.StartTime, entity.EndTime, entity.SubLocationId))
            {
                errors.Add("The sublocation is occupied during the specified time.");
            }
            if (!await IsSubLocationExists(entity.SubLocationId))
            {
                errors.Add($"SubLocation with id {entity.SubLocationId} does not exist.");
            }
            if(await IsActivityOccurrenceExists(entity.ActivityId))
            {
                errors.Add($"ActivityOccurrence with id {entity.ActivityId} already exists.");

            }
            if(!await IsCapacityLargerThanSubLocationMaxCapacity(entity.SubLocationId, entity.Capacity))
            {
                errors.Add("The requested capacity exceeds the sublocation's maximum capacity.");
            }

            return errors;
        }


    }
}
