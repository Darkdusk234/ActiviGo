using ActiviGoApi.Core.Models;
using ActiviGoApi.Services.Interfaces;
using ActiviGoApi.Infrastructur.Repositories;

namespace ActiviGoApi.Services.Services
{
    public class LocationService : ILocationService
    {
        private readonly IUnitOfWork _unitOfWork;
        public LocationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<Location>> GetAllAsync(CancellationToken ct = default)
        {
            return await _unitOfWork.GetAllAsync(ct);
        }
        public async Task<Location?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return await _unitOfWork.Locations.GetByIdAsync(id, ct);
        }

        public async Task<Location> AddAsync(Location location, CancellationToken ct = default)
        {
            location.CreatedAt = DateTime.UtcNow;
            location.UpdatedAt = DateTime.UtcNow;

            var createdLocation = await _unitOfWork.Locations.AddAsync(location, ct);
            await _unitOfWork.SaveChangesAsync(ct);

            return createdLocation;
        }

        public async Task<Location?> UpdateAsync(int id, Location location, CancellationToken ct = default)
        {
            var updateLocation = await _unitOfWork.Locations.GetByIdAsync(id, ct);

            if (updateLocation != null) 
            { 
                return null;
            }

            updateLocation.Name = location.Name;
            updateLocation.Description = location.Description;
            updateLocation.Adress = location.Adress;
            updateLocation.Latitude = location.Latitude;
            updateLocation.Longitude = location.Longitude;
            updateLocation.Capacity = location.Capacity;
            updateLocation.IsIndoors = location.IsIndoors;
            updateLocation.IsActive = location.IsActive;
            updateLocation.UpdatedAt = DateTime.UtcNow;

            await _unitOfWork.Locations.UpdateAsync(updateLocation, ct);
            await _unitOfWork.SaveChangesAsync(ct); 
            
            return updateLocation;
        }
        public async Task<bool> DeleteAsync(int id, CancellationToken ct = default)
        {
            var result = await _unitOfWork.DeleteAsync(id, ct);

            if (result) // result true and save
            {
                await _unitOfWork.SaveChangesAsync(ct);
            }
            return result;
        }



    }
}
