using ActiviGoApi.Core.Models;
using ActiviGoApi.Services.DTOs.LocationDTOs;

namespace ActiviGoApi.Services.Interfaces
{
    public interface ILocationService
    {
        Task<IEnumerable<Location>>GetAllAsync(CancellationToken ct = default);
        Task<Location?> GetByIdAsync(int id, CancellationToken ct = default);
        Task <Location>AddAsync(CreateLocationDTO createDto, CancellationToken ct = default);    // CreateAsync
        Task<Location?> UpdateAsync(int id, UpdateLocationDTO updateLocal, CancellationToken ct = default);
        Task DeleteAsync(int id, CancellationToken ct = default);
    }
}
