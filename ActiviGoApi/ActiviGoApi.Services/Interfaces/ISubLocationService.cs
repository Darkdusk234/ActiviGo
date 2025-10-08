using ActiviGoApi.Services.DTOs.SubLocationDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActiviGoApi.Services.Interfaces
{
    public interface ISubLocationService
    {
        public Task<IEnumerable<GetSubLocationResponse>> GetAllSubLocationsAsync(CancellationToken ct = default);
        public Task<GetSubLocationResponse?> GetSubLocationByIdAsync(int id, CancellationToken ct = default);

        public Task<GetSubLocationResponse> CreateSubLocationAsync(CreateSubLocationRequest request, CancellationToken ct = default);
        public Task<bool> UpdateSubLocationAsync(int id, UpdateSubLocationRequest dto, CancellationToken ct = default);

        public Task<bool> DeleteSubLocationAsync(int id, CancellationToken ct = default);

    }
}
