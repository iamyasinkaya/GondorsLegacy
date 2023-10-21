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
                table: "Reservations",
                columns: new[] { "Id", "CancellationReason", "CheckInDate", "CheckOutDate", "CreatedDateTime", "CustomerEmail", "CustomerFirstName", "CustomerId", "CustomerLastName", "HotelId", "HotelName", "IsReservationCancelled", "NumberOfAdults", "NumberOfChildren", "NumberOfGuests", "PaymentStatus", "ReservationStatus", "RoomNumber", "RoomType", "SpecialRequests", "TotalPrice", "UpdatedDateTime" },
                values: new object[,]
                {
                    { new Guid("0109bd61-0fc2-466b-a32c-206fe7f3956f"), 0, new DateTime(2023, 10, 23, 15, 52, 25, 544, DateTimeKind.Local).AddTicks(9910), new DateTime(2023, 10, 26, 15, 52, 25, 544, DateTimeKind.Local).AddTicks(9910), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "peter.parker@example.com", "Peter Parker", new Guid("2144bf0e-c462-4278-959c-c4801fe9d584"), "Parker", new Guid("69a019e9-dc9a-4fde-a082-2bb09db41603"), "Hilton Otel", false, 2, 2, 4, 1, 1, 603, 2, "Need a room with two double beds.", 35000.75m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("057611d0-10ca-4505-b1bd-ff477deb451d"), 0, new DateTime(2023, 10, 22, 15, 52, 25, 544, DateTimeKind.Local).AddTicks(9860), new DateTime(2023, 10, 25, 15, 52, 25, 544, DateTimeKind.Local).AddTicks(9860), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "ahmet.cakar@gmail.com", "Ahmet ASLAN ", new Guid("282ced65-8138-428e-b6af-f6b9498c4ca8"), "ÇAKAR", new Guid("d5b0f772-bea2-406f-8417-182f4f3881ea"), "Hilton Otel", false, 2, 1, 3, 1, 1, 502, 2, "Çocuğum için klozete basamak koyulabilir mi?", 21500.00m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("3b82150a-8076-4457-9e22-9571a092f824"), 0, new DateTime(2023, 10, 22, 15, 52, 25, 544, DateTimeKind.Local).AddTicks(9890), new DateTime(2023, 10, 28, 15, 52, 25, 544, DateTimeKind.Local).AddTicks(9890), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "jane.doe@example.com", "Jane Doe", new Guid("20a6f274-1022-454b-9c7e-47cb88136bc6"), "Doe", new Guid("e814fc57-b888-478a-99d3-b9dc31f7de08"), "Hilton Otel", false, 2, 0, 2, 0, 0, 502, 1, "Need a room with a view.", 22000.00m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("46dbf404-62eb-4a08-a8ca-f142396c7d3b"), 0, new DateTime(2023, 10, 23, 15, 52, 25, 544, DateTimeKind.Local).AddTicks(9990), new DateTime(2023, 10, 26, 15, 52, 25, 544, DateTimeKind.Local).AddTicks(9990), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "peter.parker@example.com", "Peter Parker", new Guid("81a44440-5b8f-4b48-bb97-d0d63041cd40"), "Parker", new Guid("13b8c194-b5f9-4f1a-8acd-55dbf597c6f3"), "Hilton Otel", false, 2, 2, 4, 1, 1, 603, 2, "Need a room with two double beds.", 35000.75m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("6dcc23e4-d3a6-4178-a882-d8862dbba3b7"), 0, new DateTime(2023, 10, 28, 15, 52, 25, 544, DateTimeKind.Local).AddTicks(9940), new DateTime(2023, 10, 31, 15, 52, 25, 544, DateTimeKind.Local).AddTicks(9940), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "mehmet.ozdemir@example.com", "Mehmet Özdemir", new Guid("5fa55ca6-4a7b-49be-abc4-c22f1a9d1be3"), "Özdemir", new Guid("4de693df-ef3a-4936-a973-cdcb976d8a69"), "Hilton Otel", false, 2, 0, 2, 0, 0, 402, 1, "Need a room with a king-sized bed.", 25000.00m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("7285e556-c91b-4ba4-9520-82cd404748fc"), 0, new DateTime(2023, 10, 24, 15, 52, 25, 544, DateTimeKind.Local).AddTicks(9920), new DateTime(2023, 10, 26, 15, 52, 25, 544, DateTimeKind.Local).AddTicks(9920), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "ali.yilmaz@example.com", "Ali Yılmaz", new Guid("f6b8e0c5-baf5-469b-b55f-e187626a1e37"), "Yılmaz", new Guid("e779aafb-7147-495c-a8ce-1f9102a58f88"), "Hilton Otel", false, 2, 1, 3, 2, 2, 701, 2, "Need a room with a balcony.", 45000.00m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("88aaed72-2670-4da0-b701-4d8dbb4c6cef"), 0, new DateTime(2023, 10, 27, 15, 52, 25, 544, DateTimeKind.Local).AddTicks(9930), new DateTime(2023, 10, 30, 15, 52, 25, 544, DateTimeKind.Local).AddTicks(9930), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "aysegul.aktas@example.com", "Ayşegül Aktaş", new Guid("4a9f08d0-f3c0-4feb-ace4-cf6baaeacd4f"), "Aktaş", new Guid("fa0f16ff-c2ba-4513-9c52-991e6b7a4127"), "Hilton Otel", false, 1, 0, 1, 0, 0, 201, 0, "Need a room with a wheelchair accessible bathroom.", 10000.00m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("b4dc50fa-add7-4c3f-b927-4fd5e3090f03"), 0, new DateTime(2023, 10, 21, 15, 52, 25, 544, DateTimeKind.Local).AddTicks(9810), new DateTime(2023, 10, 29, 15, 52, 25, 544, DateTimeKind.Local).AddTicks(9840), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "yasin.salvator@gmail.com", "Yasin Çınar", new Guid("ff4f4d78-e72c-49b8-993d-24be40eb6aa3"), "SALVATOR", new Guid("bc8034a7-c718-4b69-98f0-4fa80c304886"), "Hilton Otel", false, 2, 0, 2, 0, 0, 501, 1, "Internet mutlaka olmalıdır!", 17500.12m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("bde393d3-1bba-433f-8926-52b1d34f783a"), 0, new DateTime(2023, 10, 22, 15, 52, 25, 544, DateTimeKind.Local).AddTicks(9880), new DateTime(2023, 10, 24, 15, 52, 25, 544, DateTimeKind.Local).AddTicks(9880), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "john.doe@example.com", "John Doe", new Guid("8b36aa79-2bcd-4f0b-8c45-7bb645db66de"), "Doe", new Guid("c15fe9db-9d68-4ff7-bc3b-856dbebaf342"), "Hilton Otel", false, 1, 0, 1, 0, 0, 101, 0, "Need a quiet room.", 8000.50m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("c85bef17-31e3-486c-bfaa-6c7c3d87dd9e"), 0, new DateTime(2023, 10, 22, 15, 52, 25, 544, DateTimeKind.Local).AddTicks(9980), new DateTime(2023, 10, 28, 15, 52, 25, 544, DateTimeKind.Local).AddTicks(9980), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "jane.doe@example.com", "Jane Doe", new Guid("fdf2e3a5-8b8a-422e-9142-c9695170d390"), "Doe", new Guid("aa137bfe-289c-49e1-abe0-d3e247a91f00"), "Hilton Otel", false, 2, 0, 2, 0, 0, 502, 1, "Need a room with a view.", 22000.00m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("e452ccbf-0e0b-427e-80f5-618775536521"), 0, new DateTime(2023, 11, 2, 15, 52, 25, 544, DateTimeKind.Local).AddTicks(9870), new DateTime(2023, 11, 7, 15, 52, 25, 544, DateTimeKind.Local).AddTicks(9870), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "ahmet.cakar@gmail.com", "Sibel", new Guid("0cf04832-aafd-443b-b8c7-f4e306c5ffcc"), "SAĞLAM", new Guid("beb6ddc5-7dd4-4113-bd8c-7a921ccf8147"), "Hilton Otel", false, 1, 0, 1, 0, 0, 503, 0, "Sigara kullanılmayan oda olsun.", 1500.00m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("eb71c04b-11e8-404c-ae6f-3f404be81dfb"), 0, new DateTime(2023, 10, 22, 15, 52, 25, 544, DateTimeKind.Local).AddTicks(9950), new DateTime(2023, 10, 24, 15, 52, 25, 544, DateTimeKind.Local).AddTicks(9950), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "john.doe@example.com", "John Doe", new Guid("9061dc28-e587-4bdd-9126-d830a0627907"), "Doe", new Guid("b9baaa59-a96e-4381-b07a-e7d271d43524"), "Hilton Otel", false, 1, 0, 1, 1, 1, 101, 0, "Need a quiet room.", 8000.50m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
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
