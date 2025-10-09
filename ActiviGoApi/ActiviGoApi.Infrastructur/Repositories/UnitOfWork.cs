using ActiviGoApi.Core.Interfaces;
using ActiviGoApi.Core.Models;
using ActiviGoApi.Infrastructur.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActiviGoApi.Infrastructur.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ToadContext _context;

        // Private repositories added here
        private LocationRepository? _locationRepository;

        private ActivityOccuranceRepository? _activityOccuranceRepository;


        private ActivityRepository? _activityRepository;

        private IGenericRepository<Category>? _categoryRepository;

        private BookingRepository? _bookingRepository;

        private SubLocationRepository? _subLocationRepository;



        // Public properties to access the repositories added here
        public LocationRepository Locations => _locationRepository ??= new LocationRepository(_context);

        public ActivityRepository Activities => _activityRepository ??= new ActivityRepository(_context);

        public IGenericRepository<Category> Categories => _categoryRepository ??= new GenericRepository<Category>(_context);

        public BookingRepository Bookings => _bookingRepository ??= new BookingRepository(_context);
        public ActivityOccuranceRepository ActivityOccurrences => _activityOccuranceRepository ??= new ActivityOccuranceRepository(_context);

        public SubLocationRepository SubLocations => _subLocationRepository ??= new SubLocationRepository(_context);
        public UnitOfWork(ToadContext context)
        {
            _context = context;
        }

        public async Task<bool> SaveChangesAsync(CancellationToken ct = default)
        {
            return await _context.SaveChangesAsync(ct) > 0;
        }
    }
}
