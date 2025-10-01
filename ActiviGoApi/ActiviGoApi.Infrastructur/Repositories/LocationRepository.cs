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
    public class LocationRepository : GenericRepository<Location>
    {
        public LocationRepository(ToadContext context) : base(context)
        {
        }

        // Aquí puedes agregar métodos específicos para Location si es necesario
    }
}
