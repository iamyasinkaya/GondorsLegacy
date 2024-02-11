using GondorsLegacy.Services.HotelInformation.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GondorsLegacy.Services.HotelInformation.Mappings;

public class HotelRatingConfiguration : IEntityTypeConfiguration<HotelRating>
{
    public void Configure(EntityTypeBuilder<HotelRating> builder)
    {
        builder.HasKey(x => x.Id);
        builder.ToTable("HotelRatings");

        builder.HasData(new List<HotelRating>
        {
            new HotelRating
            {
                Id = Guid.NewGuid(),
                HotelId = new Guid("459f9270-9f33-488b-a6d6-0b441697c50c"),
                CreatedDateTime = DateTime.Now,
                Stars = 5,
                Description = "NULL",
                Cleanliness = 10,
                ServiceQuality = 10,
                ValueForMoney = 10,
                Location = 10,
                Amenities = 10,
                UpdatedDateTime = DateTime.Now,

            }
        });
    }
}
