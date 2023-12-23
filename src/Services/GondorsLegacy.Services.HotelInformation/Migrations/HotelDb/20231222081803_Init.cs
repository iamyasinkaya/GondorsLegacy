using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GondorsLegacy.Services.HotelInformation.Migrations.HotelDb
{
    /// <inheritdoc />
    public partial class Init : Migration
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
                    { new Guid("1df5491a-2109-4ad0-864d-6b2d95f0687e"), new DateTimeOffset(new DateTime(2023, 12, 22, 8, 18, 3, 519, DateTimeKind.Unspecified).AddTicks(5651), new TimeSpan(0, 0, 0, 0, 0)), "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s,", "Salvator Hotel", new DateTimeOffset(new DateTime(2023, 12, 22, 8, 18, 3, 519, DateTimeKind.Unspecified).AddTicks(5652), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("a25d1208-49ef-428e-8441-25f494f66cd8"), new DateTimeOffset(new DateTime(2023, 12, 22, 8, 18, 3, 519, DateTimeKind.Unspecified).AddTicks(5655), new TimeSpan(0, 0, 0, 0, 0)), "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s,", "Kelebek Hotel", new DateTimeOffset(new DateTime(2023, 12, 22, 8, 18, 3, 519, DateTimeKind.Unspecified).AddTicks(5655), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("b30a16b2-8b74-4d54-a5bf-8e4411f67803"), new DateTimeOffset(new DateTime(2023, 12, 22, 8, 18, 3, 519, DateTimeKind.Unspecified).AddTicks(5661), new TimeSpan(0, 0, 0, 0, 0)), "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s,", "Koeralop Hotel", new DateTimeOffset(new DateTime(2023, 12, 22, 8, 18, 3, 519, DateTimeKind.Unspecified).AddTicks(5662), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("baf458d6-a9a0-4ff9-a795-9fd5358a16dc"), new DateTimeOffset(new DateTime(2023, 12, 22, 8, 18, 3, 519, DateTimeKind.Unspecified).AddTicks(5657), new TimeSpan(0, 0, 0, 0, 0)), "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s,", "Vensure Hotel", new DateTimeOffset(new DateTime(2023, 12, 22, 8, 18, 3, 519, DateTimeKind.Unspecified).AddTicks(5658), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("e0a98bd9-50ad-4ebe-8253-694ad35dcc3f"), new DateTimeOffset(new DateTime(2023, 12, 22, 8, 18, 3, 519, DateTimeKind.Unspecified).AddTicks(5659), new TimeSpan(0, 0, 0, 0, 0)), "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s,", "Radisson Hotel", new DateTimeOffset(new DateTime(2023, 12, 22, 8, 18, 3, 519, DateTimeKind.Unspecified).AddTicks(5660), new TimeSpan(0, 0, 0, 0, 0)) }
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
