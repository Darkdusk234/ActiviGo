using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ActiviGoApi.Infrastructur.Migrations
{
    /// <inheritdoc />
    public partial class moreSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "Description", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Strength and conditioning classes", "Fitness", new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 2, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mindfulness and flexibility sessions", "Yoga", new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 3, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Various dance styles and choreography", "Dance", new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 4, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Combat sports and self-defense", "Martial Arts", new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 5, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Pool-based training and technique", "Swimming", new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 6, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Indoor cycling classes and outdoor rides", "Cycling", new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 7, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Bouldering and rope climbing instruction", "Climbing", new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 8, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Organized team training (soccer, basketball)", "Team Sports", new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 9, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Technique, intervals and endurance runs", "Running", new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 10, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Core and posture improvement", "Pilates", new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 11, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Pad work, sparring and conditioning", "Boxing", new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 12, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "High-intensity functional training", "CrossFit", new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 13, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Floor, rings, bars and flexibility", "Gymnastics", new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 14, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Indoor rowing technique and workouts", "Rowing", new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 15, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Off-season training and technique", "Skiing", new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 16, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Archery and target practice sessions", "Shooting", new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 17, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Hiking, trekking and outdoor skills", "Outdoor", new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 18, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Recovery, mobility and guided relaxation", "Wellness", new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 19, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Child-focused activities and classes", "Kids", new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 20, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Low-impact sessions for older adults", "Senior", new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc) }
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Adress", "CreatedAt", "Description", "IsActive", "Latitude", "Longitude", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "1 Central Park Way", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Large public park with open fields", true, "40.785091", "-73.968285", "Central Park", new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 2, "2 Riverside Ave", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Riverside recreational area", true, "40.800000", "-73.970000", "Riverside Grounds", new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 3, "3 Harbor Rd", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Coastal facility with views of the harbor", true, "40.700000", "-74.010000", "Harbor View", new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 4, "4 North End Ln", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Community sports complex", true, "40.820000", "-73.950000", "North End Complex", new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 5, "5 South Gate Blvd", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Southern parkland with trails", true, "40.760000", "-73.980000", "South Gate Park", new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 6, "6 East Point St", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "East-side activity center", true, "40.770000", "-73.930000", "East Point Center", new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 7, "7 West Field Dr", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Outdoor fields and courts", true, "40.740000", "-73.990000", "West Field Grounds", new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 8, "8 City Center Pl", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Indoor arena in city center", true, "40.712776", "-74.005974", "City Center Arena", new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 9, "9 Lakeside Rd", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Venue by the lake", true, "40.750000", "-74.000000", "Lakeside Venue", new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 10, "10 Old Town Sq", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Converted town hall used for activities", true, "40.730610", "-73.935242", "Old Town Hall", new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 11, "11 Meadow Ln", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Meadow with event lawns", true, "40.760500", "-73.982000", "Green Meadow", new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 12, "12 Highlands Ave", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Highland area with courts and gym", true, "40.780000", "-73.960000", "Highlands Sports", new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 13, "13 Sunset Blvd", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Plaza suitable for classes and markets", true, "40.710000", "-74.015000", "Sunset Plaza", new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 14, "14 Mountain Rd", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Base facility near small hills", true, "40.850000", "-73.880000", "Mountain Base", new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 15, "15 Valley St", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Community hub in the valley", true, "40.690000", "-74.020000", "Valley Hub", new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 16, "16 Seafront Ave", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Seafront with promenade", true, "40.700500", "-74.012000", "Seafront Deck", new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 17, "17 Meadow Park Ln", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Small park with playground", true, "40.755000", "-73.987000", "Meadow Park", new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 18, "18 Station Sq", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Square adjacent to main station", true, "40.752726", "-73.977229", "Station Square", new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 19, "19 Festival Grounds", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Large open area used for events", true, "40.748000", "-73.985500", "Festival Grounds", new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 20, "20 Civic Plaza", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Plaza in front of civic buildings", true, "40.741000", "-73.989000", "Civic Plaza", new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc) }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "Description", "DurationInMinutes", "IMGUrl", "IsActive", "Name", "Price", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Intense full-body workout to start your day", 45, "https://cdn.example.com/act1.jpg", true, "Morning Bootcamp", 12.50m, new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 2, 2, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Gentle Vinyasa to wake the body", 60, "https://cdn.example.com/act2.jpg", true, "Sunrise Yoga", 10.00m, new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 3, 3, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Urban choreography for all levels", 50, "https://cdn.example.com/act3.jpg", true, "Hip Hop Dance", 11.00m, new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 4, 4, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Intro to basic strikes and stances", 60, "https://cdn.example.com/act4.jpg", true, "Beginner Karate", 15.00m, new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 5, 5, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Technique and endurance laps", 30, "https://cdn.example.com/act5.jpg", true, "Lap Swimming", 8.00m, new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 6, 6, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "High-energy indoor cycling", 45, "https://cdn.example.com/act6.jpg", true, "Spin Class", 13.00m, new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 7, 7, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Belay and lead techniques", 90, "https://cdn.example.com/act7.jpg", true, "Top Rope Climbing", 20.00m, new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 8, 8, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Skill drills and small-sided games", 75, "https://cdn.example.com/act8.jpg", true, "Soccer Practice", 9.50m, new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 9, 9, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Speed intervals on the track", 40, "https://cdn.example.com/act9.jpg", true, "Interval Running", 7.00m, new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 10, 10, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Core stability and breath work", 50, "https://cdn.example.com/act10.jpg", true, "Pilates Mat", 11.50m, new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 11, 11, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Footwork, guard and combos", 55, "https://cdn.example.com/act11.jpg", true, "Boxing Basics", 14.00m, new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 12, 12, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Scaled CrossFit workout of the day", 60, "https://cdn.example.com/act12.jpg", true, "WOD - Beginner", 16.00m, new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 13, 19, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Basic gymnastics for children", 45, "https://cdn.example.com/act13.jpg", true, "Kids Gym", 8.50m, new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 14, 14, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Technique and endurance on erg", 30, "https://cdn.example.com/act14.jpg", true, "Indoor Rowing", 9.00m, new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 15, 15, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Strength for off-road skiing and trekking", 60, "https://cdn.example.com/act15.jpg", true, "Trail Prep", 10.00m, new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 16, 16, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Introduction to recurve bow handling", 60, "https://cdn.example.com/act16.jpg", true, "Archery Basics", 18.00m, new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 17, 17, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Guided day hikes for mixed groups", 300, "https://cdn.example.com/act17.jpg", true, "Hiking Meetup", 25.00m, new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 18, 18, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Joint health and functional movement", 40, "https://cdn.example.com/act18.jpg", true, "Mobility Class", 9.00m, new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 19, 13, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Apparatus and tumbling skills", 90, "https://cdn.example.com/act19.jpg", true, "Advanced Gymnastics", 22.00m, new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 20, 20, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Low impact balance and coordination", 45, "https://cdn.example.com/act20.jpg", true, "Senior Balance", 7.50m, new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc) }
                });

            migrationBuilder.InsertData(
                table: "SubLocations",
                columns: new[] { "Id", "CreatedAt", "Description", "Indoors", "LocationId", "MaxCapacity", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Main arena at Central Park", false, 1, 200, "Arena A1", new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 2, new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Riverside multipurpose court", false, 2, 60, "Court R2", new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 3, new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Indoor gym at Harbor View", true, 3, 80, "Harbor Gym", new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 4, new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Large indoor hall for events", true, 4, 150, "North Hall", new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 5, new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Outdoor field for sports", false, 5, 120, "South Field", new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 6, new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Small studio for classes", true, 6, 20, "East Studio", new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 7, new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), "West Field indoor court 1", true, 7, 60, "West Court 1", new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 8, new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Indoor arena for tournaments", true, 8, 500, "City Arena", new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 9, new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Open deck near lake", false, 9, 50, "Lakeside Deck", new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 10, new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Community studio in Old Town Hall", true, 10, 30, "Old Hall Studio", new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 11, new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Seasonal arena on the meadow", false, 11, 220, "Green Meadow Arena", new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 12, new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Outdoor courts at Highlands", false, 12, 80, "Highlands Court", new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 13, new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Open stage for classes and events", false, 13, 100, "Sunset Plaza Stage", new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 14, new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Training gym at Mountain Base", true, 14, 60, "Mountain Gym", new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 15, new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Community hall in Valley Hub", true, 15, 140, "Valley Hall", new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 16, new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Outdoor seafront court", false, 16, 70, "Seafront Court", new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 17, new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Small studio by the meadow", true, 17, 25, "Meadow Studio", new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 18, new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Arena adjacent to station", false, 18, 180, "Station Square Arena", new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 19, new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Big open festival field", false, 19, 1000, "Festival Field", new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 20, new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Gym inside civic plaza building", true, 20, 90, "Civic Gym", new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc) }
                });

            migrationBuilder.InsertData(
                table: "ActivityOccurences",
                columns: new[] { "Id", "ActivityId", "AvailableSpots", "Capacity", "CreatedAt", "EndTime", "IsCancelled", "StartTime", "SubLocationId", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 1, 20, 20, new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 10, 10, 9, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(2025, 10, 10, 8, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2025, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 2, 2, 15, 15, new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 10, 11, 7, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(2025, 10, 11, 6, 0, 0, 0, DateTimeKind.Utc), 6, new DateTime(2025, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 3, 3, 25, 25, new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 10, 12, 19, 30, 0, 0, DateTimeKind.Utc), false, new DateTime(2025, 10, 12, 18, 0, 0, 0, DateTimeKind.Utc), 3, new DateTime(2025, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 4, 4, 30, 30, new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 10, 13, 18, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(2025, 10, 13, 17, 0, 0, 0, DateTimeKind.Utc), 4, new DateTime(2025, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 5, 5, 12, 12, new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 10, 14, 7, 30, 0, 0, DateTimeKind.Utc), false, new DateTime(2025, 10, 14, 7, 0, 0, 0, DateTimeKind.Utc), 5, new DateTime(2025, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 6, 6, 22, 22, new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 10, 15, 20, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(2025, 10, 15, 19, 0, 0, 0, DateTimeKind.Utc), 8, new DateTime(2025, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 7, 7, 10, 10, new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 10, 16, 15, 30, 0, 0, DateTimeKind.Utc), false, new DateTime(2025, 10, 16, 14, 0, 0, 0, DateTimeKind.Utc), 7, new DateTime(2025, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 8, 8, 40, 40, new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 10, 17, 17, 15, 0, 0, DateTimeKind.Utc), false, new DateTime(2025, 10, 17, 16, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2025, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 9, 9, 18, 18, new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 10, 18, 6, 40, 0, 0, DateTimeKind.Utc), false, new DateTime(2025, 10, 18, 6, 0, 0, 0, DateTimeKind.Utc), 11, new DateTime(2025, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 10, 10, 16, 16, new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 10, 19, 13, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(2025, 10, 19, 12, 0, 0, 0, DateTimeKind.Utc), 10, new DateTime(2025, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 11, 11, 20, 20, new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 10, 20, 19, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(2025, 10, 20, 18, 0, 0, 0, DateTimeKind.Utc), 12, new DateTime(2025, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 12, 12, 24, 24, new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 10, 21, 9, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(2025, 10, 21, 8, 0, 0, 0, DateTimeKind.Utc), 8, new DateTime(2025, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 13, 13, 30, 30, new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 10, 22, 16, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(2025, 10, 22, 15, 0, 0, 0, DateTimeKind.Utc), 13, new DateTime(2025, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 14, 14, 14, 14, new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 10, 23, 17, 30, 0, 0, DateTimeKind.Utc), false, new DateTime(2025, 10, 23, 17, 0, 0, 0, DateTimeKind.Utc), 14, new DateTime(2025, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 15, 15, 28, 28, new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 10, 24, 11, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(2025, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc), 15, new DateTime(2025, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 16, 16, 12, 12, new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 10, 25, 14, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(2025, 10, 25, 13, 0, 0, 0, DateTimeKind.Utc), 16, new DateTime(2025, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 17, 17, 40, 40, new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 10, 26, 14, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(2025, 10, 26, 9, 0, 0, 0, DateTimeKind.Utc), 19, new DateTime(2025, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 18, 18, 18, 18, new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 10, 27, 11, 40, 0, 0, DateTimeKind.Utc), false, new DateTime(2025, 10, 27, 11, 0, 0, 0, DateTimeKind.Utc), 17, new DateTime(2025, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 19, 19, 35, 35, new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 10, 28, 17, 30, 0, 0, DateTimeKind.Utc), false, new DateTime(2025, 10, 28, 16, 0, 0, 0, DateTimeKind.Utc), 18, new DateTime(2025, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 20, 20, 16, 16, new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 10, 29, 10, 45, 0, 0, DateTimeKind.Utc), false, new DateTime(2025, 10, 29, 10, 0, 0, 0, DateTimeKind.Utc), 20, new DateTime(2025, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ActivityOccurences",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ActivityOccurences",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ActivityOccurences",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ActivityOccurences",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ActivityOccurences",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ActivityOccurences",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ActivityOccurences",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ActivityOccurences",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ActivityOccurences",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ActivityOccurences",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "ActivityOccurences",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "ActivityOccurences",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "ActivityOccurences",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "ActivityOccurences",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "ActivityOccurences",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "ActivityOccurences",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "ActivityOccurences",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "ActivityOccurences",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "ActivityOccurences",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "ActivityOccurences",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "SubLocations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SubLocations",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "SubLocations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SubLocations",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "SubLocations",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "SubLocations",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "SubLocations",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "SubLocations",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "SubLocations",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "SubLocations",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "SubLocations",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "SubLocations",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "SubLocations",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "SubLocations",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "SubLocations",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "SubLocations",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "SubLocations",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "SubLocations",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "SubLocations",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "SubLocations",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 20);
        }
    }
}
