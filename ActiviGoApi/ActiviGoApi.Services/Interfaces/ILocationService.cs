using ActiviGoApi.Core.Models;

namespace ActiviGoApi.Services.Interfaces
{
    public interface ILocationService
    {
        Task<IEnumerable<Location>>GetAllAsync(CancellationToken ct = default);
        Task<Location?> GetByIdAsync(int id, CancellationToken ct = default);
        Task <Location>AddAsync(Location location, CancellationToken ct = default);    // CreateAsync
        Task<Location?> UpdateAsync(int id, Location location, CancellationToken ct = default);
        Task<bool> DeleteAsync(int id, CancellationToken ct = default);
    }
}
