using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GondorsLegacy.Services.HotelInformation.Migrations.Hotels
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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HotelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Province = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Neighborhood = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdditionalInfo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BuildingNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Floor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApartmentNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    POBox = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    IsSecure = table.Column<bool>(type: "bit", nullable: false),
                    SecurityCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Labels = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HotelCustomerReviews",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HotelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReviewTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReviewText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReviewDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsRecommended = table.Column<bool>(type: "bit", nullable: false),
                    IsVerified = table.Column<bool>(type: "bit", nullable: false),
                    IsHelpful = table.Column<bool>(type: "bit", nullable: false),
                    Likes = table.Column<int>(type: "int", nullable: false),
                    Dislikes = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelCustomerReviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HotelCustomerReviews_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HotelPolicies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HotelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HotelPolicyType = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelPolicies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HotelPolicies_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HotelRatings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HotelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Stars = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cleanliness = table.Column<float>(type: "real", nullable: false),
                    ServiceQuality = table.Column<float>(type: "real", nullable: false),
                    ValueForMoney = table.Column<float>(type: "real", nullable: false),
                    Location = table.Column<float>(type: "real", nullable: false),
                    Amenities = table.Column<float>(type: "real", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelRatings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HotelRatings_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HotelRooms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HotelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoomType = table.Column<int>(type: "int", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelRooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HotelRooms_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HotelServices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HotelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HotelServiceType = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HotelServices_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "CreatedDateTime", "Description", "EmailAddress", "Name", "Phone", "UpdatedDateTime", "Website" },
                values: new object[] { new Guid("459f9270-9f33-488b-a6d6-0b441697c50c"), new DateTimeOffset(new DateTime(2024, 4, 30, 16, 51, 35, 22, DateTimeKind.Unspecified).AddTicks(1703), new TimeSpan(0, 3, 0, 0, 0)), "Açıklama", "info@salvatorresort.com", "SALVATOR RESORT HOTEL", "05303288200", new DateTimeOffset(new DateTime(2024, 4, 30, 16, 51, 35, 22, DateTimeKind.Unspecified).AddTicks(1718), new TimeSpan(0, 3, 0, 0, 0)), "https://www.salvatorresort.com" });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "AdditionalInfo", "ApartmentNumber", "BuildingNumber", "City", "Country", "CreatedDateTime", "District", "Floor", "HotelId", "IsSecure", "Labels", "Latitude", "Longitude", "Neighborhood", "POBox", "PostCode", "Province", "SecurityCode", "Street", "UpdatedDateTime" },
                values: new object[] { new Guid("ca937045-e20d-4651-89b1-3dbebd8b1156"), "NULL", "5", "9", "İstanbul", "Türkiye", new DateTimeOffset(new DateTime(2024, 4, 30, 16, 51, 35, 21, DateTimeKind.Unspecified).AddTicks(6217), new TimeSpan(0, 3, 0, 0, 0)), "Gaziosmanpaşa", "1", new Guid("459f9270-9f33-488b-a6d6-0b441697c50c"), true, "Özel Mülk", 34.100000000000001, 41.5, "Yenidoğan", "34100", "34100", "İstanbul", "f4e465s1", "Kuyu", new DateTimeOffset(new DateTime(2024, 4, 30, 16, 51, 35, 21, DateTimeKind.Unspecified).AddTicks(6291), new TimeSpan(0, 3, 0, 0, 0)) });

            migrationBuilder.InsertData(
                table: "HotelCustomerReviews",
                columns: new[] { "Id", "CreatedDateTime", "CustomerId", "Dislikes", "HotelId", "IsHelpful", "IsRecommended", "IsVerified", "Likes", "ReviewDate", "ReviewText", "ReviewTitle", "UpdatedDateTime" },
                values: new object[,]
                {
                    { new Guid("5ae56c1c-e4f8-4dce-a348-7e97e10e502d"), new DateTimeOffset(new DateTime(2024, 4, 30, 16, 51, 35, 22, DateTimeKind.Unspecified).AddTicks(3597), new TimeSpan(0, 3, 0, 0, 0)), new Guid("7f1831d1-4fc0-4899-afab-156ed1ab5c24"), 10, new Guid("459f9270-9f33-488b-a6d6-0b441697c50c"), true, true, true, 10, new DateTime(2024, 4, 30, 16, 51, 35, 22, DateTimeKind.Local).AddTicks(3621), "Bu otele bayıldım", "Bu otele bayıldım!", new DateTimeOffset(new DateTime(2024, 4, 30, 16, 51, 35, 22, DateTimeKind.Unspecified).AddTicks(3623), new TimeSpan(0, 3, 0, 0, 0)) },
                    { new Guid("e6c1fdf7-40b7-44a6-9d53-1bac83eea279"), new DateTimeOffset(new DateTime(2024, 4, 30, 16, 51, 35, 22, DateTimeKind.Unspecified).AddTicks(3628), new TimeSpan(0, 3, 0, 0, 0)), new Guid("93803ce2-71d1-4b23-88e6-13c3a5f63398"), 12, new Guid("459f9270-9f33-488b-a6d6-0b441697c50c"), true, true, true, 17, new DateTime(2024, 4, 30, 16, 51, 35, 22, DateTimeKind.Local).AddTicks(3629), "Bu otele güzeldi", "Bu otel güzeldi!", new DateTimeOffset(new DateTime(2024, 4, 30, 16, 51, 35, 22, DateTimeKind.Unspecified).AddTicks(3630), new TimeSpan(0, 3, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "HotelPolicies",
                columns: new[] { "Id", "CreatedDateTime", "HotelId", "HotelPolicyType", "UpdatedDateTime" },
                values: new object[,]
                {
                    { new Guid("0d0d277b-4806-4e6b-a043-e5cde90def76"), new DateTimeOffset(new DateTime(2024, 4, 30, 16, 51, 35, 22, DateTimeKind.Unspecified).AddTicks(5072), new TimeSpan(0, 3, 0, 0, 0)), new Guid("459f9270-9f33-488b-a6d6-0b441697c50c"), 56, new DateTimeOffset(new DateTime(2024, 4, 30, 16, 51, 35, 22, DateTimeKind.Unspecified).AddTicks(5073), new TimeSpan(0, 3, 0, 0, 0)) },
                    { new Guid("3ab6b852-2c64-474f-9d2a-b5c7b027d186"), new DateTimeOffset(new DateTime(2024, 4, 30, 16, 51, 35, 22, DateTimeKind.Unspecified).AddTicks(5076), new TimeSpan(0, 3, 0, 0, 0)), new Guid("459f9270-9f33-488b-a6d6-0b441697c50c"), 44, new DateTimeOffset(new DateTime(2024, 4, 30, 16, 51, 35, 22, DateTimeKind.Unspecified).AddTicks(5077), new TimeSpan(0, 3, 0, 0, 0)) },
                    { new Guid("78850b86-a52b-45fa-b33f-f88f61d54273"), new DateTimeOffset(new DateTime(2024, 4, 30, 16, 51, 35, 22, DateTimeKind.Unspecified).AddTicks(5061), new TimeSpan(0, 3, 0, 0, 0)), new Guid("459f9270-9f33-488b-a6d6-0b441697c50c"), 14, new DateTimeOffset(new DateTime(2024, 4, 30, 16, 51, 35, 22, DateTimeKind.Unspecified).AddTicks(5068), new TimeSpan(0, 3, 0, 0, 0)) },
                    { new Guid("d7a90fc6-8073-4b0e-91dc-01f226bbac10"), new DateTimeOffset(new DateTime(2024, 4, 30, 16, 51, 35, 22, DateTimeKind.Unspecified).AddTicks(5080), new TimeSpan(0, 3, 0, 0, 0)), new Guid("459f9270-9f33-488b-a6d6-0b441697c50c"), 23, new DateTimeOffset(new DateTime(2024, 4, 30, 16, 51, 35, 22, DateTimeKind.Unspecified).AddTicks(5081), new TimeSpan(0, 3, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "HotelRatings",
                columns: new[] { "Id", "Amenities", "Cleanliness", "CreatedDateTime", "Description", "HotelId", "Location", "ServiceQuality", "Stars", "UpdatedDateTime", "ValueForMoney" },
                values: new object[] { new Guid("d2e6cf3a-d001-4659-a10a-5d27272241b5"), 10f, 10f, new DateTimeOffset(new DateTime(2024, 4, 30, 16, 51, 35, 22, DateTimeKind.Unspecified).AddTicks(6309), new TimeSpan(0, 3, 0, 0, 0)), "NULL", new Guid("459f9270-9f33-488b-a6d6-0b441697c50c"), 10f, 10f, 5, new DateTimeOffset(new DateTime(2024, 4, 30, 16, 51, 35, 22, DateTimeKind.Unspecified).AddTicks(6315), new TimeSpan(0, 3, 0, 0, 0)), 10f });

            migrationBuilder.InsertData(
                table: "HotelRooms",
                columns: new[] { "Id", "Capacity", "CreatedDateTime", "HotelId", "RoomType", "UpdatedDateTime" },
                values: new object[,]
                {
                    { new Guid("93abd8c4-2460-4839-a801-301272d4123f"), 50, new DateTimeOffset(new DateTime(2024, 4, 30, 16, 51, 35, 22, DateTimeKind.Unspecified).AddTicks(7492), new TimeSpan(0, 3, 0, 0, 0)), new Guid("459f9270-9f33-488b-a6d6-0b441697c50c"), 0, new DateTimeOffset(new DateTime(2024, 4, 30, 16, 51, 35, 22, DateTimeKind.Unspecified).AddTicks(7505), new TimeSpan(0, 3, 0, 0, 0)) },
                    { new Guid("e3454d91-301a-4c13-bc43-d008c744be09"), 80, new DateTimeOffset(new DateTime(2024, 4, 30, 16, 51, 35, 22, DateTimeKind.Unspecified).AddTicks(7520), new TimeSpan(0, 3, 0, 0, 0)), new Guid("459f9270-9f33-488b-a6d6-0b441697c50c"), 5, new DateTimeOffset(new DateTime(2024, 4, 30, 16, 51, 35, 22, DateTimeKind.Unspecified).AddTicks(7522), new TimeSpan(0, 3, 0, 0, 0)) },
                    { new Guid("fe13f5b3-d735-473f-a510-307d9155deb0"), 75, new DateTimeOffset(new DateTime(2024, 4, 30, 16, 51, 35, 22, DateTimeKind.Unspecified).AddTicks(7515), new TimeSpan(0, 3, 0, 0, 0)), new Guid("459f9270-9f33-488b-a6d6-0b441697c50c"), 3, new DateTimeOffset(new DateTime(2024, 4, 30, 16, 51, 35, 22, DateTimeKind.Unspecified).AddTicks(7518), new TimeSpan(0, 3, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "HotelServices",
                columns: new[] { "Id", "CreatedDateTime", "HotelId", "HotelServiceType", "UpdatedDateTime" },
                values: new object[,]
                {
                    { new Guid("33d5cf9a-b162-4bd1-9ccd-84ce176a3f22"), new DateTimeOffset(new DateTime(2024, 4, 30, 16, 51, 35, 22, DateTimeKind.Unspecified).AddTicks(8978), new TimeSpan(0, 3, 0, 0, 0)), new Guid("459f9270-9f33-488b-a6d6-0b441697c50c"), 52, new DateTimeOffset(new DateTime(2024, 4, 30, 16, 51, 35, 22, DateTimeKind.Unspecified).AddTicks(8979), new TimeSpan(0, 3, 0, 0, 0)) },
                    { new Guid("53d2af56-fcdf-407f-9a17-5b05dd0fc336"), new DateTimeOffset(new DateTime(2024, 4, 30, 16, 51, 35, 22, DateTimeKind.Unspecified).AddTicks(8990), new TimeSpan(0, 3, 0, 0, 0)), new Guid("459f9270-9f33-488b-a6d6-0b441697c50c"), 73, new DateTimeOffset(new DateTime(2024, 4, 30, 16, 51, 35, 22, DateTimeKind.Unspecified).AddTicks(8991), new TimeSpan(0, 3, 0, 0, 0)) },
                    { new Guid("7e3f89e2-be99-48e1-a43f-6d9aebd5a92b"), new DateTimeOffset(new DateTime(2024, 4, 30, 16, 51, 35, 22, DateTimeKind.Unspecified).AddTicks(8982), new TimeSpan(0, 3, 0, 0, 0)), new Guid("459f9270-9f33-488b-a6d6-0b441697c50c"), 34, new DateTimeOffset(new DateTime(2024, 4, 30, 16, 51, 35, 22, DateTimeKind.Unspecified).AddTicks(8983), new TimeSpan(0, 3, 0, 0, 0)) },
                    { new Guid("8aaf0f3e-f150-4e9c-8da7-8f154e54a20e"), new DateTimeOffset(new DateTime(2024, 4, 30, 16, 51, 35, 22, DateTimeKind.Unspecified).AddTicks(8961), new TimeSpan(0, 3, 0, 0, 0)), new Guid("459f9270-9f33-488b-a6d6-0b441697c50c"), 75, new DateTimeOffset(new DateTime(2024, 4, 30, 16, 51, 35, 22, DateTimeKind.Unspecified).AddTicks(8973), new TimeSpan(0, 3, 0, 0, 0)) },
                    { new Guid("f5c22a88-3e86-405c-86de-1b75bca1e98e"), new DateTimeOffset(new DateTime(2024, 4, 30, 16, 51, 35, 22, DateTimeKind.Unspecified).AddTicks(8986), new TimeSpan(0, 3, 0, 0, 0)), new Guid("459f9270-9f33-488b-a6d6-0b441697c50c"), 9, new DateTimeOffset(new DateTime(2024, 4, 30, 16, 51, 35, 22, DateTimeKind.Unspecified).AddTicks(8987), new TimeSpan(0, 3, 0, 0, 0)) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_HotelId",
                table: "Addresses",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_HotelCustomerReviews_HotelId",
                table: "HotelCustomerReviews",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_HotelPolicies_HotelId",
                table: "HotelPolicies",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_HotelRatings_HotelId",
                table: "HotelRatings",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_HotelRooms_HotelId",
                table: "HotelRooms",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_HotelServices_HotelId",
                table: "HotelServices",
                column: "HotelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "HotelCustomerReviews");

            migrationBuilder.DropTable(
                name: "HotelPolicies");

            migrationBuilder.DropTable(
                name: "HotelRatings");

            migrationBuilder.DropTable(
                name: "HotelRooms");

            migrationBuilder.DropTable(
                name: "HotelServices");

            migrationBuilder.DropTable(
                name: "Hotels");
        }
    }
}
