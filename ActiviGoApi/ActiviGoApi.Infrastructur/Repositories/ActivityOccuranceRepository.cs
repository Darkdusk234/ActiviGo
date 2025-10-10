using ActiviGoApi.Core.Models;
using ActiviGoApi.Infrastructur.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActiviGoApi.Infrastructur.Repositories
{
    public class ActivityOccuranceRepository : GenericRepository<ActivityOccurence>
    {
        public ActivityOccuranceRepository(ToadContext context) : base(context)
        {

        }
    }
}
