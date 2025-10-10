using ActiviGoApi.Core.Models;
using ActiviGoApi.Services.DTOs;
using ActiviGoApi.Services.DTOs.LocationDTOs;

namespace ActiviGoApi.Services.Interfaces
{
    public interface ILocationService
    {
        Task<IEnumerable<LocationRequestDTO>>GetAllAsync(CancellationToken ct = default);
        Task<LocationRequestDTO?> GetByIdAsync(int id, CancellationToken ct = default);
        Task <LocationRequestDTO> AddAsync(CreateLocationDTO createDto, CancellationToken ct = default);    // CreateAsync
        Task<LocationRequestDTO?> UpdateAsync(int id, UpdateLocationDTO updateLocal, CancellationToken ct = default);
        Task DeleteAsync(int id, CancellationToken ct = default);
    }
}
