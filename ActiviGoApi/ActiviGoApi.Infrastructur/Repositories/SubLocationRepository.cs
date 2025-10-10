using ActiviGoApi.Core.Models;
using ActiviGoApi.Infrastructur.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActiviGoApi.Infrastructur.Repositories
{
    public class SubLocationRepository : GenericRepository<SubLocation>
    {
        public SubLocationRepository(ToadContext context) : base(context)
        {
        }

    }
}
