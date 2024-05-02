using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GondorsLegacy.Services.Reservation.Migrations.Reservations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Guests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Firstname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Lastname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ReservationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerFirstName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CustomerLastName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    HotelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HotelName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CheckInDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckOutDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RoomType = table.Column<int>(type: "int", nullable: false),
                    NumberOfGuests = table.Column<int>(type: "int", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RoomNumber = table.Column<int>(type: "int", nullable: false),
                    CustomerEmail = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ReservationStatus = table.Column<int>(type: "int", nullable: false),
                    SpecialRequests = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    NumberOfAdults = table.Column<int>(type: "int", nullable: false),
                    NumberOfChildren = table.Column<int>(type: "int", nullable: false),
                    PaymentStatus = table.Column<int>(type: "int", nullable: false),
                    CancellationReason = table.Column<int>(type: "int", nullable: false),
                    IsReservationCancelled = table.Column<bool>(type: "bit", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Guests",
                columns: new[] { "Id", "CreatedDateTime", "DateOfBirth", "EmailAddress", "Firstname", "Gender", "Lastname", "PhoneNumber", "ReservationId", "UpdatedDateTime" },
                values: new object[,]
                {
                    { new Guid("1c951a59-a126-4a8d-b4b9-bf48377b13a0"), new DateTimeOffset(new DateTime(2024, 5, 1, 12, 39, 31, 925, DateTimeKind.Unspecified).AddTicks(8168), new TimeSpan(0, 3, 0, 0, 0)), new DateTime(1995, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "yasin.kanberoglu@gmail.com", "Yasin Mirza", 0, "KANBEROĞLU", "05303288200", new Guid("b8a07d3e-ca94-4a51-bc7d-ef1db4a566c6"), new DateTimeOffset(new DateTime(2024, 5, 1, 12, 39, 31, 925, DateTimeKind.Unspecified).AddTicks(8129), new TimeSpan(0, 3, 0, 0, 0)) },
                    { new Guid("d39aae86-a6c6-40e5-bc69-9e0953e7b6cf"), new DateTimeOffset(new DateTime(2024, 5, 1, 12, 39, 31, 925, DateTimeKind.Unspecified).AddTicks(8178), new TimeSpan(0, 3, 0, 0, 0)), new DateTime(1994, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "asli.kanberoglu@gmail.com", "Aslı", 0, "KANBEROĞLU", "05303288201", new Guid("b8a07d3e-ca94-4a51-bc7d-ef1db4a566c6"), new DateTimeOffset(new DateTime(2024, 5, 1, 12, 39, 31, 925, DateTimeKind.Unspecified).AddTicks(8177), new TimeSpan(0, 3, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "CancellationReason", "CheckInDate", "CheckOutDate", "CreatedDateTime", "CustomerEmail", "CustomerFirstName", "CustomerId", "CustomerLastName", "HotelId", "HotelName", "IsReservationCancelled", "NumberOfAdults", "NumberOfChildren", "NumberOfGuests", "PaymentStatus", "ReservationStatus", "RoomNumber", "RoomType", "SpecialRequests", "TotalPrice", "UpdatedDateTime" },
                values: new object[] { new Guid("b8a07d3e-ca94-4a51-bc7d-ef1db4a566c6"), 0, new DateTime(2024, 5, 1, 12, 39, 31, 926, DateTimeKind.Local).AddTicks(1131), new DateTime(2024, 5, 9, 12, 39, 31, 926, DateTimeKind.Local).AddTicks(1133), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "yasin.kanberoglu@gmail.com", "Yasin Mirza", new Guid("af7a41ad-bb23-4237-9177-211cc0541d2c"), "Kanberoğlu", new Guid("fa6284cf-9614-4b4d-95fe-5e630c7c8e2e"), "Hilton Otel", false, 2, 0, 2, 0, 0, 501, 6, "Internet mutlaka olmalıdır!", 17500.12m, new DateTimeOffset(new DateTime(2024, 5, 1, 12, 39, 31, 926, DateTimeKind.Unspecified).AddTicks(1155), new TimeSpan(0, 3, 0, 0, 0)) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Guests");

            migrationBuilder.DropTable(
                name: "Reservations");
        }
    }
}
