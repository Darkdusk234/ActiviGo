using ActiviGoApi.Core.Models;
using ActiviGoApi.Services.Interfaces;
using ActiviGoApi.Infrastructur.Repositories;
using AutoMapper;
using ActiviGoApi.Services.DTOs.LocationDTOs;
using ActiviGoApi.Services.DTOs;

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

        public async Task<IEnumerable<LocationRequestDTO>> GetAllAsync(CancellationToken ct = default)
        {
            var locations = await _unitOfWork.Locations.GetAllAsync(ct);
            return _mapper.Map<IEnumerable<LocationRequestDTO>>(locations);
        }

        public async Task<LocationRequestDTO?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            var location = await _unitOfWork.Locations.GetByIdAsync(id, ct);
            if (location == null)
            {
                throw new KeyNotFoundException($"Location with id {id} not found.");
            }
            return _mapper.Map<LocationRequestDTO>(location);
        }           


        public async Task<LocationRequestDTO> AddAsync(CreateLocationDTO createDto, CancellationToken ct = default)
        {
            var creatingLocation = _mapper.Map<Location>(createDto);

            await _unitOfWork.Locations.AddAsync(creatingLocation, ct);
            await _unitOfWork.SaveChangesAsync(ct);
            return _mapper.Map<LocationRequestDTO>(creatingLocation);
        }

        public async Task<LocationRequestDTO?> UpdateAsync(int id, UpdateLocationDTO updateLocal, CancellationToken ct = default)
        {
            var existingLocal = await _unitOfWork.Locations.GetByIdAsync(id, ct);
            if (existingLocal == null)
            {
                throw new KeyNotFoundException($"Location with id {id} not found.");
            }

            _mapper.Map(updateLocal, existingLocal);


            await _unitOfWork.Locations.UpdateAsync(existingLocal, ct);
            await _unitOfWork.SaveChangesAsync(ct); 
            
            return _mapper.Map<LocationRequestDTO>(existingLocal);
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
