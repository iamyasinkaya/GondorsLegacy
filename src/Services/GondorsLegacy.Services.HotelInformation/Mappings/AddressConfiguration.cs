using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GondorsLegacy.Services.HotelInformation.Mappings;

public class AddressConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.HasKey(x=> x.Id);
        builder.ToTable("Addresses");
        builder.HasData(new Address
        {
            Id = Guid.NewGuid(),
            Country = "Türkiye",
            Province = "İstanbul",
            District = "Gaziosmanpaşa",
            City = "İstanbul",
            PostCode = "34100",
            Neighborhood = "Yenidoğan",
            Street = "Kuyu",
            AdditionalInfo = "NULL",
            BuildingNumber = "9",
            Floor = "1",
            ApartmentNumber = "5",
            POBox = "34100",
            Labels = "Özel Mülk",
            Latitude = 34.10000,
            Longitude = 41.5000,
            IsSecure = true,
            CreatedDateTime = DateTimeOffset.Now,
            HotelId = new Guid("459f9270-9f33-488b-a6d6-0b441697c50c"),
            SecurityCode = "f4e465s1",
            UpdatedDateTime = DateTimeOffset.Now,

        });
    }
}
