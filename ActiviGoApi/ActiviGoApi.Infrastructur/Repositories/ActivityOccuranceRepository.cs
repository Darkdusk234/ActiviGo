using ActiviGoApi.Core.Models;
using ActiviGoApi.Infrastructur.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ActiviGoApi.Infrastructur.Repositories
{
    public class ActivityOccuranceRepository : GenericRepository<ActivityOccurence>
    {
        private DbSet<ActivityOccurence> _dbSet;

        public ActivityOccuranceRepository(ToadContext context) : base(context)
        {
            _dbSet = context.Set<ActivityOccurence>();
        }
    }
}
