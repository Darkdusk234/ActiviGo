using ActiviGoApi.Core.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActiviGoApi.Infrastructur.Data
{

        // Deterministic explicit seed data (fixed DateTime values).
        // Each method returns exactly 20 unique items.
        public static class SeedData
        {
            // Fixed timestamp base values (UTC)
            private static readonly DateTime D1 = new DateTime(2025, 01, 01, 0, 0, 0, DateTimeKind.Utc);
            private static readonly DateTime D2 = new DateTime(2025, 02, 01, 0, 0, 0, DateTimeKind.Utc);
            private static readonly DateTime D3 = new DateTime(2025, 03, 01, 0, 0, 0, DateTimeKind.Utc);
            private static readonly DateTime D4 = new DateTime(2025, 04, 01, 0, 0, 0, DateTimeKind.Utc);

        public static List<Category> GetCategories()
            {
                return new List<Category>
            {
                new Category { Id = 1, Name = "Fitness", Description = "Strength and conditioning classes", CreatedAt = D1, UpdatedAt = D2 },
                new Category { Id = 2, Name = "Yoga", Description = "Mindfulness and flexibility sessions", CreatedAt = D1, UpdatedAt = D2 },
                new Category { Id = 3, Name = "Dance", Description = "Various dance styles and choreography", CreatedAt = D1, UpdatedAt = D2 },
                new Category { Id = 4, Name = "Martial Arts", Description = "Combat sports and self-defense", CreatedAt = D1, UpdatedAt = D2 },
                new Category { Id = 5, Name = "Swimming", Description = "Pool-based training and technique", CreatedAt = D1, UpdatedAt = D2 },
                new Category { Id = 6, Name = "Cycling", Description = "Indoor cycling classes and outdoor rides", CreatedAt = D1, UpdatedAt = D2 },
                new Category { Id = 7, Name = "Climbing", Description = "Bouldering and rope climbing instruction", CreatedAt = D1, UpdatedAt = D2 },
                new Category { Id = 8, Name = "Team Sports", Description = "Organized team training (soccer, basketball)", CreatedAt = D1, UpdatedAt = D2 },
                new Category { Id = 9, Name = "Running", Description = "Technique, intervals and endurance runs", CreatedAt = D1, UpdatedAt = D2 },
                new Category { Id = 10, Name = "Pilates", Description = "Core and posture improvement", CreatedAt = D1, UpdatedAt = D2 },
                new Category { Id = 11, Name = "Boxing", Description = "Pad work, sparring and conditioning", CreatedAt = D1, UpdatedAt = D2 },
                new Category { Id = 12, Name = "CrossFit", Description = "High-intensity functional training", CreatedAt = D1, UpdatedAt = D2 },
                new Category { Id = 13, Name = "Gymnastics", Description = "Floor, rings, bars and flexibility", CreatedAt = D1, UpdatedAt = D2 },
                new Category { Id = 14, Name = "Rowing", Description = "Indoor rowing technique and workouts", CreatedAt = D1, UpdatedAt = D2 },
                new Category { Id = 15, Name = "Skiing", Description = "Off-season training and technique", CreatedAt = D1, UpdatedAt = D2 },
                new Category { Id = 16, Name = "Shooting", Description = "Archery and target practice sessions", CreatedAt = D1, UpdatedAt = D2 },
                new Category { Id = 17, Name = "Outdoor", Description = "Hiking, trekking and outdoor skills", CreatedAt = D1, UpdatedAt = D2 },
                new Category { Id = 18, Name = "Wellness", Description = "Recovery, mobility and guided relaxation", CreatedAt = D1, UpdatedAt = D2 },
                new Category { Id = 19, Name = "Kids", Description = "Child-focused activities and classes", CreatedAt = D1, UpdatedAt = D2 },
                new Category { Id = 20, Name = "Senior", Description = "Low-impact sessions for older adults", CreatedAt = D1, UpdatedAt = D2 },
            };
            }

            public static List<Activity> GetActivities()
            {
                return new List<Activity>
            {
                new Activity { Id = 1, Name = "Morning Bootcamp", Description = "Intense full-body workout to start your day", DurationInMinutes = 45, Price = 12.50m, IMGUrl = "https://cdn.example.com/act1.jpg", IsActive = true, CategoryId = 1, CreatedAt = D1, UpdatedAt = D2 },
                new Activity { Id = 2, Name = "Sunrise Yoga", Description = "Gentle Vinyasa to wake the body", DurationInMinutes = 60, Price = 10.00m, IMGUrl = "https://cdn.example.com/act2.jpg", IsActive = true, CategoryId = 2, CreatedAt = D1, UpdatedAt = D2 },
                new Activity { Id = 3, Name = "Hip Hop Dance", Description = "Urban choreography for all levels", DurationInMinutes = 50, Price = 11.00m, IMGUrl = "https://cdn.example.com/act3.jpg", IsActive = true, CategoryId = 3, CreatedAt = D1, UpdatedAt = D2 },
                new Activity { Id = 4, Name = "Beginner Karate", Description = "Intro to basic strikes and stances", DurationInMinutes = 60, Price = 15.00m, IMGUrl = "https://cdn.example.com/act4.jpg", IsActive = true, CategoryId = 4, CreatedAt = D1, UpdatedAt = D2 },
                new Activity { Id = 5, Name = "Lap Swimming", Description = "Technique and endurance laps", DurationInMinutes = 30, Price = 8.00m, IMGUrl = "https://cdn.example.com/act5.jpg", IsActive = true, CategoryId = 5, CreatedAt = D1, UpdatedAt = D2 },
                new Activity { Id = 6, Name = "Spin Class", Description = "High-energy indoor cycling", DurationInMinutes = 45, Price = 13.00m, IMGUrl = "https://cdn.example.com/act6.jpg", IsActive = true, CategoryId = 6, CreatedAt = D1, UpdatedAt = D2 },
                new Activity { Id = 7, Name = "Top Rope Climbing", Description = "Belay and lead techniques", DurationInMinutes = 90, Price = 20.00m, IMGUrl = "https://cdn.example.com/act7.jpg", IsActive = true, CategoryId = 7, CreatedAt = D1, UpdatedAt = D2 },
                new Activity { Id = 8, Name = "Soccer Practice", Description = "Skill drills and small-sided games", DurationInMinutes = 75, Price = 9.50m, IMGUrl = "https://cdn.example.com/act8.jpg", IsActive = true, CategoryId = 8, CreatedAt = D1, UpdatedAt = D2 },
                new Activity { Id = 9, Name = "Interval Running", Description = "Speed intervals on the track", DurationInMinutes = 40, Price = 7.00m, IMGUrl = "https://cdn.example.com/act9.jpg", IsActive = true, CategoryId = 9, CreatedAt = D1, UpdatedAt = D2 },
                new Activity { Id = 10, Name = "Pilates Mat", Description = "Core stability and breath work", DurationInMinutes = 50, Price = 11.50m, IMGUrl = "https://cdn.example.com/act10.jpg", IsActive = true, CategoryId = 10, CreatedAt = D1, UpdatedAt = D2 },
                new Activity { Id = 11, Name = "Boxing Basics", Description = "Footwork, guard and combos", DurationInMinutes = 55, Price = 14.00m, IMGUrl = "https://cdn.example.com/act11.jpg", IsActive = true, CategoryId = 11, CreatedAt = D1, UpdatedAt = D2 },
                new Activity { Id = 12, Name = "WOD - Beginner", Description = "Scaled CrossFit workout of the day", DurationInMinutes = 60, Price = 16.00m, IMGUrl = "https://cdn.example.com/act12.jpg", IsActive = true, CategoryId = 12, CreatedAt = D1, UpdatedAt = D2 },
                new Activity { Id = 13, Name = "Kids Gym", Description = "Basic gymnastics for children", DurationInMinutes = 45, Price = 8.50m, IMGUrl = "https://cdn.example.com/act13.jpg", IsActive = true, CategoryId = 19, CreatedAt = D1, UpdatedAt = D2 },
                new Activity { Id = 14, Name = "Indoor Rowing", Description = "Technique and endurance on erg", DurationInMinutes = 30, Price = 9.00m, IMGUrl = "https://cdn.example.com/act14.jpg", IsActive = true, CategoryId = 14, CreatedAt = D1, UpdatedAt = D2 },
                new Activity { Id = 15, Name = "Trail Prep", Description = "Strength for off-road skiing and trekking", DurationInMinutes = 60, Price = 10.00m, IMGUrl = "https://cdn.example.com/act15.jpg", IsActive = true, CategoryId = 15, CreatedAt = D1, UpdatedAt = D2 },
                new Activity { Id = 16, Name = "Archery Basics", Description = "Introduction to recurve bow handling", DurationInMinutes = 60, Price = 18.00m, IMGUrl = "https://cdn.example.com/act16.jpg", IsActive = true, CategoryId = 16, CreatedAt = D1, UpdatedAt = D2 },
                new Activity { Id = 17, Name = "Hiking Meetup", Description = "Guided day hikes for mixed groups", DurationInMinutes = 300, Price = 25.00m, IMGUrl = "https://cdn.example.com/act17.jpg", IsActive = true, CategoryId = 17, CreatedAt = D1, UpdatedAt = D2 },
                new Activity { Id = 18, Name = "Mobility Class", Description = "Joint health and functional movement", DurationInMinutes = 40, Price = 9.00m, IMGUrl = "https://cdn.example.com/act18.jpg", IsActive = true, CategoryId = 18, CreatedAt = D1, UpdatedAt = D2 },
                new Activity { Id = 19, Name = "Advanced Gymnastics", Description = "Apparatus and tumbling skills", DurationInMinutes = 90, Price = 22.00m, IMGUrl = "https://cdn.example.com/act19.jpg", IsActive = true, CategoryId = 13, CreatedAt = D1, UpdatedAt = D2 },
                new Activity { Id = 20, Name = "Senior Balance", Description = "Low impact balance and coordination", DurationInMinutes = 45, Price = 7.50m, IMGUrl = "https://cdn.example.com/act20.jpg", IsActive = true, CategoryId = 20, CreatedAt = D1, UpdatedAt = D2 }
            };
            }

            public static List<Location> GetLocations()
            {
                return new List<Location>
            {
                new Location { Id = 1, Name = "Central Park", Description = "Large public park with open fields", Adress = "1 Central Park Way", Latitude = "57.785091", Longitude = "18.968285", IsActive = true, CreatedAt = D1, UpdatedAt = D2 },
                new Location { Id = 2, Name = "Riverside Grounds", Description = "Riverside recreational area", Adress = "2 Riverside Ave", Latitude = "57.800000", Longitude = "18.970000", IsActive = true, CreatedAt = D1, UpdatedAt = D2 },
                new Location { Id = 3, Name = "Harbor View", Description = "Coastal facility with views of the harbor", Adress = "3 Harbor Rd", Latitude = "57.700000", Longitude = "18.010000", IsActive = true, CreatedAt = D1, UpdatedAt = D2 },
                new Location { Id = 4, Name = "North End Complex", Description = "Community sports complex", Adress = "4 North End Ln", Latitude = "57.820000", Longitude = "18.950000", IsActive = true, CreatedAt = D1, UpdatedAt = D2 },
                new Location { Id = 5, Name = "South Gate Park", Description = "Southern parkland with trails", Adress = "5 South Gate Blvd", Latitude = "57.760000", Longitude = "18.980000", IsActive = true, CreatedAt = D1, UpdatedAt = D2 },
                new Location { Id = 6, Name = "East Point Center", Description = "East-side activity center", Adress = "6 East Point St", Latitude = "57.770000", Longitude = "18.930000", IsActive = true, CreatedAt = D1, UpdatedAt = D2 },
                new Location { Id = 7, Name = "West Field Grounds", Description = "Outdoor fields and courts", Adress = "7 West Field Dr", Latitude = "57.757000", Longitude = "18.990000", IsActive = true, CreatedAt = D1, UpdatedAt = D2 },
                new Location { Id = 8, Name = "City Center Arena", Description = "Indoor arena in city center", Adress = "8 City Center Pl", Latitude = "57.712776", Longitude = "18.005974", IsActive = true, CreatedAt = D1, UpdatedAt = D2 },
                new Location { Id = 9, Name = "Lakeside Venue", Description = "Venue by the lake", Adress = "9 Lakeside Rd", Latitude = "57.750000", Longitude = "18.000000", IsActive = true, CreatedAt = D1, UpdatedAt = D2 },
                new Location { Id = 10, Name = "Old Town Hall", Description = "Converted town hall used for activities", Adress = "10 Old Town Sq", Latitude = "57.730610", Longitude = "18.935242", IsActive = true, CreatedAt = D1, UpdatedAt = D2 },
                new Location { Id = 11, Name = "Green Meadow", Description = "Meadow with event lawns", Adress = "11 Meadow Ln", Latitude = "57.760500", Longitude = "18.982000", IsActive = true, CreatedAt = D1, UpdatedAt = D2 },
                new Location { Id = 12, Name = "Highlands Sports", Description = "Highland area with courts and gym", Adress = "12 Highlands Ave", Latitude = "57.780000", Longitude = "18.960000", IsActive = true, CreatedAt = D1, UpdatedAt = D2 },
                new Location { Id = 13, Name = "Sunset Plaza", Description = "Plaza suitable for classes and markets", Adress = "13 Sunset Blvd", Latitude = "57.710000", Longitude = "18.015000", IsActive = true, CreatedAt = D1, UpdatedAt = D2 },
                new Location { Id = 14, Name = "Mountain Base", Description = "Base facility near small hills", Adress = "14 Mountain Rd", Latitude = "57.850000", Longitude = "18.880000", IsActive = true, CreatedAt = D1, UpdatedAt = D2 },
                new Location { Id = 15, Name = "Valley Hub", Description = "Community hub in the valley", Adress = "15 Valley St", Latitude = "57.690000", Longitude = "18.020000", IsActive = true, CreatedAt = D1, UpdatedAt = D2 },
                new Location { Id = 16, Name = "Seafront Deck", Description = "Seafront with promenade", Adress = "16 Seafront Ave", Latitude = "57.700500", Longitude = "18.012000", IsActive = true, CreatedAt = D1, UpdatedAt = D2 },
                new Location { Id = 17, Name = "Meadow Park", Description = "Small park with playground", Adress = "17 Meadow Park Ln", Latitude = "57.755000", Longitude = "18.987000", IsActive = true, CreatedAt = D1, UpdatedAt = D2 },
                new Location { Id = 18, Name = "Station Square", Description = "Square adjacent to main station", Adress = "18 Station Sq", Latitude = "57.752726", Longitude = "18.977229", IsActive = true, CreatedAt = D1, UpdatedAt = D2 },
                new Location { Id = 19, Name = "Festival Grounds", Description = "Large open area used for events", Adress = "19 Festival Grounds", Latitude = "57.748000", Longitude = "18.985500", IsActive = true, CreatedAt = D1, UpdatedAt = D2 },
                new Location { Id = 20, Name = "Civic Plaza", Description = "Plaza in front of civic buildings", Adress = "20 Civic Plaza", Latitude = "57.741000", Longitude = "18.989000", IsActive = true, CreatedAt = D1, UpdatedAt = D2 }
            };
            }

            public static List<SubLocation> GetSubLocations()
            {
                return new List<SubLocation>
            {
                new SubLocation { Id = 1, Name = "Arena A1", Description = "Main arena at Central Park", MaxCapacity = 200, Indoors = false, LocationId = 1, CreatedAt = D2, UpdatedAt = D3 },
                new SubLocation { Id = 2, Name = "Court R2", Description = "Riverside multipurpose court", MaxCapacity = 60, Indoors = false, LocationId = 2, CreatedAt = D2, UpdatedAt = D3 },
                new SubLocation { Id = 3, Name = "Harbor Gym", Description = "Indoor gym at Harbor View", MaxCapacity = 80, Indoors = true, LocationId = 3, CreatedAt = D2, UpdatedAt = D3 },
                new SubLocation { Id = 4, Name = "North Hall", Description = "Large indoor hall for events", MaxCapacity = 150, Indoors = true, LocationId = 4, CreatedAt = D2, UpdatedAt = D3 },
                new SubLocation { Id = 5, Name = "South Field", Description = "Outdoor field for sports", MaxCapacity = 120, Indoors = false, LocationId = 5, CreatedAt = D2, UpdatedAt = D3 },
                new SubLocation { Id = 6, Name = "East Studio", Description = "Small studio for classes", MaxCapacity = 20, Indoors = true, LocationId = 6, CreatedAt = D2, UpdatedAt = D3 },
                new SubLocation { Id = 7, Name = "West Court 1", Description = "West Field indoor court 1", MaxCapacity = 60, Indoors = true, LocationId = 7, CreatedAt = D2, UpdatedAt = D3 },
                new SubLocation { Id = 8, Name = "City Arena", Description = "Indoor arena for tournaments", MaxCapacity = 500, Indoors = true, LocationId = 8, CreatedAt = D2, UpdatedAt = D3 },
                new SubLocation { Id = 9, Name = "Lakeside Deck", Description = "Open deck near lake", MaxCapacity = 50, Indoors = false, LocationId = 9, CreatedAt = D2, UpdatedAt = D3 },
                new SubLocation { Id = 10, Name = "Old Hall Studio", Description = "Community studio in Old Town Hall", MaxCapacity = 30, Indoors = true, LocationId = 10, CreatedAt = D2, UpdatedAt = D3 },
                new SubLocation { Id = 11, Name = "Green Meadow Arena", Description = "Seasonal arena on the meadow", MaxCapacity = 220, Indoors = false, LocationId = 11, CreatedAt = D2, UpdatedAt = D3 },
                new SubLocation { Id = 12, Name = "Highlands Court", Description = "Outdoor courts at Highlands", MaxCapacity = 80, Indoors = false, LocationId = 12, CreatedAt = D2, UpdatedAt = D3 },
                new SubLocation { Id = 13, Name = "Sunset Plaza Stage", Description = "Open stage for classes and events", MaxCapacity = 100, Indoors = false, LocationId = 13, CreatedAt = D2, UpdatedAt = D3 },
                new SubLocation { Id = 14, Name = "Mountain Gym", Description = "Training gym at Mountain Base", MaxCapacity = 60, Indoors = true, LocationId = 14, CreatedAt = D2, UpdatedAt = D3 },
                new SubLocation { Id = 15, Name = "Valley Hall", Description = "Community hall in Valley Hub", MaxCapacity = 140, Indoors = true, LocationId = 15, CreatedAt = D2, UpdatedAt = D3 },
                new SubLocation { Id = 16, Name = "Seafront Court", Description = "Outdoor seafront court", MaxCapacity = 70, Indoors = false, LocationId = 16, CreatedAt = D2, UpdatedAt = D3 },
                new SubLocation { Id = 17, Name = "Meadow Studio", Description = "Small studio by the meadow", MaxCapacity = 25, Indoors = true, LocationId = 17, CreatedAt = D2, UpdatedAt = D3 },
                new SubLocation { Id = 18, Name = "Station Square Arena", Description = "Arena adjacent to station", MaxCapacity = 180, Indoors = false, LocationId = 18, CreatedAt = D2, UpdatedAt = D3 },
                new SubLocation { Id = 19, Name = "Festival Field", Description = "Big open festival field", MaxCapacity = 1000, Indoors = false, LocationId = 19, CreatedAt = D2, UpdatedAt = D3 },
                new SubLocation { Id = 20, Name = "Civic Gym", Description = "Gym inside civic plaza building", MaxCapacity = 90, Indoors = true, LocationId = 20, CreatedAt = D2, UpdatedAt = D3 }
            };
            }

            public static List<ActivityOccurence> GetActivityOccurences()
            {
                return new List<ActivityOccurence>
            {
                new ActivityOccurence { Id = 1, StartTime = new DateTime(2025,10,10,8,0,0, DateTimeKind.Utc), EndTime = new DateTime(2025,10,10,9,0,0, DateTimeKind.Utc), Capacity = 20, AvailableSpots = 20, IsCancelled = false, ActivityId = 1, SubLocationId = 1, CreatedAt = D3, UpdatedAt = D4 },
                new ActivityOccurence { Id = 2, StartTime = new DateTime(2025,10,11,6,0,0, DateTimeKind.Utc), EndTime = new DateTime(2025,10,11,7,0,0, DateTimeKind.Utc), Capacity = 15, AvailableSpots = 15, IsCancelled = false, ActivityId = 2, SubLocationId = 6, CreatedAt = D3, UpdatedAt = D4 },
                new ActivityOccurence { Id = 3, StartTime = new DateTime(2025,10,12,18,0,0, DateTimeKind.Utc), EndTime = new DateTime(2025,10,12,19,30,0, DateTimeKind.Utc), Capacity = 25, AvailableSpots = 25, IsCancelled = false, ActivityId = 3, SubLocationId = 3, CreatedAt = D3, UpdatedAt = D4 },
                new ActivityOccurence { Id = 4, StartTime = new DateTime(2025,10,13,17,0,0, DateTimeKind.Utc), EndTime = new DateTime(2025,10,13,18,0,0, DateTimeKind.Utc), Capacity = 30, AvailableSpots = 30, IsCancelled = false, ActivityId = 4, SubLocationId = 4, CreatedAt = D3, UpdatedAt = D4 },
                new ActivityOccurence { Id = 5, StartTime = new DateTime(2025,10,14,7,0,0, DateTimeKind.Utc), EndTime = new DateTime(2025,10,14,7,30,0, DateTimeKind.Utc), Capacity = 12, AvailableSpots = 12, IsCancelled = false, ActivityId = 5, SubLocationId = 5, CreatedAt = D3, UpdatedAt = D4 },
                new ActivityOccurence { Id = 6, StartTime = new DateTime(2025,10,15,19,0,0, DateTimeKind.Utc), EndTime = new DateTime(2025,10,15,20,0,0, DateTimeKind.Utc), Capacity = 22, AvailableSpots = 22, IsCancelled = false, ActivityId = 6, SubLocationId = 8, CreatedAt = D3, UpdatedAt = D4 },
                new ActivityOccurence { Id = 7, StartTime = new DateTime(2025,10,16,14,0,0, DateTimeKind.Utc), EndTime = new DateTime(2025,10,16,15,30,0, DateTimeKind.Utc), Capacity = 10, AvailableSpots = 10, IsCancelled = false, ActivityId = 7, SubLocationId = 7, CreatedAt = D3, UpdatedAt = D4 },
                new ActivityOccurence { Id = 8, StartTime = new DateTime(2025,10,17,16,0,0, DateTimeKind.Utc), EndTime = new DateTime(2025,10,17,17,15,0, DateTimeKind.Utc), Capacity = 40, AvailableSpots = 40, IsCancelled = false, ActivityId = 8, SubLocationId = 1, CreatedAt = D3, UpdatedAt = D4 },
                new ActivityOccurence { Id = 9, StartTime = new DateTime(2025,10,18,6,0,0, DateTimeKind.Utc), EndTime = new DateTime(2025,10,18,6,40,0, DateTimeKind.Utc), Capacity = 18, AvailableSpots = 18, IsCancelled = false, ActivityId = 9, SubLocationId = 11, CreatedAt = D3, UpdatedAt = D4 },
                new ActivityOccurence { Id = 10, StartTime = new DateTime(2025,10,19,12,0,0, DateTimeKind.Utc), EndTime = new DateTime(2025,10,19,13,0,0, DateTimeKind.Utc), Capacity = 16, AvailableSpots = 16, IsCancelled = false, ActivityId = 10, SubLocationId = 10, CreatedAt = D3, UpdatedAt = D4 },
                new ActivityOccurence { Id = 11, StartTime = new DateTime(2025,10,20,18,0,0, DateTimeKind.Utc), EndTime = new DateTime(2025,10,20,19,0,0, DateTimeKind.Utc), Capacity = 20, AvailableSpots = 20, IsCancelled = false, ActivityId = 11, SubLocationId = 12, CreatedAt = D3, UpdatedAt = D4 },
                new ActivityOccurence { Id = 12, StartTime = new DateTime(2025,10,21,8,0,0, DateTimeKind.Utc), EndTime = new DateTime(2025,10,21,9,0,0, DateTimeKind.Utc), Capacity = 24, AvailableSpots = 24, IsCancelled = false, ActivityId = 12, SubLocationId = 8, CreatedAt = D3, UpdatedAt = D4 },
                new ActivityOccurence { Id = 13, StartTime = new DateTime(2025,10,22,15,0,0, DateTimeKind.Utc), EndTime = new DateTime(2025,10,22,16,0,0, DateTimeKind.Utc), Capacity = 30, AvailableSpots = 30, IsCancelled = false, ActivityId = 13, SubLocationId = 13, CreatedAt = D3, UpdatedAt = D4 },
                new ActivityOccurence { Id = 14, StartTime = new DateTime(2025,10,23,17,0,0, DateTimeKind.Utc), EndTime = new DateTime(2025,10,23,17,30,0, DateTimeKind.Utc), Capacity = 14, AvailableSpots = 14, IsCancelled = false, ActivityId = 14, SubLocationId = 14, CreatedAt = D3, UpdatedAt = D4 },
                new ActivityOccurence { Id = 15, StartTime = new DateTime(2025,10,24,10,0,0, DateTimeKind.Utc), EndTime = new DateTime(2025,10,24,11,0,0, DateTimeKind.Utc), Capacity = 28, AvailableSpots = 28, IsCancelled = false, ActivityId = 15, SubLocationId = 15, CreatedAt = D3, UpdatedAt = D4 },
                new ActivityOccurence { Id = 16, StartTime = new DateTime(2025,10,25,13,0,0, DateTimeKind.Utc), EndTime = new DateTime(2025,10,25,14,0,0, DateTimeKind.Utc), Capacity = 12, AvailableSpots = 12, IsCancelled = false, ActivityId = 16, SubLocationId = 16, CreatedAt = D3, UpdatedAt = D4 },
                new ActivityOccurence { Id = 17, StartTime = new DateTime(2025,10,26,9,0,0, DateTimeKind.Utc), EndTime = new DateTime(2025,10,26,14,0,0, DateTimeKind.Utc), Capacity = 40, AvailableSpots = 40, IsCancelled = false, ActivityId = 17, SubLocationId = 19, CreatedAt = D3, UpdatedAt = D4 },
                new ActivityOccurence { Id = 18, StartTime = new DateTime(2025,10,27,11,0,0, DateTimeKind.Utc), EndTime = new DateTime(2025,10,27,11,40,0, DateTimeKind.Utc), Capacity = 18, AvailableSpots = 18, IsCancelled = false, ActivityId = 18, SubLocationId = 17, CreatedAt = D3, UpdatedAt = D4 },
                new ActivityOccurence { Id = 19, StartTime = new DateTime(2025,10,28,16,0,0, DateTimeKind.Utc), EndTime = new DateTime(2025,10,28,17,30,0, DateTimeKind.Utc), Capacity = 35, AvailableSpots = 35, IsCancelled = false, ActivityId = 19, SubLocationId = 18, CreatedAt = D3, UpdatedAt = D4 },
                new ActivityOccurence { Id = 20, StartTime = new DateTime(2025,10,29,10,0,0, DateTimeKind.Utc), EndTime = new DateTime(2025,10,29,10,45,0, DateTimeKind.Utc), Capacity = 16, AvailableSpots = 16, IsCancelled = false, ActivityId = 20, SubLocationId = 20, CreatedAt = D3, UpdatedAt = D4 }
            };
            }



        public static List<Booking> GetBookings()
            {
                // Booking.UserId is string (Identity). Values match GetUsers() IDs.
                return new List<Booking>
            {
                new Booking { Id = 1, UserId = "b1f4f730-0001-4a1a-8000-000000000001", ActivityOccurenceId = 1, CreatedAt = D3, UpdatedAt = D4, ParticipationConfirmed = true, Participants = 1, IsActive = true, IsPaid = true, IsCancelled = false },
                new Booking { Id = 2, UserId = "b1f4f730-0002-4a1a-8000-000000000002", ActivityOccurenceId = 2, CreatedAt = D3, UpdatedAt = D4, ParticipationConfirmed = false, Participants = 2, IsActive = true, IsPaid = false, IsCancelled = false },
                new Booking { Id = 3, UserId = "b1f4f730-0003-4a1a-8000-000000000003", ActivityOccurenceId = 3, CreatedAt = D3, UpdatedAt = D4, ParticipationConfirmed = true, Participants = 1, IsActive = true, IsPaid = true, IsCancelled = false },
                new Booking { Id = 4, UserId = "b1f4f730-0004-4a1a-8000-000000000004", ActivityOccurenceId = 4, CreatedAt = D3, UpdatedAt = D4, ParticipationConfirmed = false, Participants = 3, IsActive = true, IsPaid = false, IsCancelled = false },
                new Booking { Id = 5, UserId = "b1f4f730-0005-4a1a-8000-000000000005", ActivityOccurenceId = 5, CreatedAt = D3, UpdatedAt = D4, ParticipationConfirmed = true, Participants = 1, IsActive = true, IsPaid = true, IsCancelled = false },
                new Booking { Id = 6, UserId = "b1f4f730-0006-4a1a-8000-000000000006", ActivityOccurenceId = 6, CreatedAt = D3, UpdatedAt = D4, ParticipationConfirmed = true, Participants = 2, IsActive = true, IsPaid = true, IsCancelled = false },
                new Booking { Id = 7, UserId = "b1f4f730-0007-4a1a-8000-000000000007", ActivityOccurenceId = 7, CreatedAt = D3, UpdatedAt = D4, ParticipationConfirmed = false, Participants = 1, IsActive = true, IsPaid = false, IsCancelled = false },
                new Booking { Id = 8, UserId = "b1f4f730-0008-4a1a-8000-000000000008", ActivityOccurenceId = 8, CreatedAt = D3, UpdatedAt = D4, ParticipationConfirmed = true, Participants = 4, IsActive = true, IsPaid = true, IsCancelled = false },
                new Booking { Id = 9, UserId = "b1f4f730-0009-4a1a-8000-000000000009", ActivityOccurenceId = 9, CreatedAt = D3, UpdatedAt = D4, ParticipationConfirmed = false, Participants = 2, IsActive = true, IsPaid = false, IsCancelled = false },
                new Booking { Id = 10, UserId = "b1f4f730-000a-4a1a-8000-00000000000a", ActivityOccurenceId = 10, CreatedAt = D3, UpdatedAt = D4, ParticipationConfirmed = true, Participants = 1, IsActive = true, IsPaid = true, IsCancelled = false },
                new Booking { Id = 11, UserId = "b1f4f730-000b-4a1a-8000-00000000000b", ActivityOccurenceId = 11, CreatedAt = D3, UpdatedAt = D4, ParticipationConfirmed = true, Participants = 2, IsActive = true, IsPaid = true, IsCancelled = false },
                new Booking { Id = 12, UserId = "b1f4f730-000c-4a1a-8000-00000000000c", ActivityOccurenceId = 12, CreatedAt = D3, UpdatedAt = D4, ParticipationConfirmed = false, Participants = 3, IsActive = true, IsPaid = false, IsCancelled = false },
                new Booking { Id = 13, UserId = "b1f4f730-000d-4a1a-8000-00000000000d", ActivityOccurenceId = 13, CreatedAt = D3, UpdatedAt = D4, ParticipationConfirmed = true, Participants = 1, IsActive = true, IsPaid = true, IsCancelled = false },
                new Booking { Id = 14, UserId = "b1f4f730-000e-4a1a-8000-00000000000e", ActivityOccurenceId = 14, CreatedAt = D3, UpdatedAt = D4, ParticipationConfirmed = false, Participants = 2, IsActive = true, IsPaid = false, IsCancelled = false },
                new Booking { Id = 15, UserId = "b1f4f730-000f-4a1a-8000-00000000000f", ActivityOccurenceId = 15, CreatedAt = D3, UpdatedAt = D4, ParticipationConfirmed = true, Participants = 3, IsActive = true, IsPaid = true, IsCancelled = false },
                new Booking { Id = 16, UserId = "b1f4f730-0010-4a1a-8000-000000000010", ActivityOccurenceId = 16, CreatedAt = D3, UpdatedAt = D4, ParticipationConfirmed = true, Participants = 1, IsActive = true, IsPaid = true, IsCancelled = false },
                new Booking { Id = 17, UserId = "b1f4f730-0011-4a1a-8000-000000000011", ActivityOccurenceId = 17, CreatedAt = D3, UpdatedAt = D4, ParticipationConfirmed = false, Participants = 5, IsActive = true, IsPaid = false, IsCancelled = false },
                new Booking { Id = 18, UserId = "b1f4f730-0012-4a1a-8000-000000000012", ActivityOccurenceId = 18, CreatedAt = D3, UpdatedAt = D4, ParticipationConfirmed = true, Participants = 1, IsActive = true, IsPaid = true, IsCancelled = false },
                new Booking { Id = 19, UserId = "b1f4f730-0013-4a1a-8000-000000000013", ActivityOccurenceId = 19, CreatedAt = D3, UpdatedAt = D4, ParticipationConfirmed = true, Participants = 2, IsActive = true, IsPaid = true, IsCancelled = false },
                new Booking { Id = 20, UserId = "b1f4f730-0014-4a1a-8000-000000000014", ActivityOccurenceId = 20, CreatedAt = D3, UpdatedAt = D4, ParticipationConfirmed = false, Participants = 1, IsActive = true, IsPaid = false, IsCancelled = false }
            };
            }
        }
}

