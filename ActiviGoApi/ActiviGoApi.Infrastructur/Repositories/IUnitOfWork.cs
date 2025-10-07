using ActiviGoApi.Core.Interfaces;
using ActiviGoApi.Core.Models;

namespace ActiviGoApi.Infrastructur.Repositories
{
    public interface IUnitOfWork
    {
        // Add properties for each repository with only a getter
        LocationRepository Locations { get; }
        IGenericRepository<Category> Categories { get; }

        Task<bool> SaveChangesAsync(CancellationToken ct = default);
    }
}
