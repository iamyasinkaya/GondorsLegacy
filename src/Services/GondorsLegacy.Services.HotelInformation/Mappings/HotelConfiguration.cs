using GondorsLegacy.Services.HotelInformation.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GondorsLegacy.Services.HotelInformation.Mappings;

public class HotelConfiguration : IEntityTypeConfiguration<Hotel>
{
    public void Configure(EntityTypeBuilder<Hotel> builder)
    {
        builder.ToTable("Hotels"); // Veritabanında hangi tabloya karşılık geldiğini belirtiyoruz
        builder.HasKey(h => h.Id); // Id özelliğini birincil anahtar olarak belirtiyoruz

        // Addresses ilişkisi için
        builder.HasMany(h => h.Addresses)
               .WithOne()
               .HasForeignKey(a => a.HotelId)
               .OnDelete(DeleteBehavior.Cascade); // Bağlantılı adres silindiğinde otel de silinsin

        // Diğer ilişkiler için
        builder.HasMany(h => h.Rooms)
               .WithOne()
               .HasForeignKey(r => r.HotelId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(h => h.Services)
               .WithOne()
               .HasForeignKey(s => s.HotelId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(h => h.Policies)
               .WithOne()
               .HasForeignKey(p => p.HotelId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(h => h.HotelCustomerReviews)
               .WithOne()
               .HasForeignKey(r => r.HotelId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(h => h.HotelRatings)
              .WithOne()
              .HasForeignKey(r => r.HotelId)
              .OnDelete(DeleteBehavior.Cascade);




        builder.HasData(new Hotel
        {
            Id = new Guid("459f9270-9f33-488b-a6d6-0b441697c50c"),
            Name = "SALVATOR RESORT HOTEL",
            Description = "Açıklama",
            EmailAddress = "info@salvatorresort.com",
            Phone = "05303288200",
            CreatedDateTime = DateTimeOffset.Now,
            UpdatedDateTime = DateTimeOffset.Now,
            Website = "https://www.salvatorresort.com"
            
        });
    }
}
