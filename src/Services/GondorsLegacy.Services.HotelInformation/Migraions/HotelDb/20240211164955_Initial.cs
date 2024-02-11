using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GondorsLegacy.Services.HotelInformation.Migraions.HotelDb
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
                values: new object[] { new Guid("459f9270-9f33-488b-a6d6-0b441697c50c"), new DateTimeOffset(new DateTime(2024, 2, 11, 19, 49, 54, 878, DateTimeKind.Unspecified).AddTicks(8485), new TimeSpan(0, 3, 0, 0, 0)), "Açıklama", "info@salvatorresort.com", "SALVATOR RESORT HOTEL", "05303288200", new DateTimeOffset(new DateTime(2024, 2, 11, 19, 49, 54, 878, DateTimeKind.Unspecified).AddTicks(8502), new TimeSpan(0, 3, 0, 0, 0)), "https://www.salvatorresort.com" });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "AdditionalInfo", "ApartmentNumber", "BuildingNumber", "City", "Country", "CreatedDateTime", "District", "Floor", "HotelId", "IsSecure", "Labels", "Latitude", "Longitude", "Neighborhood", "POBox", "PostCode", "Province", "SecurityCode", "Street", "UpdatedDateTime" },
                values: new object[] { new Guid("3e97bd4c-6762-41e7-8595-6c79a5d91a19"), "NULL", "5", "9", "İstanbul", "Türkiye", new DateTimeOffset(new DateTime(2024, 2, 11, 19, 49, 54, 878, DateTimeKind.Unspecified).AddTicks(2798), new TimeSpan(0, 3, 0, 0, 0)), "Gaziosmanpaşa", "1", new Guid("459f9270-9f33-488b-a6d6-0b441697c50c"), true, "Özel Mülk", 34.100000000000001, 41.5, "Yenidoğan", "34100", "34100", "İstanbul", "f4e465s1", "Kuyu", new DateTimeOffset(new DateTime(2024, 2, 11, 19, 49, 54, 878, DateTimeKind.Unspecified).AddTicks(2862), new TimeSpan(0, 3, 0, 0, 0)) });

            migrationBuilder.InsertData(
                table: "HotelCustomerReviews",
                columns: new[] { "Id", "CreatedDateTime", "CustomerId", "Dislikes", "HotelId", "IsHelpful", "IsRecommended", "IsVerified", "Likes", "ReviewDate", "ReviewText", "ReviewTitle", "UpdatedDateTime" },
                values: new object[,]
                {
                    { new Guid("0230c9ac-c9fa-4d09-bf58-03979355604e"), new DateTimeOffset(new DateTime(2024, 2, 11, 19, 49, 54, 879, DateTimeKind.Unspecified).AddTicks(823), new TimeSpan(0, 3, 0, 0, 0)), new Guid("e1e1af7b-01f0-4dc3-95a1-dd6873bf3dd7"), 12, new Guid("459f9270-9f33-488b-a6d6-0b441697c50c"), true, true, true, 17, new DateTime(2024, 2, 11, 19, 49, 54, 879, DateTimeKind.Local).AddTicks(825), "Bu otele güzeldi", "Bu otel güzeldi!", new DateTimeOffset(new DateTime(2024, 2, 11, 19, 49, 54, 879, DateTimeKind.Unspecified).AddTicks(827), new TimeSpan(0, 3, 0, 0, 0)) },
                    { new Guid("5aa381c7-7dab-4c81-a8d0-6c517ded8318"), new DateTimeOffset(new DateTime(2024, 2, 11, 19, 49, 54, 879, DateTimeKind.Unspecified).AddTicks(773), new TimeSpan(0, 3, 0, 0, 0)), new Guid("efb1421d-65e7-4eda-bc9d-b6080420ba17"), 10, new Guid("459f9270-9f33-488b-a6d6-0b441697c50c"), true, true, true, 10, new DateTime(2024, 2, 11, 19, 49, 54, 879, DateTimeKind.Local).AddTicks(797), "Bu otele bayıldım", "Bu otele bayıldım!", new DateTimeOffset(new DateTime(2024, 2, 11, 19, 49, 54, 879, DateTimeKind.Unspecified).AddTicks(799), new TimeSpan(0, 3, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "HotelPolicies",
                columns: new[] { "Id", "CreatedDateTime", "HotelId", "HotelPolicyType", "UpdatedDateTime" },
                values: new object[,]
                {
                    { new Guid("1388b190-db9f-47ec-9ab4-8ff9438ca309"), new DateTimeOffset(new DateTime(2024, 2, 11, 19, 49, 54, 879, DateTimeKind.Unspecified).AddTicks(3047), new TimeSpan(0, 3, 0, 0, 0)), new Guid("459f9270-9f33-488b-a6d6-0b441697c50c"), 13, new DateTimeOffset(new DateTime(2024, 2, 11, 19, 49, 54, 879, DateTimeKind.Unspecified).AddTicks(3060), new TimeSpan(0, 3, 0, 0, 0)) },
                    { new Guid("41341e7b-c984-435b-b607-69877b6a7990"), new DateTimeOffset(new DateTime(2024, 2, 11, 19, 49, 54, 879, DateTimeKind.Unspecified).AddTicks(3078), new TimeSpan(0, 3, 0, 0, 0)), new Guid("459f9270-9f33-488b-a6d6-0b441697c50c"), 22, new DateTimeOffset(new DateTime(2024, 2, 11, 19, 49, 54, 879, DateTimeKind.Unspecified).AddTicks(3079), new TimeSpan(0, 3, 0, 0, 0)) },
                    { new Guid("49909ea1-1cb9-4535-893d-0f96d05dea03"), new DateTimeOffset(new DateTime(2024, 2, 11, 19, 49, 54, 879, DateTimeKind.Unspecified).AddTicks(3067), new TimeSpan(0, 3, 0, 0, 0)), new Guid("459f9270-9f33-488b-a6d6-0b441697c50c"), 55, new DateTimeOffset(new DateTime(2024, 2, 11, 19, 49, 54, 879, DateTimeKind.Unspecified).AddTicks(3069), new TimeSpan(0, 3, 0, 0, 0)) },
                    { new Guid("a04bcb45-5327-4533-b9c5-d035d1188608"), new DateTimeOffset(new DateTime(2024, 2, 11, 19, 49, 54, 879, DateTimeKind.Unspecified).AddTicks(3073), new TimeSpan(0, 3, 0, 0, 0)), new Guid("459f9270-9f33-488b-a6d6-0b441697c50c"), 43, new DateTimeOffset(new DateTime(2024, 2, 11, 19, 49, 54, 879, DateTimeKind.Unspecified).AddTicks(3074), new TimeSpan(0, 3, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "HotelRatings",
                columns: new[] { "Id", "Amenities", "Cleanliness", "CreatedDateTime", "Description", "HotelId", "Location", "ServiceQuality", "Stars", "UpdatedDateTime", "ValueForMoney" },
                values: new object[] { new Guid("91a7887a-4318-4a0a-be4c-55248609e4d6"), 10f, 10f, new DateTimeOffset(new DateTime(2024, 2, 11, 19, 49, 54, 879, DateTimeKind.Unspecified).AddTicks(4909), new TimeSpan(0, 3, 0, 0, 0)), "NULL", new Guid("459f9270-9f33-488b-a6d6-0b441697c50c"), 10f, 10f, 5, new DateTimeOffset(new DateTime(2024, 2, 11, 19, 49, 54, 879, DateTimeKind.Unspecified).AddTicks(4921), new TimeSpan(0, 3, 0, 0, 0)), 10f });

            migrationBuilder.InsertData(
                table: "HotelRooms",
                columns: new[] { "Id", "Capacity", "CreatedDateTime", "HotelId", "RoomType", "UpdatedDateTime" },
                values: new object[,]
                {
                    { new Guid("260e469a-b87f-49e5-8ac8-c36716521552"), 50, new DateTimeOffset(new DateTime(2024, 2, 11, 19, 49, 54, 879, DateTimeKind.Unspecified).AddTicks(6411), new TimeSpan(0, 3, 0, 0, 0)), new Guid("459f9270-9f33-488b-a6d6-0b441697c50c"), 0, new DateTimeOffset(new DateTime(2024, 2, 11, 19, 49, 54, 879, DateTimeKind.Unspecified).AddTicks(6428), new TimeSpan(0, 3, 0, 0, 0)) },
                    { new Guid("69e60e50-08bf-4bdc-95fc-fce558a0ea60"), 80, new DateTimeOffset(new DateTime(2024, 2, 11, 19, 49, 54, 879, DateTimeKind.Unspecified).AddTicks(6445), new TimeSpan(0, 3, 0, 0, 0)), new Guid("459f9270-9f33-488b-a6d6-0b441697c50c"), 5, new DateTimeOffset(new DateTime(2024, 2, 11, 19, 49, 54, 879, DateTimeKind.Unspecified).AddTicks(6447), new TimeSpan(0, 3, 0, 0, 0)) },
                    { new Guid("88f4520b-9c57-4e55-9654-107b926b214b"), 75, new DateTimeOffset(new DateTime(2024, 2, 11, 19, 49, 54, 879, DateTimeKind.Unspecified).AddTicks(6431), new TimeSpan(0, 3, 0, 0, 0)), new Guid("459f9270-9f33-488b-a6d6-0b441697c50c"), 3, new DateTimeOffset(new DateTime(2024, 2, 11, 19, 49, 54, 879, DateTimeKind.Unspecified).AddTicks(6434), new TimeSpan(0, 3, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "HotelServices",
                columns: new[] { "Id", "CreatedDateTime", "HotelId", "HotelServiceType", "UpdatedDateTime" },
                values: new object[,]
                {
                    { new Guid("0097bc87-0623-461f-9479-7b96975fdbc9"), new DateTimeOffset(new DateTime(2024, 2, 11, 19, 49, 54, 879, DateTimeKind.Unspecified).AddTicks(8007), new TimeSpan(0, 3, 0, 0, 0)), new Guid("459f9270-9f33-488b-a6d6-0b441697c50c"), 33, new DateTimeOffset(new DateTime(2024, 2, 11, 19, 49, 54, 879, DateTimeKind.Unspecified).AddTicks(8009), new TimeSpan(0, 3, 0, 0, 0)) },
                    { new Guid("442d1a17-b52d-4226-8c95-5052ce4a51af"), new DateTimeOffset(new DateTime(2024, 2, 11, 19, 49, 54, 879, DateTimeKind.Unspecified).AddTicks(8018), new TimeSpan(0, 3, 0, 0, 0)), new Guid("459f9270-9f33-488b-a6d6-0b441697c50c"), 72, new DateTimeOffset(new DateTime(2024, 2, 11, 19, 49, 54, 879, DateTimeKind.Unspecified).AddTicks(8019), new TimeSpan(0, 3, 0, 0, 0)) },
                    { new Guid("58d6d610-424c-4df1-bda0-02848857920d"), new DateTimeOffset(new DateTime(2024, 2, 11, 19, 49, 54, 879, DateTimeKind.Unspecified).AddTicks(7999), new TimeSpan(0, 3, 0, 0, 0)), new Guid("459f9270-9f33-488b-a6d6-0b441697c50c"), 51, new DateTimeOffset(new DateTime(2024, 2, 11, 19, 49, 54, 879, DateTimeKind.Unspecified).AddTicks(8001), new TimeSpan(0, 3, 0, 0, 0)) },
                    { new Guid("5a7ec8e3-a70a-4058-861c-4457e3e54380"), new DateTimeOffset(new DateTime(2024, 2, 11, 19, 49, 54, 879, DateTimeKind.Unspecified).AddTicks(8013), new TimeSpan(0, 3, 0, 0, 0)), new Guid("459f9270-9f33-488b-a6d6-0b441697c50c"), 8, new DateTimeOffset(new DateTime(2024, 2, 11, 19, 49, 54, 879, DateTimeKind.Unspecified).AddTicks(8014), new TimeSpan(0, 3, 0, 0, 0)) },
                    { new Guid("86aa2b6a-329e-4ddf-a2db-21f8f6932fa6"), new DateTimeOffset(new DateTime(2024, 2, 11, 19, 49, 54, 879, DateTimeKind.Unspecified).AddTicks(7978), new TimeSpan(0, 3, 0, 0, 0)), new Guid("459f9270-9f33-488b-a6d6-0b441697c50c"), 74, new DateTimeOffset(new DateTime(2024, 2, 11, 19, 49, 54, 879, DateTimeKind.Unspecified).AddTicks(7988), new TimeSpan(0, 3, 0, 0, 0)) }
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
