namespace ActiviGoApi.Infrastructur.Repositories
{
    public interface IUnitOfWork
    {
        // Add properties for each repository with only a getter
        LocationRepository Locations { get; }

        Task<bool> SaveChangesAsync(CancellationToken ct = default);
    }
}
