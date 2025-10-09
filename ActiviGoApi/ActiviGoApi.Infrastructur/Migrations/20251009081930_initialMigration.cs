using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ActiviGoApi.Infrastructur.Migrations
{
    /// <inheritdoc />
    public partial class initialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Latitude = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Longitude = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsSuspended = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    DurationInMinutes = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IMGUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Activities_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubLocations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaxCapacity = table.Column<int>(type: "int", nullable: false),
                    Indoors = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubLocations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubLocations_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ActivityOccurences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    AvailableSpots = table.Column<int>(type: "int", nullable: false),
                    IsCancelled = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActivityId = table.Column<int>(type: "int", nullable: false),
                    SubLocationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityOccurences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActivityOccurences_Activities_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "Activities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActivityOccurences_SubLocations_SubLocationId",
                        column: x => x.SubLocationId,
                        principalTable: "SubLocations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ActivitySubLocation",
                columns: table => new
                {
                    ActivitiesId = table.Column<int>(type: "int", nullable: false),
                    SubLocationsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivitySubLocation", x => new { x.ActivitiesId, x.SubLocationsId });
                    table.ForeignKey(
                        name: "FK_ActivitySubLocation_Activities_ActivitiesId",
                        column: x => x.ActivitiesId,
                        principalTable: "Activities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActivitySubLocation_SubLocations_SubLocationsId",
                        column: x => x.SubLocationsId,
                        principalTable: "SubLocations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ActivityOccurenceId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ParticipationConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    Participants = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsPaid = table.Column<bool>(type: "bit", nullable: false),
                    IsCancelled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bookings_ActivityOccurences_ActivityOccurenceId",
                        column: x => x.ActivityOccurenceId,
                        principalTable: "ActivityOccurences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bookings_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "IsSuspended", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "b1f4f730-0001-4a1a-8000-000000000001", 0, "1 Park Lane", "35d2a734-8554-4a11-b949-11c275cd1d0f", new DateTime(1990, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "alice@example.com", true, "Alice", false, "Andersson", false, null, "ALICE@EXAMPLE.COM", "ALICE@EXAMPLE.COM", null, null, false, "9dc4a4da-1269-4b8a-9753-7d8047fb374d", false, "alice@example.com" },
                    { "b1f4f730-0002-4a1a-8000-000000000002", 0, "2 River Rd", "6de23b99-0302-40b8-8392-66541d3a9bd6", new DateTime(1985, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "bob@example.com", true, "Bob", false, "Brown", false, null, "BOB@EXAMPLE.COM", "BOB@EXAMPLE.COM", null, null, false, "033af989-1d12-4bdd-ad88-7fc89c59cb20", false, "bob@example.com" },
                    { "b1f4f730-0003-4a1a-8000-000000000003", 0, "3 Harbor St", "20e7fb16-7843-4efe-9632-f36847907076", new DateTime(1992, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "carol@example.com", true, "Carol", false, "Carlson", false, null, "CAROL@EXAMPLE.COM", "CAROL@EXAMPLE.COM", null, null, false, "74812eb0-3854-406d-b00e-ed15192d4f46", false, "carol@example.com" },
                    { "b1f4f730-0004-4a1a-8000-000000000004", 0, "4 North Ave", "9041b7ef-5b75-4a16-b2df-e03545e612d9", new DateTime(1988, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "dan@example.com", true, "Dan", false, "Davis", false, null, "DAN@EXAMPLE.COM", "DAN@EXAMPLE.COM", null, null, false, "809b4ed9-77c9-401c-b532-4f6ebef2b384", false, "dan@example.com" },
                    { "b1f4f730-0005-4a1a-8000-000000000005", 0, "5 South Gate", "58a1d668-6aee-4bb6-a859-8f08e882ff8e", new DateTime(1995, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "eva@example.com", true, "Eva", false, "Eriksson", false, null, "EVA@EXAMPLE.COM", "EVA@EXAMPLE.COM", null, null, false, "b000f285-3b8f-41ac-8a96-5e0af5ccfedb", false, "eva@example.com" },
                    { "b1f4f730-0006-4a1a-8000-000000000006", 0, "6 East Point", "78131727-b97c-4754-8afc-d4462905d65d", new DateTime(1979, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "fred@example.com", true, "Fred", false, "Fischer", false, null, "FRED@EXAMPLE.COM", "FRED@EXAMPLE.COM", null, null, false, "8fce4dce-8586-4e71-9bb4-e3f65dd6678a", false, "fred@example.com" },
                    { "b1f4f730-0007-4a1a-8000-000000000007", 0, "7 West Field", "5a20527e-4bb1-4375-8531-bb49084f76a6", new DateTime(1982, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "gina@example.com", true, "Gina", false, "Gustav", false, null, "GINA@EXAMPLE.COM", "GINA@EXAMPLE.COM", null, null, false, "4085c573-3fd9-43b5-8bb6-682236190224", false, "gina@example.com" },
                    { "b1f4f730-0008-4a1a-8000-000000000008", 0, "8 City Center", "d13b385d-109d-4082-8df9-4ed14347095a", new DateTime(1991, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "harry@example.com", true, "Harry", false, "Hansen", false, null, "HARRY@EXAMPLE.COM", "HARRY@EXAMPLE.COM", null, null, false, "a54360ef-3afb-4182-ada6-52ea6d03dffc", false, "harry@example.com" },
                    { "b1f4f730-0009-4a1a-8000-000000000009", 0, "9 Lakeside", "78a38fb0-9686-45fb-b788-80df4894ead1", new DateTime(1993, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "irene@example.com", true, "Irene", false, "Iverson", false, null, "IRENE@EXAMPLE.COM", "IRENE@EXAMPLE.COM", null, null, false, "024f1d3b-bed0-4e26-8569-b423ffa9d9d8", false, "irene@example.com" },
                    { "b1f4f730-000a-4a1a-8000-00000000000a", 0, "10 Old Town", "18e4302d-6a7d-4b92-864f-f743994b5e31", new DateTime(1975, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "john@example.com", true, "John", false, "Johnson", false, null, "JOHN@EXAMPLE.COM", "JOHN@EXAMPLE.COM", null, null, false, "29e885b7-144a-4398-bebc-f4f3e3c9ea26", false, "john@example.com" },
                    { "b1f4f730-000b-4a1a-8000-00000000000b", 0, "11 Green Meadow", "f91d75bf-f818-4980-b9e0-0d0aa2aa1b4e", new DateTime(1987, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "kate@example.com", true, "Kate", false, "Karlsson", false, null, "KATE@EXAMPLE.COM", "KATE@EXAMPLE.COM", null, null, false, "395fd560-954a-4315-addf-981392092e39", false, "kate@example.com" },
                    { "b1f4f730-000c-4a1a-8000-00000000000c", 0, "12 Highlands", "c46197e0-134b-4a63-969e-0c50d0a4ef5a", new DateTime(1996, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "liam@example.com", true, "Liam", false, "Larsson", false, null, "LIAM@EXAMPLE.COM", "LIAM@EXAMPLE.COM", null, null, false, "f1f6bcd8-2519-41f5-9657-2b51116d8485", false, "liam@example.com" },
                    { "b1f4f730-000d-4a1a-8000-00000000000d", 0, "13 Sunset Plaza", "67cc4b20-3338-4d13-8951-de8aa1be6aa1", new DateTime(1994, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "mia@example.com", true, "Mia", false, "Mårtensson", false, null, "MIA@EXAMPLE.COM", "MIA@EXAMPLE.COM", null, null, false, "4d55a6f0-a236-4710-a7f3-a4729fca5f7c", false, "mia@example.com" },
                    { "b1f4f730-000e-4a1a-8000-00000000000e", 0, "14 Mountain Base", "f00d2552-2f4c-48a3-bc2c-0750355176cc", new DateTime(1989, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "noah@example.com", true, "Noah", false, "Nilsen", false, null, "NOAH@EXAMPLE.COM", "NOAH@EXAMPLE.COM", null, null, false, "232dcd15-3026-46fd-9134-df0c6969b308", false, "noah@example.com" },
                    { "b1f4f730-000f-4a1a-8000-00000000000f", 0, "15 Valley Hub", "535d18ef-61bd-4b0d-a09e-630addf57a83", new DateTime(1978, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "olga@example.com", true, "Olga", false, "Olsen", false, null, "OLGA@EXAMPLE.COM", "OLGA@EXAMPLE.COM", null, null, false, "5bb75e88-38a5-4eca-9e95-f575829d73a3", false, "olga@example.com" },
                    { "b1f4f730-0010-4a1a-8000-000000000010", 0, "16 Seafront", "0c35b6e2-f66b-4312-952f-00d56c8b3eb0", new DateTime(1984, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "pete@example.com", true, "Pete", false, "Peterson", false, null, "PETE@EXAMPLE.COM", "PETE@EXAMPLE.COM", null, null, false, "a2698a72-7028-47a2-adce-fde0b5f1738e", false, "pete@example.com" },
                    { "b1f4f730-0011-4a1a-8000-000000000011", 0, "17 Meadow Park", "f64406f6-eef3-4646-a329-87f628e34c21", new DateTime(1999, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "quinn@example.com", true, "Quinn", false, "Qvist", false, null, "QUINN@EXAMPLE.COM", "QUINN@EXAMPLE.COM", null, null, false, "c03ba5ab-b0ab-435b-a20f-7d3c48bf6676", false, "quinn@example.com" },
                    { "b1f4f730-0012-4a1a-8000-000000000012", 0, "18 Station Square", "62770e6f-5121-448d-8b84-2532783017e0", new DateTime(1997, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "rachel@example.com", true, "Rachel", false, "Rosen", false, null, "RACHEL@EXAMPLE.COM", "RACHEL@EXAMPLE.COM", null, null, false, "2a2e727d-0a20-454a-b31e-379feb283c12", false, "rachel@example.com" },
                    { "b1f4f730-0013-4a1a-8000-000000000013", 0, "19 Festival Grounds", "c47a6087-dae4-40ac-9ae7-4131ffe9bd6e", new DateTime(1990, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "sam@example.com", true, "Sam", false, "Svensson", false, null, "SAM@EXAMPLE.COM", "SAM@EXAMPLE.COM", null, null, false, "895a8f78-bea8-4e1d-9785-902adc5e0b1c", false, "sam@example.com" },
                    { "b1f4f730-0014-4a1a-8000-000000000014", 0, "20 Civic Plaza", "8ea4ef0f-0879-4b07-993f-97c7767c43ba", new DateTime(1983, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "tina@example.com", true, "Tina", false, "Thompson", false, null, "TINA@EXAMPLE.COM", "TINA@EXAMPLE.COM", null, null, false, "d1860db8-a592-44a4-87c4-66ea08100ce8", false, "tina@example.com" }
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

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "ActivityOccurenceId", "CreatedAt", "IsActive", "IsCancelled", "IsPaid", "Participants", "ParticipationConfirmed", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, false, true, 1, true, new DateTime(2025, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), "b1f4f730-0001-4a1a-8000-000000000001" },
                    { 2, 2, new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, false, false, 2, false, new DateTime(2025, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), "b1f4f730-0002-4a1a-8000-000000000002" },
                    { 3, 3, new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, false, true, 1, true, new DateTime(2025, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), "b1f4f730-0003-4a1a-8000-000000000003" },
                    { 4, 4, new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, false, false, 3, false, new DateTime(2025, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), "b1f4f730-0004-4a1a-8000-000000000004" },
                    { 5, 5, new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, false, true, 1, true, new DateTime(2025, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), "b1f4f730-0005-4a1a-8000-000000000005" },
                    { 6, 6, new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, false, true, 2, true, new DateTime(2025, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), "b1f4f730-0006-4a1a-8000-000000000006" },
                    { 7, 7, new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, false, false, 1, false, new DateTime(2025, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), "b1f4f730-0007-4a1a-8000-000000000007" },
                    { 8, 8, new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, false, true, 4, true, new DateTime(2025, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), "b1f4f730-0008-4a1a-8000-000000000008" },
                    { 9, 9, new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, false, false, 2, false, new DateTime(2025, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), "b1f4f730-0009-4a1a-8000-000000000009" },
                    { 10, 10, new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, false, true, 1, true, new DateTime(2025, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), "b1f4f730-000a-4a1a-8000-00000000000a" },
                    { 11, 11, new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, false, true, 2, true, new DateTime(2025, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), "b1f4f730-000b-4a1a-8000-00000000000b" },
                    { 12, 12, new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, false, false, 3, false, new DateTime(2025, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), "b1f4f730-000c-4a1a-8000-00000000000c" },
                    { 13, 13, new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, false, true, 1, true, new DateTime(2025, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), "b1f4f730-000d-4a1a-8000-00000000000d" },
                    { 14, 14, new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, false, false, 2, false, new DateTime(2025, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), "b1f4f730-000e-4a1a-8000-00000000000e" },
                    { 15, 15, new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, false, true, 3, true, new DateTime(2025, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), "b1f4f730-000f-4a1a-8000-00000000000f" },
                    { 16, 16, new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, false, true, 1, true, new DateTime(2025, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), "b1f4f730-0010-4a1a-8000-000000000010" },
                    { 17, 17, new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, false, false, 5, false, new DateTime(2025, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), "b1f4f730-0011-4a1a-8000-000000000011" },
                    { 18, 18, new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, false, true, 1, true, new DateTime(2025, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), "b1f4f730-0012-4a1a-8000-000000000012" },
                    { 19, 19, new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, false, true, 2, true, new DateTime(2025, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), "b1f4f730-0013-4a1a-8000-000000000013" },
                    { 20, 20, new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, false, false, 1, false, new DateTime(2025, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), "b1f4f730-0014-4a1a-8000-000000000014" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activities_CategoryId",
                table: "Activities",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityOccurences_ActivityId",
                table: "ActivityOccurences",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityOccurences_SubLocationId",
                table: "ActivityOccurences",
                column: "SubLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivitySubLocation_SubLocationsId",
                table: "ActivitySubLocation",
                column: "SubLocationsId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_ActivityOccurenceId",
                table: "Bookings",
                column: "ActivityOccurenceId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_UserId",
                table: "Bookings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SubLocations_LocationId",
                table: "SubLocations",
                column: "LocationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActivitySubLocation");

            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "ActivityOccurences");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.DropTable(
                name: "SubLocations");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Locations");
        }
    }
}
