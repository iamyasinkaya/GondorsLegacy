namespace GondorsLegacy.Services.Reservation.Mappings;


using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class ReservationConfiguration : IEntityTypeConfiguration<Entities.Reservation>
{
    public void Configure(EntityTypeBuilder<Entities.Reservation> builder)
    {
        builder.HasKey(r => r.Id);
        builder.Property(r => r.Id).ValueGeneratedOnAdd();
        builder.Ignore(r => r.ExtraServices);
        builder.Property(r => r.CustomerName).IsRequired().HasMaxLength(255);
        builder.Property(r => r.CheckInDate).IsRequired();
        builder.Property(r => r.CheckOutDate).IsRequired();
        builder.Property(r => r.RoomType).IsRequired();
        builder.Property(r => r.NumberOfGuests).IsRequired();
        builder.Property(r => r.CustomerEmail).IsRequired().HasMaxLength(255);
        builder.Property(r => r.ReservationStatus).IsRequired();
        builder.Property(r => r.PaymentInformation).HasMaxLength(500);
        builder.Property(r => r.SpecialRequests).HasMaxLength(1000);
        builder.Property(r => r.NumberOfAdults).IsRequired();
        builder.Property(r => r.NumberOfChildren).IsRequired();
        builder.Property(r => r.TaxRate).HasColumnType("decimal(18,2)");
        builder.Property(r => r.ExtraServicePrice).HasColumnType("decimal(18,2)");
        builder.Property(r => r.PaymentStatus).IsRequired();
        builder.Property(r => r.CancellationReason).IsRequired();
        builder.Property(r => r.TotalPrice).HasColumnType("decimal(18,2)").IsRequired();
        builder.Property(r => r.RoomNumber).IsRequired();
        builder.ToTable("Reservations");

        builder.HasData(
            new Entities.Reservation
            {
                Id = Guid.NewGuid(),
                ReservationId = 1,
                CustomerName = "Yasin Çınar SALVATOR",
                CheckInDate = DateTime.Now,
                CheckOutDate = DateTime.Now.AddDays(8),
                RoomType = Constants.RoomType.Deluxe,
                NumberOfGuests = 2,
                TotalPrice = 17500.12M,
                RoomNumber = 501,
                CustomerEmail = "yasin.salvator@gmail.com",
                ReservationStatus = Constants.ReservationStatus.Confirmed,
                PaymentInformation = "Ödendi",
                SpecialRequests = "Internet mutlaka olmalıdır!",
                NumberOfAdults = 2,
                NumberOfChildren = 0,
                TaxRate = 20.00m,
                ExtraServicePrice = 0.00m,
                PaymentStatus = Constants.PaymentStatus.Paid,

            },
            new Entities.Reservation
            {
                Id = Guid.NewGuid(),
                ReservationId = 2,
                CustomerName = "Ahmet ASLAN ÇAKAR",
                CheckInDate = DateTime.Now.AddDays(1),
                CheckOutDate = DateTime.Now.AddDays(4),
                RoomType = Constants.RoomType.Suite,
                NumberOfGuests = 3,
                TotalPrice = 21500.00m,
                RoomNumber = 502,
                CustomerEmail = "ahmet.cakar@gmail.com",
                ReservationStatus = Constants.ReservationStatus.Pending,
                PaymentInformation = "Bekliyor",
                SpecialRequests = "Çocuğum için klozete basamak koyulabilir mi?",
                NumberOfAdults = 2,
                NumberOfChildren = 1,
                TaxRate = 20.00m,
                ExtraServicePrice = 0.00m,
                PaymentStatus = Constants.PaymentStatus.PendingPayment,
            },
            new Entities.Reservation
            {
                Id = Guid.NewGuid(),
                ReservationId = 3,
                CustomerName = "Sibel SAĞLAM",
                CheckInDate = DateTime.Now.AddDays(12),
                CheckOutDate = DateTime.Now.AddDays(17),
                RoomType = Constants.RoomType.Standard,
                NumberOfGuests = 1,
                TotalPrice = 1500.00M,
                RoomNumber = 503,
                CustomerEmail = "ahmet.cakar@gmail.com",
                ReservationStatus = Constants.ReservationStatus.Confirmed,
                PaymentInformation = "Ödendi",
                SpecialRequests = "Sigara kullanılmayan oda olsun.",
                NumberOfAdults = 1,
                NumberOfChildren = 0,
                TaxRate = 20.00m,
                ExtraServicePrice = 0.00m,
                PaymentStatus = Constants.PaymentStatus.Paid,
            });

    }
}
