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
                    HotelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HotelName = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                table: "Reservations",
                columns: new[] { "Id", "CancellationReason", "CheckInDate", "CheckOutDate", "CreatedDateTime", "CustomerEmail", "CustomerFirstName", "CustomerId", "CustomerLastName", "HotelId", "HotelName", "IsReservationCancelled", "NumberOfAdults", "NumberOfChildren", "NumberOfGuests", "PaymentStatus", "ReservationStatus", "RoomNumber", "RoomType", "SpecialRequests", "TotalPrice", "UpdatedDateTime" },
                values: new object[,]
                {
                    { new Guid("048838a3-741a-4d32-b171-2d061f5494e2"), 0, new DateTime(2023, 10, 28, 1, 4, 3, 467, DateTimeKind.Local).AddTicks(210), new DateTime(2023, 10, 31, 1, 4, 3, 467, DateTimeKind.Local).AddTicks(210), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "mehmet.ozdemir@example.com", "Mehmet Özdemir", new Guid("2ba1e7cb-86c5-4a1a-abb6-9d2ed4a9dd14"), "Özdemir", new Guid("00000000-0000-0000-0000-000000000000"), null, false, 2, 0, 2, 0, 0, 402, 1, "Need a room with a king-sized bed.", 25000.00m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("13176391-361d-436e-abe0-e98b8c82a234"), 0, new DateTime(2023, 10, 22, 1, 4, 3, 467, DateTimeKind.Local).AddTicks(120), new DateTime(2023, 10, 28, 1, 4, 3, 467, DateTimeKind.Local).AddTicks(120), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "jane.doe@example.com", "Jane Doe", new Guid("386af8ce-563e-4386-9138-e08294ff3aa0"), "Doe", new Guid("00000000-0000-0000-0000-000000000000"), null, false, 2, 0, 2, 0, 0, 502, 1, "Need a room with a view.", 22000.00m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("1f9c5401-2840-419f-9860-baf015ab0b9b"), 0, new DateTime(2023, 10, 24, 1, 4, 3, 467, DateTimeKind.Local).AddTicks(190), new DateTime(2023, 10, 26, 1, 4, 3, 467, DateTimeKind.Local).AddTicks(200), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "ali.yilmaz@example.com", "Ali Yılmaz", new Guid("3a141e18-e182-43ac-bf18-b8be76d73223"), "Yılmaz", new Guid("00000000-0000-0000-0000-000000000000"), null, false, 2, 1, 3, 2, 2, 701, 2, "Need a room with a balcony.", 45000.00m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("24d81139-de0b-4465-b00a-581f744d53d7"), 0, new DateTime(2023, 10, 23, 1, 4, 3, 467, DateTimeKind.Local).AddTicks(130), new DateTime(2023, 10, 26, 1, 4, 3, 467, DateTimeKind.Local).AddTicks(130), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "peter.parker@example.com", "Peter Parker", new Guid("e8631740-54f7-444f-ad7a-9975d413c375"), "Parker", new Guid("00000000-0000-0000-0000-000000000000"), null, false, 2, 2, 4, 1, 1, 603, 2, "Need a room with two double beds.", 35000.75m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("43ad979e-3e28-497d-b51f-bb2d62fe297a"), 0, new DateTime(2023, 11, 2, 1, 4, 3, 467, DateTimeKind.Local).AddTicks(110), new DateTime(2023, 11, 7, 1, 4, 3, 467, DateTimeKind.Local).AddTicks(110), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "ahmet.cakar@gmail.com", "Sibel", new Guid("34d59ff0-051b-484f-8f09-888d1736d7b6"), "SAĞLAM", new Guid("00000000-0000-0000-0000-000000000000"), null, false, 1, 0, 1, 0, 0, 503, 0, "Sigara kullanılmayan oda olsun.", 1500.00m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("636b643c-20ac-4a1a-bc6e-688c88ddbdc4"), 0, new DateTime(2023, 10, 22, 1, 4, 3, 467, DateTimeKind.Local).AddTicks(230), new DateTime(2023, 10, 28, 1, 4, 3, 467, DateTimeKind.Local).AddTicks(230), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "jane.doe@example.com", "Jane Doe", new Guid("fc4d0914-e0e3-41bc-bc64-ecbf427878ce"), "Doe", new Guid("00000000-0000-0000-0000-000000000000"), null, false, 2, 0, 2, 0, 0, 502, 1, "Need a room with a view.", 22000.00m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("67126244-a036-4a56-afe6-56d4631b42cd"), 0, new DateTime(2023, 10, 23, 1, 4, 3, 467, DateTimeKind.Local).AddTicks(240), new DateTime(2023, 10, 26, 1, 4, 3, 467, DateTimeKind.Local).AddTicks(240), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "peter.parker@example.com", "Peter Parker", new Guid("3fb599b9-0b28-41ba-84d3-2a12658569c0"), "Parker", new Guid("00000000-0000-0000-0000-000000000000"), null, false, 2, 2, 4, 1, 1, 603, 2, "Need a room with two double beds.", 35000.75m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("6b5db74c-1da3-4b06-8e62-1ffcf4731c43"), 0, new DateTime(2023, 10, 21, 1, 4, 3, 467, DateTimeKind.Local).AddTicks(40), new DateTime(2023, 10, 29, 1, 4, 3, 467, DateTimeKind.Local).AddTicks(70), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "yasin.salvator@gmail.com", "Yasin Çınar", new Guid("505e5ce5-714c-433c-b095-ed3b0770ac84"), "SALVATOR", new Guid("00000000-0000-0000-0000-000000000000"), null, false, 2, 0, 2, 0, 0, 501, 1, "Internet mutlaka olmalıdır!", 17500.12m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("8d5dc0b9-5707-4f5a-af25-091813b33817"), 0, new DateTime(2023, 10, 22, 1, 4, 3, 467, DateTimeKind.Local).AddTicks(220), new DateTime(2023, 10, 24, 1, 4, 3, 467, DateTimeKind.Local).AddTicks(220), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "john.doe@example.com", "John Doe", new Guid("2e728122-1db5-4a4b-bed0-cafa5fadb3d5"), "Doe", new Guid("00000000-0000-0000-0000-000000000000"), null, false, 1, 0, 1, 1, 1, 101, 0, "Need a quiet room.", 8000.50m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("b78ba515-3337-4dc2-a492-68e3918a56d0"), 0, new DateTime(2023, 10, 27, 1, 4, 3, 467, DateTimeKind.Local).AddTicks(200), new DateTime(2023, 10, 30, 1, 4, 3, 467, DateTimeKind.Local).AddTicks(200), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "aysegul.aktas@example.com", "Ayşegül Aktaş", new Guid("273bd7b3-8934-4820-abea-0078e22a55ff"), "Aktaş", new Guid("00000000-0000-0000-0000-000000000000"), null, false, 1, 0, 1, 0, 0, 201, 0, "Need a room with a wheelchair accessible bathroom.", 10000.00m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("bbd6f51b-01d8-4c02-8431-cf94d7b10224"), 0, new DateTime(2023, 10, 22, 1, 4, 3, 467, DateTimeKind.Local).AddTicks(100), new DateTime(2023, 10, 25, 1, 4, 3, 467, DateTimeKind.Local).AddTicks(100), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "ahmet.cakar@gmail.com", "Ahmet ASLAN ", new Guid("a0f75614-47d7-4d01-958d-9b948fd32dc3"), "ÇAKAR", new Guid("00000000-0000-0000-0000-000000000000"), null, false, 2, 1, 3, 1, 1, 502, 2, "Çocuğum için klozete basamak koyulabilir mi?", 21500.00m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("db416e7f-1c14-41eb-9606-2af6459ed98b"), 0, new DateTime(2023, 10, 22, 1, 4, 3, 467, DateTimeKind.Local).AddTicks(110), new DateTime(2023, 10, 24, 1, 4, 3, 467, DateTimeKind.Local).AddTicks(120), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "john.doe@example.com", "John Doe", new Guid("415eef8d-a3f8-4567-8e4f-8606d4ecf4f1"), "Doe", new Guid("00000000-0000-0000-0000-000000000000"), null, false, 1, 0, 1, 0, 0, 101, 0, "Need a quiet room.", 8000.50m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
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
