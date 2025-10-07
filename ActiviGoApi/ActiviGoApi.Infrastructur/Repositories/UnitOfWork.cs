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
        private BookingRepository? _bookingRepository;


        // Public properties to access the repositories added here
        public LocationRepository Locations => _locationRepository ??= new LocationRepository(_context);
        public BookingRepository Bookings => _bookingRepository ??= new BookingRepository(_context);

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
