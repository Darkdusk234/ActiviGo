using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ActiviGoApi.Infrastructur.Migrations
{
    /// <inheritdoc />
    public partial class identitydbadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Users_UserId",
                table: "Bookings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "b1f4f730-0001-4a1a-8000-000000000001");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "b1f4f730-0002-4a1a-8000-000000000002");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "b1f4f730-0003-4a1a-8000-000000000003");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "b1f4f730-0004-4a1a-8000-000000000004");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "b1f4f730-0005-4a1a-8000-000000000005");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "b1f4f730-0006-4a1a-8000-000000000006");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "b1f4f730-0007-4a1a-8000-000000000007");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "b1f4f730-0008-4a1a-8000-000000000008");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "b1f4f730-0009-4a1a-8000-000000000009");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "b1f4f730-000a-4a1a-8000-00000000000a");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "b1f4f730-000b-4a1a-8000-00000000000b");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "b1f4f730-000c-4a1a-8000-00000000000c");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "b1f4f730-000d-4a1a-8000-00000000000d");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "b1f4f730-000e-4a1a-8000-00000000000e");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "b1f4f730-000f-4a1a-8000-00000000000f");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "b1f4f730-0010-4a1a-8000-000000000010");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "b1f4f730-0011-4a1a-8000-000000000011");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "b1f4f730-0012-4a1a-8000-000000000012");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "b1f4f730-0013-4a1a-8000-000000000013");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "b1f4f730-0014-4a1a-8000-000000000014");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NormalizedUserName",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NormalizedEmail",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<bool>(
                name: "IsSuspended",
                table: "AspNetUsers",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUsers",
                table: "AspNetUsers",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "DateOfBirth", "Discriminator", "Email", "EmailConfirmed", "FirstName", "IsSuspended", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "b1f4f730-0001-4a1a-8000-000000000001", 0, "1 Park Lane", "e09dc3de-0b2e-4fbb-9a8e-609624315abc", new DateTime(1990, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "User", "alice@example.com", true, "Alice", false, "Andersson", false, null, "ALICE@EXAMPLE.COM", "ALICE@EXAMPLE.COM", null, null, false, "8493c572-aa92-4148-b202-1e6a784c1030", false, "alice@example.com" },
                    { "b1f4f730-0002-4a1a-8000-000000000002", 0, "2 River Rd", "2aea41b2-796d-43e7-9e27-cefd7fcd206e", new DateTime(1985, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "User", "bob@example.com", true, "Bob", false, "Brown", false, null, "BOB@EXAMPLE.COM", "BOB@EXAMPLE.COM", null, null, false, "9ff4ef8c-35a0-4e72-a120-3764fbdd635c", false, "bob@example.com" },
                    { "b1f4f730-0003-4a1a-8000-000000000003", 0, "3 Harbor St", "534f0c0c-2bec-43df-aaba-5c95fee8e185", new DateTime(1992, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "User", "carol@example.com", true, "Carol", false, "Carlson", false, null, "CAROL@EXAMPLE.COM", "CAROL@EXAMPLE.COM", null, null, false, "51434507-6935-4f60-ae95-961083c4f05c", false, "carol@example.com" },
                    { "b1f4f730-0004-4a1a-8000-000000000004", 0, "4 North Ave", "639f074d-5b53-4bbf-b3ce-02362b0d6f67", new DateTime(1988, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "User", "dan@example.com", true, "Dan", false, "Davis", false, null, "DAN@EXAMPLE.COM", "DAN@EXAMPLE.COM", null, null, false, "2697558c-aecb-4345-aa32-9d7a6bbf15db", false, "dan@example.com" },
                    { "b1f4f730-0005-4a1a-8000-000000000005", 0, "5 South Gate", "5f99d3b2-1383-423f-9189-a3a0d18fa29d", new DateTime(1995, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "User", "eva@example.com", true, "Eva", false, "Eriksson", false, null, "EVA@EXAMPLE.COM", "EVA@EXAMPLE.COM", null, null, false, "68342640-22f4-483e-a0e6-d46eba36232f", false, "eva@example.com" },
                    { "b1f4f730-0006-4a1a-8000-000000000006", 0, "6 East Point", "e5a19cd6-3d62-40c0-9bce-11c4a810f80b", new DateTime(1979, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "User", "fred@example.com", true, "Fred", false, "Fischer", false, null, "FRED@EXAMPLE.COM", "FRED@EXAMPLE.COM", null, null, false, "20322510-1ec5-4252-a346-aed50f194f84", false, "fred@example.com" },
                    { "b1f4f730-0007-4a1a-8000-000000000007", 0, "7 West Field", "bccbc729-c29c-47b8-80df-1f8a675b44f7", new DateTime(1982, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "User", "gina@example.com", true, "Gina", false, "Gustav", false, null, "GINA@EXAMPLE.COM", "GINA@EXAMPLE.COM", null, null, false, "91963162-525a-4447-ba1a-1cec8a70fcee", false, "gina@example.com" },
                    { "b1f4f730-0008-4a1a-8000-000000000008", 0, "8 City Center", "a85e743d-1b3c-473f-95db-cc5bd0159da7", new DateTime(1991, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "User", "harry@example.com", true, "Harry", false, "Hansen", false, null, "HARRY@EXAMPLE.COM", "HARRY@EXAMPLE.COM", null, null, false, "5491511c-803b-4d62-bf8b-63c5fab371b2", false, "harry@example.com" },
                    { "b1f4f730-0009-4a1a-8000-000000000009", 0, "9 Lakeside", "d3a4cca1-82ec-45fc-8b59-606c80df9c8b", new DateTime(1993, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "User", "irene@example.com", true, "Irene", false, "Iverson", false, null, "IRENE@EXAMPLE.COM", "IRENE@EXAMPLE.COM", null, null, false, "1a486407-5e81-4178-a26a-573eb7ec9a60", false, "irene@example.com" },
                    { "b1f4f730-000a-4a1a-8000-00000000000a", 0, "10 Old Town", "e3477505-7cc0-463e-b18a-f40a248085f4", new DateTime(1975, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "User", "john@example.com", true, "John", false, "Johnson", false, null, "JOHN@EXAMPLE.COM", "JOHN@EXAMPLE.COM", null, null, false, "5aca9faf-5d54-4704-971e-0e5dc2ffe55e", false, "john@example.com" },
                    { "b1f4f730-000b-4a1a-8000-00000000000b", 0, "11 Green Meadow", "1ecf606d-87ea-40de-9e8c-c5a1dfa38a0c", new DateTime(1987, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "User", "kate@example.com", true, "Kate", false, "Karlsson", false, null, "KATE@EXAMPLE.COM", "KATE@EXAMPLE.COM", null, null, false, "0a4f0fa6-66b9-40f9-a4da-a37e329238ea", false, "kate@example.com" },
                    { "b1f4f730-000c-4a1a-8000-00000000000c", 0, "12 Highlands", "2acf2451-f46e-4b85-b70b-886efee5fdf9", new DateTime(1996, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "User", "liam@example.com", true, "Liam", false, "Larsson", false, null, "LIAM@EXAMPLE.COM", "LIAM@EXAMPLE.COM", null, null, false, "c6eb000e-3acc-4a3f-8efd-b2ac92233c6d", false, "liam@example.com" },
                    { "b1f4f730-000d-4a1a-8000-00000000000d", 0, "13 Sunset Plaza", "684a41f0-d677-412e-8982-e4cba6f1b0d6", new DateTime(1994, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "User", "mia@example.com", true, "Mia", false, "Mårtensson", false, null, "MIA@EXAMPLE.COM", "MIA@EXAMPLE.COM", null, null, false, "6179677e-5406-4ab3-8a88-c3fe778700f9", false, "mia@example.com" },
                    { "b1f4f730-000e-4a1a-8000-00000000000e", 0, "14 Mountain Base", "60b00bdd-16d5-4d6b-adda-cd0c5c65bc7f", new DateTime(1989, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "User", "noah@example.com", true, "Noah", false, "Nilsen", false, null, "NOAH@EXAMPLE.COM", "NOAH@EXAMPLE.COM", null, null, false, "a8d3bd64-a10c-4929-b971-7381b9ef57ee", false, "noah@example.com" },
                    { "b1f4f730-000f-4a1a-8000-00000000000f", 0, "15 Valley Hub", "029f0fd0-fe78-4930-9b01-c537a149e31b", new DateTime(1978, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "User", "olga@example.com", true, "Olga", false, "Olsen", false, null, "OLGA@EXAMPLE.COM", "OLGA@EXAMPLE.COM", null, null, false, "9d6b380f-cbce-4b83-828c-381a93c0bcff", false, "olga@example.com" },
                    { "b1f4f730-0010-4a1a-8000-000000000010", 0, "16 Seafront", "8df2325e-da06-4a7e-8f3d-fe2cb56a69ac", new DateTime(1984, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "User", "pete@example.com", true, "Pete", false, "Peterson", false, null, "PETE@EXAMPLE.COM", "PETE@EXAMPLE.COM", null, null, false, "cf129d28-2f50-4422-ae46-2f0efb9f6fd6", false, "pete@example.com" },
                    { "b1f4f730-0011-4a1a-8000-000000000011", 0, "17 Meadow Park", "812606da-9b16-468d-9209-45d8e9adc0c8", new DateTime(1999, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "User", "quinn@example.com", true, "Quinn", false, "Qvist", false, null, "QUINN@EXAMPLE.COM", "QUINN@EXAMPLE.COM", null, null, false, "9664b80b-e64a-4e9b-9fb8-e12a5103c831", false, "quinn@example.com" },
                    { "b1f4f730-0012-4a1a-8000-000000000012", 0, "18 Station Square", "fc7f0470-f894-4cdf-9c31-a6630b3efb46", new DateTime(1997, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "User", "rachel@example.com", true, "Rachel", false, "Rosen", false, null, "RACHEL@EXAMPLE.COM", "RACHEL@EXAMPLE.COM", null, null, false, "3342f890-2dd3-42cb-85c4-fb57bd5b40e8", false, "rachel@example.com" },
                    { "b1f4f730-0013-4a1a-8000-000000000013", 0, "19 Festival Grounds", "b87a007d-1f52-4ffe-a6e5-0d84f2003b0a", new DateTime(1990, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "User", "sam@example.com", true, "Sam", false, "Svensson", false, null, "SAM@EXAMPLE.COM", "SAM@EXAMPLE.COM", null, null, false, "119c98be-96b6-4869-8811-3a59bf06ca9c", false, "sam@example.com" },
                    { "b1f4f730-0014-4a1a-8000-000000000014", 0, "20 Civic Plaza", "4e7f1ce8-0ac4-404a-9a24-e77f54cf88b0", new DateTime(1983, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "User", "tina@example.com", true, "Tina", false, "Thompson", false, null, "TINA@EXAMPLE.COM", "TINA@EXAMPLE.COM", null, null, false, "25c68ad5-8e74-409f-9394-3972743a52a4", false, "tina@example.com" }
                });

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_AspNetUsers_UserId",
                table: "Bookings",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_AspNetUsers_UserId",
                table: "Bookings");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUsers",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "EmailIndex",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "UserNameIndex",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "AspNetUsers",
                newName: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NormalizedUserName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NormalizedEmail",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsSuspended",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "b1f4f730-0001-4a1a-8000-000000000001",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "35d2a734-8554-4a11-b949-11c275cd1d0f", "9dc4a4da-1269-4b8a-9753-7d8047fb374d" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "b1f4f730-0002-4a1a-8000-000000000002",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "6de23b99-0302-40b8-8392-66541d3a9bd6", "033af989-1d12-4bdd-ad88-7fc89c59cb20" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "b1f4f730-0003-4a1a-8000-000000000003",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "20e7fb16-7843-4efe-9632-f36847907076", "74812eb0-3854-406d-b00e-ed15192d4f46" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "b1f4f730-0004-4a1a-8000-000000000004",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "9041b7ef-5b75-4a16-b2df-e03545e612d9", "809b4ed9-77c9-401c-b532-4f6ebef2b384" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "b1f4f730-0005-4a1a-8000-000000000005",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "58a1d668-6aee-4bb6-a859-8f08e882ff8e", "b000f285-3b8f-41ac-8a96-5e0af5ccfedb" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "b1f4f730-0006-4a1a-8000-000000000006",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "78131727-b97c-4754-8afc-d4462905d65d", "8fce4dce-8586-4e71-9bb4-e3f65dd6678a" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "b1f4f730-0007-4a1a-8000-000000000007",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "5a20527e-4bb1-4375-8531-bb49084f76a6", "4085c573-3fd9-43b5-8bb6-682236190224" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "b1f4f730-0008-4a1a-8000-000000000008",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "d13b385d-109d-4082-8df9-4ed14347095a", "a54360ef-3afb-4182-ada6-52ea6d03dffc" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "b1f4f730-0009-4a1a-8000-000000000009",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "78a38fb0-9686-45fb-b788-80df4894ead1", "024f1d3b-bed0-4e26-8569-b423ffa9d9d8" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "b1f4f730-000a-4a1a-8000-00000000000a",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "18e4302d-6a7d-4b92-864f-f743994b5e31", "29e885b7-144a-4398-bebc-f4f3e3c9ea26" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "b1f4f730-000b-4a1a-8000-00000000000b",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "f91d75bf-f818-4980-b9e0-0d0aa2aa1b4e", "395fd560-954a-4315-addf-981392092e39" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "b1f4f730-000c-4a1a-8000-00000000000c",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "c46197e0-134b-4a63-969e-0c50d0a4ef5a", "f1f6bcd8-2519-41f5-9657-2b51116d8485" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "b1f4f730-000d-4a1a-8000-00000000000d",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "67cc4b20-3338-4d13-8951-de8aa1be6aa1", "4d55a6f0-a236-4710-a7f3-a4729fca5f7c" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "b1f4f730-000e-4a1a-8000-00000000000e",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "f00d2552-2f4c-48a3-bc2c-0750355176cc", "232dcd15-3026-46fd-9134-df0c6969b308" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "b1f4f730-000f-4a1a-8000-00000000000f",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "535d18ef-61bd-4b0d-a09e-630addf57a83", "5bb75e88-38a5-4eca-9e95-f575829d73a3" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "b1f4f730-0010-4a1a-8000-000000000010",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "0c35b6e2-f66b-4312-952f-00d56c8b3eb0", "a2698a72-7028-47a2-adce-fde0b5f1738e" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "b1f4f730-0011-4a1a-8000-000000000011",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "f64406f6-eef3-4646-a329-87f628e34c21", "c03ba5ab-b0ab-435b-a20f-7d3c48bf6676" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "b1f4f730-0012-4a1a-8000-000000000012",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "62770e6f-5121-448d-8b84-2532783017e0", "2a2e727d-0a20-454a-b31e-379feb283c12" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "b1f4f730-0013-4a1a-8000-000000000013",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "c47a6087-dae4-40ac-9ae7-4131ffe9bd6e", "895a8f78-bea8-4e1d-9785-902adc5e0b1c" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "b1f4f730-0014-4a1a-8000-000000000014",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "8ea4ef0f-0879-4b07-993f-97c7767c43ba", "d1860db8-a592-44a4-87c4-66ea08100ce8" });

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Users_UserId",
                table: "Bookings",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
