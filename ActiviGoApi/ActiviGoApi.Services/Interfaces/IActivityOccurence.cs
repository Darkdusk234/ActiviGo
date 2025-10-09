using ActiviGoApi.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActiviGoApi.Services.Interfaces
{
    public interface IActivityOccurence
    {
        Task<IEnumerable<ActivityOccurence>> GetAllAsync(CancellationToken ct = default);
        Task<ActivityOccurence?> GetByIdAsync(int id, CancellationToken ct = default);
        Task<ActivityOccurence> CreateAsync(ActivityOccurence occurrence, CancellationToken ct = default);
        Task<ActivityOccurence?> UpdateAsync(int id, ActivityOccurence occurrence, CancellationToken ct = default);
        Task<ActivityOccurence?> DeleteAsync(int id, CancellationToken ct = default);
    }
}
