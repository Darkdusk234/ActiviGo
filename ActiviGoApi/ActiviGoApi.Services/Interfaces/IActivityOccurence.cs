using ActiviGoApi.Core.Models;
using ActiviGoApi.Services.DTOs.ActivityOccurenceDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActiviGoApi.Services.Interfaces
{
    public interface IActivityOccurence
    {
        Task<IEnumerable<ActivityOccurence>> GetAllAsync(CancellationToken ct = default);
        Task<ActivityOccurence?> GetByIdAsync(int id, CancellationToken ct = default);
        Task<ActivityOccurence> CreateAsync(CreateActivityOccurrenceDTO createAODTO, CancellationToken ct = default);
        Task<ActivityOccurence?> UpdateAsync(int id, UpdateActivityOccurrenceDTO updateAODTO, CancellationToken ct = default);
        Task<ActivityOccurence?> DeleteAsync(int id, CancellationToken ct = default);
    }
}
