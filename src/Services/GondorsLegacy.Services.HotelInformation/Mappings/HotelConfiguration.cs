using GondorsLegacy.Services.HotelInformation.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GondorsLegacy.Services.HotelInformation.Mappings;

public class HotelConfiguration : IEntityTypeConfiguration<Hotel>
{
    public void Configure(EntityTypeBuilder<Hotel> builder)
    {
        builder.HasKey(h => h.Id);
        builder.Property(h => h.Id).ValueGeneratedOnAdd();
        builder.Property(h => h.Name).IsRequired().HasMaxLength(256);
        builder.Property(h => h.Description).IsRequired().HasMaxLength(2500);
        builder.ToTable("Hotels");

        builder.HasData(
                new Hotel
            {
                Id = Guid.NewGuid(),
                Name = "Salvator Hotel",
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s,",
                CreatedDateTime = DateTimeOffset.UtcNow,
                UpdatedDateTime = DateTimeOffset.UtcNow,
            },
                new Hotel
             {
                 Id = Guid.NewGuid(),
                 Name = "Kelebek Hotel",
                 Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s,",
                 CreatedDateTime = DateTimeOffset.UtcNow,
                 UpdatedDateTime = DateTimeOffset.UtcNow,
             },
                new Hotel
              {
                  Id = Guid.NewGuid(),
                  Name = "Vensure Hotel",
                  Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s,",
                  CreatedDateTime = DateTimeOffset.UtcNow,
                  UpdatedDateTime = DateTimeOffset.UtcNow,
              },
                new Hotel
               {
                   Id = Guid.NewGuid(),
                   Name = "Radisson Hotel",
                   Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s,",
                   CreatedDateTime = DateTimeOffset.UtcNow,
                   UpdatedDateTime = DateTimeOffset.UtcNow,
               },
                new Hotel
                {
                    Id = Guid.NewGuid(),
                    Name = "Koeralop Hotel",
                    Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s,",
                    CreatedDateTime = DateTimeOffset.UtcNow,
                    UpdatedDateTime = DateTimeOffset.UtcNow,
                });
    }
}
