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
                columns: new[] { "Id", "CancellationReason", "CheckInDate", "CheckOutDate", "CreatedDateTime", "CustomerEmail", "CustomerFirstName", "CustomerId", "CustomerLastName", "HotelId", "HotelName", "NumberOfAdults", "NumberOfChildren", "NumberOfGuests", "PaymentStatus", "ReservationStatus", "RoomNumber", "RoomType", "SpecialRequests", "TotalPrice", "UpdatedDateTime" },
                values: new object[,]
                {
                    { new Guid("00e8c982-0333-4aa7-ab0a-e558a6fb70c0"), 0, new DateTime(2023, 10, 22, 19, 42, 37, 882, DateTimeKind.Local).AddTicks(5220), new DateTime(2023, 10, 25, 19, 42, 37, 882, DateTimeKind.Local).AddTicks(5220), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "peter.parker@example.com", "Peter Parker", new Guid("467ee961-0f5a-45be-9873-d1e3aa269ab2"), "Parker", new Guid("00000000-0000-0000-0000-000000000000"), null, 2, 2, 4, 1, 1, 603, 2, "Need a room with two double beds.", 35000.75m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("434c491d-a4f8-4df1-b81c-7141a3d4c2af"), 0, new DateTime(2023, 11, 1, 19, 42, 37, 882, DateTimeKind.Local).AddTicks(5200), new DateTime(2023, 11, 6, 19, 42, 37, 882, DateTimeKind.Local).AddTicks(5200), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "ahmet.cakar@gmail.com", "Sibel", new Guid("62d3ca19-e012-4322-8ad7-abba68880aec"), "SAĞLAM", new Guid("00000000-0000-0000-0000-000000000000"), null, 1, 0, 1, 0, 0, 503, 0, "Sigara kullanılmayan oda olsun.", 1500.00m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("635597d9-f9c7-42ce-a4e8-0bd008e48fd6"), 0, new DateTime(2023, 10, 21, 19, 42, 37, 882, DateTimeKind.Local).AddTicks(5180), new DateTime(2023, 10, 24, 19, 42, 37, 882, DateTimeKind.Local).AddTicks(5190), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "ahmet.cakar@gmail.com", "Ahmet ASLAN ", new Guid("4b37b031-ff82-4cf2-b213-664748c2508c"), "ÇAKAR", new Guid("00000000-0000-0000-0000-000000000000"), null, 2, 1, 3, 1, 1, 502, 2, "Çocuğum için klozete basamak koyulabilir mi?", 21500.00m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("63e34dc1-58bf-4eb3-af4d-2d2712f0a0c0"), 0, new DateTime(2023, 10, 21, 19, 42, 37, 882, DateTimeKind.Local).AddTicks(5200), new DateTime(2023, 10, 23, 19, 42, 37, 882, DateTimeKind.Local).AddTicks(5200), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "john.doe@example.com", "John Doe", new Guid("02488b69-9ab2-4a64-ac0c-a48e070ca185"), "Doe", new Guid("00000000-0000-0000-0000-000000000000"), null, 1, 0, 1, 0, 0, 101, 0, "Need a quiet room.", 8000.50m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("80e28a38-01e4-4ea5-9be8-82dba50950fe"), 0, new DateTime(2023, 10, 21, 19, 42, 37, 882, DateTimeKind.Local).AddTicks(5260), new DateTime(2023, 10, 27, 19, 42, 37, 882, DateTimeKind.Local).AddTicks(5270), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "jane.doe@example.com", "Jane Doe", new Guid("77f7a42a-b49b-4288-b906-3b66a423237d"), "Doe", new Guid("00000000-0000-0000-0000-000000000000"), null, 2, 0, 2, 0, 0, 502, 1, "Need a room with a view.", 22000.00m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("8ae5bed7-c1b6-4de4-9374-d6f26e45dded"), 0, new DateTime(2023, 10, 21, 19, 42, 37, 882, DateTimeKind.Local).AddTicks(5260), new DateTime(2023, 10, 23, 19, 42, 37, 882, DateTimeKind.Local).AddTicks(5260), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "john.doe@example.com", "John Doe", new Guid("1bc8f146-35f2-4ce6-9673-23ad1a58cfb5"), "Doe", new Guid("00000000-0000-0000-0000-000000000000"), null, 1, 0, 1, 1, 1, 101, 0, "Need a quiet room.", 8000.50m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("8e844b9a-0900-47f7-887c-2ef503569cde"), 0, new DateTime(2023, 10, 26, 19, 42, 37, 882, DateTimeKind.Local).AddTicks(5240), new DateTime(2023, 10, 29, 19, 42, 37, 882, DateTimeKind.Local).AddTicks(5240), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "aysegul.aktas@example.com", "Ayşegül Aktaş", new Guid("d1a2a34d-a26d-464c-8d50-c5099659ff74"), "Aktaş", new Guid("00000000-0000-0000-0000-000000000000"), null, 1, 0, 1, 0, 0, 201, 0, "Need a room with a wheelchair accessible bathroom.", 10000.00m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("97cabaff-4725-409b-a3f1-c6665e8bd55e"), 0, new DateTime(2023, 10, 23, 19, 42, 37, 882, DateTimeKind.Local).AddTicks(5230), new DateTime(2023, 10, 25, 19, 42, 37, 882, DateTimeKind.Local).AddTicks(5230), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "ali.yilmaz@example.com", "Ali Yılmaz", new Guid("05dda1d6-bd98-48ec-89bb-bc1a034ada86"), "Yılmaz", new Guid("00000000-0000-0000-0000-000000000000"), null, 2, 1, 3, 2, 2, 701, 2, "Need a room with a balcony.", 45000.00m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("e2f0ac1b-f22e-4dbd-9a74-45ef15588f7a"), 0, new DateTime(2023, 10, 22, 19, 42, 37, 882, DateTimeKind.Local).AddTicks(5270), new DateTime(2023, 10, 25, 19, 42, 37, 882, DateTimeKind.Local).AddTicks(5270), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "peter.parker@example.com", "Peter Parker", new Guid("073f2fd4-6ecd-4b6b-8586-cd4198df7f85"), "Parker", new Guid("00000000-0000-0000-0000-000000000000"), null, 2, 2, 4, 1, 1, 603, 2, "Need a room with two double beds.", 35000.75m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("e8ca9cfc-2c88-4056-9926-bf46cff49282"), 0, new DateTime(2023, 10, 27, 19, 42, 37, 882, DateTimeKind.Local).AddTicks(5250), new DateTime(2023, 10, 30, 19, 42, 37, 882, DateTimeKind.Local).AddTicks(5250), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "mehmet.ozdemir@example.com", "Mehmet Özdemir", new Guid("32cd45bf-2195-4a38-b7b3-d8bf2e9391ae"), "Özdemir", new Guid("00000000-0000-0000-0000-000000000000"), null, 2, 0, 2, 0, 0, 402, 1, "Need a room with a king-sized bed.", 25000.00m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("fc5f77f5-8e32-48d1-b05c-b88671c8db8c"), 0, new DateTime(2023, 10, 21, 19, 42, 37, 882, DateTimeKind.Local).AddTicks(5210), new DateTime(2023, 10, 27, 19, 42, 37, 882, DateTimeKind.Local).AddTicks(5210), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "jane.doe@example.com", "Jane Doe", new Guid("6423f059-7033-4f31-a19a-25d4970b90c7"), "Doe", new Guid("00000000-0000-0000-0000-000000000000"), null, 2, 0, 2, 0, 0, 502, 1, "Need a room with a view.", 22000.00m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("fcfcb6f0-560a-42e3-83f5-e5dc4aadc6c7"), 0, new DateTime(2023, 10, 20, 19, 42, 37, 882, DateTimeKind.Local).AddTicks(5140), new DateTime(2023, 10, 28, 19, 42, 37, 882, DateTimeKind.Local).AddTicks(5170), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "yasin.salvator@gmail.com", "Yasin Çınar", new Guid("a6c3e8f0-bdbf-411e-ae96-9efa0833af8b"), "SALVATOR", new Guid("00000000-0000-0000-0000-000000000000"), null, 2, 0, 2, 0, 0, 501, 1, "Internet mutlaka olmalıdır!", 17500.12m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
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
