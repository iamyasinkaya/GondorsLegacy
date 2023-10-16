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
                    ReservationId = table.Column<int>(type: "int", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CheckInDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckOutDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RoomType = table.Column<int>(type: "int", nullable: false),
                    NumberOfGuests = table.Column<int>(type: "int", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RoomNumber = table.Column<int>(type: "int", nullable: false),
                    CustomerEmail = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ReservationStatus = table.Column<int>(type: "int", nullable: false),
                    PaymentInformation = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    SpecialRequests = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    NumberOfAdults = table.Column<int>(type: "int", nullable: false),
                    NumberOfChildren = table.Column<int>(type: "int", nullable: false),
                    TaxRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ExtraServicePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
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
                columns: new[] { "Id", "CancellationReason", "CheckInDate", "CheckOutDate", "CreatedDateTime", "CustomerEmail", "CustomerName", "ExtraServicePrice", "NumberOfAdults", "NumberOfChildren", "NumberOfGuests", "PaymentInformation", "PaymentStatus", "ReservationId", "ReservationStatus", "RoomNumber", "RoomType", "SpecialRequests", "TaxRate", "TotalPrice", "UpdatedDateTime" },
                values: new object[,]
                {
                    { new Guid("8df0f252-47bb-4d07-b373-ce61b91176bc"), 0, new DateTime(2023, 10, 28, 16, 5, 55, 399, DateTimeKind.Local).AddTicks(2580), new DateTime(2023, 11, 2, 16, 5, 55, 399, DateTimeKind.Local).AddTicks(2580), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "ahmet.cakar@gmail.com", "Sibel SAĞLAM", 0.00m, 1, 0, 1, "Ödendi", 0, 3, 0, 503, 0, "Sigara kullanılmayan oda olsun.", 20.00m, 1500.00m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("b836a1bc-7e88-40c6-abcf-7def69ee9b85"), 0, new DateTime(2023, 10, 17, 16, 5, 55, 399, DateTimeKind.Local).AddTicks(2570), new DateTime(2023, 10, 20, 16, 5, 55, 399, DateTimeKind.Local).AddTicks(2570), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "ahmet.cakar@gmail.com", "Ahmet ASLAN ÇAKAR", 0.00m, 2, 1, 3, "Bekliyor", 1, 2, 1, 502, 2, "Çocuğum için klozete basamak koyulabilir mi?", 20.00m, 21500.00m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("eeb48cda-4a54-4f4e-be79-9bc0897d51c2"), 0, new DateTime(2023, 10, 16, 16, 5, 55, 399, DateTimeKind.Local).AddTicks(2520), new DateTime(2023, 10, 24, 16, 5, 55, 399, DateTimeKind.Local).AddTicks(2550), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "yasin.salvator@gmail.com", "Yasin Çınar SALVATOR", 0.00m, 2, 0, 2, "Ödendi", 0, 1, 0, 501, 1, "Internet mutlaka olmalıdır!", 20.00m, 17500.12m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
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
