using GondorsLegacy.Services.HotelInformation.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GondorsLegacy.Services.HotelInformation.Mappings;

public class HotelRoomConfiguration : IEntityTypeConfiguration<HotelRoom>
{
    public void Configure(EntityTypeBuilder<HotelRoom> builder)
    {
        builder.HasKey(x => x.Id);
        builder.ToTable("HotelRooms");
        builder.HasData(new List<HotelRoom>
        {
            new HotelRoom
            {
                Id = Guid.NewGuid(),
                CreatedDateTime = DateTimeOffset.Now,
                Capacity = 50,
                HotelId = new Guid("459f9270-9f33-488b-a6d6-0b441697c50c"),
                RoomType = Constants.RoomType.Single,
                UpdatedDateTime = DateTimeOffset.Now,
            },
            new HotelRoom
            {
                Id = Guid.NewGuid(),
                CreatedDateTime = DateTimeOffset.Now,
                Capacity = 75,
                HotelId = new Guid("459f9270-9f33-488b-a6d6-0b441697c50c"),
                RoomType = Constants.RoomType.Family,
                UpdatedDateTime = DateTimeOffset.Now,
            },
            new HotelRoom
            {
                Id = Guid.NewGuid(),
                CreatedDateTime = DateTimeOffset.Now,
                Capacity = 80,
                HotelId = new Guid("459f9270-9f33-488b-a6d6-0b441697c50c"),
                RoomType = Constants.RoomType.Twin,
                UpdatedDateTime = DateTimeOffset.Now,
            }
        });
    }
}
