using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GondorsLegacy.Services.Reservation.Migrations.ReservationDb
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerFirstName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CustomerLastName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
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
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "CancellationReason", "CheckInDate", "CheckOutDate", "CreatedDateTime", "CustomerEmail", "CustomerFirstName", "CustomerId", "CustomerLastName", "NumberOfAdults", "NumberOfChildren", "NumberOfGuests", "PaymentStatus", "ReservationStatus", "RoomNumber", "RoomType", "SpecialRequests", "TotalPrice", "UpdatedDateTime" },
                values: new object[,]
                {
                    { new Guid("0a6e0a46-a030-4c2e-b3bc-d89b366019cc"), 0, new DateTime(2023, 10, 18, 14, 42, 39, 813, DateTimeKind.Local).AddTicks(300), new DateTime(2023, 10, 21, 14, 42, 39, 813, DateTimeKind.Local).AddTicks(300), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "ahmet.cakar@gmail.com", "Ahmet ASLAN ", new Guid("0b79449d-1f74-4df3-bf5a-1a7f4681fdd4"), "ÇAKAR", 2, 1, 3, 1, 1, 502, 2, "Çocuğum için klozete basamak koyulabilir mi?", 21500.00m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("7d4ad39b-fd9e-4be0-b493-289b020662ed"), 0, new DateTime(2023, 10, 17, 14, 42, 39, 813, DateTimeKind.Local).AddTicks(250), new DateTime(2023, 10, 25, 14, 42, 39, 813, DateTimeKind.Local).AddTicks(280), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "yasin.salvator@gmail.com", "Yasin Çınar", new Guid("f431d7b7-d24b-4656-a075-f4f2243a4583"), "SALVATOR", 2, 0, 2, 0, 0, 501, 1, "Internet mutlaka olmalıdır!", 17500.12m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("b301e2c0-6b50-4894-8dec-17b84dee4841"), 0, new DateTime(2023, 10, 29, 14, 42, 39, 813, DateTimeKind.Local).AddTicks(310), new DateTime(2023, 11, 3, 14, 42, 39, 813, DateTimeKind.Local).AddTicks(310), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "ahmet.cakar@gmail.com", "Sibel", new Guid("00000000-0000-0000-0000-000000000000"), "SAĞLAM", 1, 0, 1, 0, 0, 503, 0, "Sigara kullanılmayan oda olsun.", 1500.00m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservations");
        }
    }
}
