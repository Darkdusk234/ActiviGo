using ActiviGoApi.Services.DTOs.ActivityDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActiviGoApi.Services.Interfaces
{
    public interface IActivityService
    {
        public Task<bool> CreateActivityAsync(CreateActivityRequest dto, CancellationToken ct = default);
        public Task<IEnumerable<GetActivityResponse>> GetAllActivitiesAsync(CancellationToken ct = default);
        public Task<GetActivityResponse> GetActivityByIdAsync(int id, CancellationToken ct = default);
        public Task<bool> UpdateActivityAsync(int id, UpdateActivityRequest dto, CancellationToken ct = default);
        public Task<bool> DeleteActivityAsync(int id, CancellationToken ct = default);
        public Task<IEnumerable<GetActivityResponse>> GetActivitiesByCategoryIdAsync(int categoryId, CancellationToken ct = default);
    }
}
