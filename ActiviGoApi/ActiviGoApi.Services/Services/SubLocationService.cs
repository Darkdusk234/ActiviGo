using ActiviGoApi.Core.Models;
using ActiviGoApi.Infrastructur.Repositories;
using ActiviGoApi.Services.DTOs.SubLocationDTOs;
using ActiviGoApi.Services.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActiviGoApi.Services.Services
{
    public class SubLocationService : ISubLocationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SubLocationService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<GetSubLocationResponse> CreateSubLocationAsync(CreateSubLocationRequest request, CancellationToken ct = default)
        {
            var local = await _unitOfWork.Locations.GetByIdAsync(request.LocationId, ct);
            if (local == null)
            {
                throw new KeyNotFoundException($"Location with id {request.LocationId} not found");
            }

            var created = await _unitOfWork.SubLocations.AddAsync(_mapper.Map<Core.Models.SubLocation>(request), ct);
            await _unitOfWork.SaveChangesAsync(ct);

            return _mapper.Map<GetSubLocationResponse>(created);
        }

        public async Task<bool> DeleteSubLocationAsync(int id, CancellationToken ct = default)
        {
            await _unitOfWork.SubLocations.DeleteAsync(id, ct);
            return await _unitOfWork.SaveChangesAsync(ct);
        }

        public async Task<IEnumerable<GetSubLocationResponse>> GetAllSubLocationsAsync(CancellationToken ct = default)
        {
            var subs = await _unitOfWork.SubLocations.GetAllAsync(ct);
            if (subs == null || !subs.Any())
            {
                throw new KeyNotFoundException("No SubLocations found");
            }

            return _mapper.Map<IEnumerable<GetSubLocationResponse>>(subs);
        }

        public async Task<GetSubLocationResponse?> GetSubLocationByIdAsync(int id, CancellationToken ct = default)
        {
            var location = await _unitOfWork.SubLocations.GetByIdAsync(id, ct);
            if (location == null)
            {
                throw new KeyNotFoundException($"SubLocation with id {id} not found");
            }

            return _mapper.Map<GetSubLocationResponse>(location);
        }

        public async Task<bool> UpdateSubLocationAsync(int id, UpdateSubLocationRequest dto, CancellationToken ct = default)
        {
            var toUpdate = await _unitOfWork.SubLocations.GetByIdAsync(id, ct);

            if (toUpdate == null)
            {
                throw new KeyNotFoundException($"SubLocation with id {id} not found");
            }
            else
            {
                var updated = _mapper.Map<SubLocation>(dto);
                updated.Id = id; // Ensure the ID remains the same
                await _unitOfWork.SubLocations.UpdateAsync(updated, ct);
                await _unitOfWork.SaveChangesAsync(ct);
            }
            return true;
        }
    }
}
