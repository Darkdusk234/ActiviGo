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
    public class BookingRepository : GenericRepository<Booking>
    {
        public BookingRepository(ToadContext context) : base(context)
        {
        }

        // Aquí puedes agregar métodos específicos para Location si es necesario
    }
}
