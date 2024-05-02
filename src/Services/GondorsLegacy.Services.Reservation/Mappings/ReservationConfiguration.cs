namespace GondorsLegacy.Services.Reservation.Mappings;


using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class ReservationConfiguration : IEntityTypeConfiguration<Entities.Reservation>
{
    public void Configure(EntityTypeBuilder<Entities.Reservation> builder)
    {
        builder.HasKey(r => r.Id);
        builder.Property(r => r.Id).ValueGeneratedOnAdd();
        builder.Property(r => r.CustomerFirstName).IsRequired().HasMaxLength(255);
        builder.Property(r => r.CustomerLastName).IsRequired().HasMaxLength(255);
        builder.Property(r => r.HotelId).IsRequired();
        builder.Property(r => r.HotelName).IsRequired();
        builder.Property(r => r.CheckInDate).IsRequired();
        builder.Property(r => r.CheckOutDate).IsRequired();
        builder.Property(r => r.RoomType).IsRequired();
        builder.Property(r => r.NumberOfGuests).IsRequired();
        builder.Property(r => r.CustomerEmail).IsRequired().HasMaxLength(255);
        builder.Property(r => r.ReservationStatus).IsRequired();
        builder.Property(r => r.SpecialRequests).HasMaxLength(1000);
        builder.Property(r => r.NumberOfAdults).IsRequired();
        builder.Property(r => r.NumberOfChildren).IsRequired();
        builder.Property(r => r.PaymentStatus).IsRequired();
        builder.Property(r => r.CancellationReason).IsRequired();
        builder.Property(r => r.TotalPrice).HasColumnType("decimal(18,2)").IsRequired();
        builder.Property(r => r.RoomNumber).IsRequired();
        builder.ToTable("Reservations");

        builder.HasData(
            new Entities.Reservation
            {
                Id = new Guid("b8a07d3e-ca94-4a51-bc7d-ef1db4a566c6"),
                CustomerId = new Guid("af7a41ad-bb23-4237-9177-211cc0541d2c"),
                CustomerFirstName = "Yasin Mirza",
                CustomerLastName = "Kanberoğlu",
                HotelId = new Guid("fa6284cf-9614-4b4d-95fe-5e630c7c8e2e"),
                HotelName = "Hilton Otel",
                CheckInDate = DateTime.Now,
                CheckOutDate = DateTime.Now.AddDays(8),
                RoomType = Constants.RoomType.Deluxe,
                NumberOfGuests = 2,
                TotalPrice = 17500.12M,
                RoomNumber = 501,
                CustomerEmail = "yasin.kanberoglu@gmail.com",
                ReservationStatus = Constants.ReservationStatus.Confirmed,
                SpecialRequests = "Internet mutlaka olmalıdır!",
                NumberOfAdults = 2,
                NumberOfChildren = 0,
                PaymentStatus = Constants.PaymentStatus.Paid,
                UpdatedDateTime = DateTime.Now

            });
    }
}
