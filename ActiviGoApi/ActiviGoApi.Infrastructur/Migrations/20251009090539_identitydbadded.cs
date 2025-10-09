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
