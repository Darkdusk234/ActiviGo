using ActiviGoApi.Core.Models;
using ActiviGoApi.Services.Interfaces;
using ActiviGoApi.Infrastructur.Repositories;
using AutoMapper;
using ActiviGoApi.Services.DTOs.LocationDTOs;

namespace ActiviGoApi.Services.Services
{
    public class LocationService : ILocationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public LocationService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Location>> GetAllAsync(CancellationToken ct = default)
        {
            var locations = await _unitOfWork.Locations.GetAllAsync(ct);
            return _mapper.Map<IEnumerable<Location>>(locations);
        }

        public async Task<Location?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            var location = await _unitOfWork.Locations.GetByIdAsync(id, ct);
            if (location == null)
            {
                throw new KeyNotFoundException($"Location with id {id} not found.");
            }
            return location;
        }

        public async Task<Location> AddAsync(CreateLocationDTO createDto, CancellationToken ct = default)
        {
            var creatingLocation = _mapper.Map<Location>(createDto);

            await _unitOfWork.Locations.AddAsync(creatingLocation, ct);
            await _unitOfWork.SaveChangesAsync(ct);
            return creatingLocation;
        }

        public async Task<Location?> UpdateAsync(int id, UpdateLocationDTO updateLocal, CancellationToken ct = default)
        {
            var existingLocal = await _unitOfWork.Locations.GetByIdAsync(id, ct);
            if (existingLocal == null)
            {
                throw new KeyNotFoundException($"Location with id {id} not found.");
            }

            _mapper.Map(updateLocal, existingLocal);


            await _unitOfWork.Locations.UpdateAsync(existingLocal, ct);
            await _unitOfWork.SaveChangesAsync(ct); 
            
            return existingLocal;
        }

        public async Task DeleteAsync(int id, CancellationToken ct = default)
        {
            var location = await _unitOfWork.Locations.GetByIdAsync(id, ct);
            if (location == null)
            {
                throw new KeyNotFoundException($"Location with id {id} not found.");
            }
            await _unitOfWork.Locations.DeleteAsync(id, ct);
            await _unitOfWork.SaveChangesAsync(ct);
            
        }


    }
}
