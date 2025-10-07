namespace ActiviGoApi.Infrastructur.Repositories
{
    public interface IUnitOfWork
    {
        // Add properties for each repository with only a getter
        LocationRepository Locations { get; }
        ActivityRepository Activities { get; }
        BookingRepository Bookings { get; }

        Task<bool> SaveChangesAsync(CancellationToken ct = default);
    }
}
