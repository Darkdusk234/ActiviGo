
using ActiviGoApi.Infrastructur.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActiviGoApi.Infrastructur.Repositories
{
    public class ActivityRepository : GenericRepository<Activity>
    {
        public ActivityRepository(ToadContext context) : base(context)
        {
        }
        // Aquí puedes agregar métodos específicos para Activity si es necesario
    }
}
