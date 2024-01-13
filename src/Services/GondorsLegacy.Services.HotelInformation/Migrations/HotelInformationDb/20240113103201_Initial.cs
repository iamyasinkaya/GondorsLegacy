using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GondorsLegacy.Services.HotelInformation.Migrations.HotelInformationDb
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hotels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2500)", maxLength: 2500, nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotels", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "CreatedDateTime", "Description", "Name", "UpdatedDateTime" },
                values: new object[,]
                {
                    { new Guid("599bc6bd-68a7-43e6-bb91-ba39d15df78e"), new DateTimeOffset(new DateTime(2024, 1, 13, 10, 32, 1, 252, DateTimeKind.Unspecified).AddTicks(940), new TimeSpan(0, 0, 0, 0, 0)), "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s,", "Radisson Hotel", new DateTimeOffset(new DateTime(2024, 1, 13, 10, 32, 1, 252, DateTimeKind.Unspecified).AddTicks(940), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("c65715c0-8f50-457e-b274-1e908b669a14"), new DateTimeOffset(new DateTime(2024, 1, 13, 10, 32, 1, 252, DateTimeKind.Unspecified).AddTicks(942), new TimeSpan(0, 0, 0, 0, 0)), "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s,", "Koeralop Hotel", new DateTimeOffset(new DateTime(2024, 1, 13, 10, 32, 1, 252, DateTimeKind.Unspecified).AddTicks(942), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("e29fcaa9-406c-49b2-b375-8166963f32a8"), new DateTimeOffset(new DateTime(2024, 1, 13, 10, 32, 1, 252, DateTimeKind.Unspecified).AddTicks(937), new TimeSpan(0, 0, 0, 0, 0)), "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s,", "Vensure Hotel", new DateTimeOffset(new DateTime(2024, 1, 13, 10, 32, 1, 252, DateTimeKind.Unspecified).AddTicks(938), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("fb456969-5392-4e25-abca-06d89a284aa7"), new DateTimeOffset(new DateTime(2024, 1, 13, 10, 32, 1, 252, DateTimeKind.Unspecified).AddTicks(930), new TimeSpan(0, 0, 0, 0, 0)), "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s,", "Salvator Hotel", new DateTimeOffset(new DateTime(2024, 1, 13, 10, 32, 1, 252, DateTimeKind.Unspecified).AddTicks(932), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("fc72ceb6-6482-4245-9358-ab215fb3e816"), new DateTimeOffset(new DateTime(2024, 1, 13, 10, 32, 1, 252, DateTimeKind.Unspecified).AddTicks(935), new TimeSpan(0, 0, 0, 0, 0)), "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s,", "Kelebek Hotel", new DateTimeOffset(new DateTime(2024, 1, 13, 10, 32, 1, 252, DateTimeKind.Unspecified).AddTicks(935), new TimeSpan(0, 0, 0, 0, 0)) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hotels");
        }
    }
}
