using GondorsLegacy.Services.HotelInformation.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GondorsLegacy.Services.HotelInformation.Mappings;

public class HotelServiceConfiguration : IEntityTypeConfiguration<HotelService>
{
    public void Configure(EntityTypeBuilder<HotelService> builder)
    {
        builder.HasKey(x => x.Id);
        builder.ToTable("HotelServices");
        builder.HasData(new List<HotelService>
        {
            new HotelService
            {
                Id = Guid.NewGuid(),
                HotelId = new Guid("459f9270-9f33-488b-a6d6-0b441697c50c"),
                CreatedDateTime = DateTime.Now,
                UpdatedDateTime = DateTime.Now,
                HotelServiceType = Constants.HotelServiceType.AirConditioning
            },
             new HotelService
            {
                Id = Guid.NewGuid(),
                HotelId = new Guid("459f9270-9f33-488b-a6d6-0b441697c50c"),
                CreatedDateTime = DateTime.Now,
                UpdatedDateTime = DateTime.Now,
                HotelServiceType = Constants.HotelServiceType.AirportLounges
            },
              new HotelService
            {
                Id = Guid.NewGuid(),
                HotelId = new Guid("459f9270-9f33-488b-a6d6-0b441697c50c"),
                CreatedDateTime = DateTime.Now,
                UpdatedDateTime = DateTime.Now,
                HotelServiceType = Constants.HotelServiceType.AirportShuttle
            },
               new HotelService
            {
                Id = Guid.NewGuid(),
                HotelId = new Guid("459f9270-9f33-488b-a6d6-0b441697c50c"),
                CreatedDateTime = DateTime.Now,
                UpdatedDateTime = DateTime.Now,
                HotelServiceType = Constants.HotelServiceType.AirportTransfer
            },
                new HotelService
            {
                Id = Guid.NewGuid(),
                HotelId = new Guid("459f9270-9f33-488b-a6d6-0b441697c50c"),
                CreatedDateTime = DateTime.Now,
                UpdatedDateTime = DateTime.Now,
                HotelServiceType = Constants.HotelServiceType.AssistanceForDisabled
            }
        });
    }
}
