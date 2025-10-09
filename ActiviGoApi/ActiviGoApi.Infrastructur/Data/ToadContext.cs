using ActiviGoApi.Core.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ActiviGoApi.Infrastructur.Data
{
    public class ToadContext : IdentityDbContext
    {
        public ToadContext(DbContextOptions<ToadContext> options) : base(options)
        {

        }

        public new DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<ActivityOccurence> ActivityOccurences { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<SubLocation> SubLocations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasMany<Booking>(u => u.Bookings)
                      .WithOne(b => b.User)
                      .HasForeignKey(b => b.UserId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<ActivityOccurence>(entity =>
            {
                entity.HasMany<Booking>(ao => ao.Bookings)
                      .WithOne(b => b.ActivityOccurence)
                      .HasForeignKey(b => b.ActivityOccurenceId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne<Activity>(ao => ao.Activity);
                entity.HasOne<SubLocation>(ao => ao.SubLocation);
            });

            modelBuilder.Entity<Activity>(entity =>
            {
                entity.HasMany<ActivityOccurence>(a => a.ActivityOccurrences)
                      .WithOne(ao => ao.Activity)
                      .HasForeignKey(ao => ao.ActivityId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.Property(a => a.Price).HasColumnType("decimal(18,2)");

                entity.HasOne<Category>(a => a.Category);
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasMany<Activity>(c => c.Activities)
                      .WithOne(a => a.Category)
                      .HasForeignKey(a => a.CategoryId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.HasMany<SubLocation>(l => l.SubLocations)
                      .WithOne(ao => ao.Location)
                      .HasForeignKey(ao => ao.LocationId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<SubLocation>(entity =>
            {
                entity.HasOne<Location>(sl => sl.Location);
                entity.HasMany<ActivityOccurence>(sl => sl.ActivityOccurences)
                        .WithOne(ao => ao.SubLocation)
                        .HasForeignKey(ao => ao.SubLocationId)
                        .OnDelete(DeleteBehavior.Cascade);
                entity.HasMany<Activity>(sl => sl.Activities)
                        .WithMany(a => a.SubLocations);

            });

            modelBuilder.Entity<Booking>(entity =>
            {
                entity.HasOne<User>(b => b.User);
                entity.HasOne<ActivityOccurence>(b => b.ActivityOccurence);
            });

            modelBuilder.Entity<Category>().HasData(SeedData.GetCategories().ToArray());
            modelBuilder.Entity<Activity>().HasData(SeedData.GetActivities().ToArray());
            modelBuilder.Entity<Location>().HasData(SeedData.GetLocations().ToArray());
            modelBuilder.Entity<SubLocation>().HasData(SeedData.GetSubLocations().ToArray());
            modelBuilder.Entity<ActivityOccurence>().HasData(SeedData.GetActivityOccurences().ToArray());
            modelBuilder.Entity<Booking>().HasData(SeedData.GetBookings().ToArray());
        }
    }
}
