using ActiviGoApi.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActiviGoApi.Services.Services
{
    public class ActivityOccurenceService : IActivityOccurence
    {
        private readonly IUnitOfWork _unitOfWork;
        public ActivityOccurenceService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<ActivityOccurence>> GetAllAsync(CancellationToken ct = default)
        {
            return await _unitOfWork.ActivityOccurrences.GetAllAsync(ct);
        }
        public async Task<ActivityOccurence?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return await _unitOfWork.ActivityOccurrences.GetByIdAsync(id, ct);
        }

        public async Task<ActivityOccurence> CreateAsync(ActivityOccurence occurrence, CancellationToken ct = default)
        {
            await _unitOfWork.ActivityOccurrences.AddAsync(occurrence, ct);
            await _unitOfWork.SaveChangesAsync(ct);
            return occurrence;
        }

        public async Task<ActivityOccurence?> UpdateAsync(int id, ActivityOccurence occurrence, CancellationToken ct = default)
        {
            var existingOccurrence = await _unitOfWork.ActivityOccurrences.GetByIdAsync(id, ct);
            if (existingOccurrence == null)
            {
                return null;
            }

            existingOccurrence.ActivityId = occurrence.ActivityId;
            existingOccurrence.LocationId = occurrence.LocationId;
            existingOccurrence.StartTime = occurrence.StartTime;
            existingOccurrence.EndTime = occurrence.EndTime;
            _unitOfWork.ActivityOccurrences.Update(existingOccurrence);
            await _unitOfWork.SaveChangesAsync(ct);
            return existingOccurrence;
        }
        public async Task<bool> DeleteAsync(int id, CancellationToken ct = default)
        {
            var existingOccurrence = await _unitOfWork.ActivityOccurrences.GetByIdAsync(id, ct);
            if (existingOccurrence == null)
            {
                return false;
            }
            _unitOfWork.ActivityOccurrences.Delete(existingOccurrence);
            await _unitOfWork.SaveChangesAsync(ct);
            return true;
        }
    }
}
