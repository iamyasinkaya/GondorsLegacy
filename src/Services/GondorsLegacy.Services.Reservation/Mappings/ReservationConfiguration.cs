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
                Id = Guid.NewGuid(),
                CustomerId = Guid.NewGuid(),
                CustomerFirstName = "Yasin Çınar",
                CustomerLastName = "SALVATOR",
                CheckInDate = DateTime.Now,
                CheckOutDate = DateTime.Now.AddDays(8),
                RoomType = Constants.RoomType.Deluxe,
                NumberOfGuests = 2,
                TotalPrice = 17500.12M,
                RoomNumber = 501,
                CustomerEmail = "yasin.salvator@gmail.com",
                ReservationStatus = Constants.ReservationStatus.Confirmed,
                SpecialRequests = "Internet mutlaka olmalıdır!",
                NumberOfAdults = 2,
                NumberOfChildren = 0,
                PaymentStatus = Constants.PaymentStatus.Paid,

            },
            new Entities.Reservation
            {
                Id = Guid.NewGuid(),
                CustomerId = Guid.NewGuid(),
                CustomerFirstName = "Ahmet ASLAN ",
                CustomerLastName = "ÇAKAR",
                CheckInDate = DateTime.Now.AddDays(1),
                CheckOutDate = DateTime.Now.AddDays(4),
                RoomType = Constants.RoomType.Suite,
                NumberOfGuests = 3,
                TotalPrice = 21500.00m,
                RoomNumber = 502,
                CustomerEmail = "ahmet.cakar@gmail.com",
                ReservationStatus = Constants.ReservationStatus.Pending,
                SpecialRequests = "Çocuğum için klozete basamak koyulabilir mi?",
                NumberOfAdults = 2,
                NumberOfChildren = 1,
                PaymentStatus = Constants.PaymentStatus.PendingPayment,
            },
            new Entities.Reservation
            {
                Id = Guid.NewGuid(),
                CustomerId = Guid.NewGuid(),
                CustomerFirstName = "Sibel",
                CustomerLastName = "SAĞLAM",
                CheckInDate = DateTime.Now.AddDays(12),
                CheckOutDate = DateTime.Now.AddDays(17),
                RoomType = Constants.RoomType.Standard,
                NumberOfGuests = 1,
                TotalPrice = 1500.00M,
                RoomNumber = 503,
                CustomerEmail = "ahmet.cakar@gmail.com",
                ReservationStatus = Constants.ReservationStatus.Confirmed,
                SpecialRequests = "Sigara kullanılmayan oda olsun.",
                NumberOfAdults = 1,
                NumberOfChildren = 0,
                PaymentStatus = Constants.PaymentStatus.Paid,
            },
            new Entities.Reservation
            {
                Id = Guid.NewGuid(),
                CustomerId = Guid.NewGuid(),
                CustomerFirstName = "John Doe",
                CustomerLastName = "Doe",
                CheckInDate = DateTime.Now.AddDays(1),
                CheckOutDate = DateTime.Now.AddDays(3),
                RoomType = Constants.RoomType.Standard,
                NumberOfGuests = 1,
                TotalPrice = 8000.50M,
                RoomNumber = 101,
                CustomerEmail = "john.doe@example.com",
                ReservationStatus = Constants.ReservationStatus.Confirmed,
                SpecialRequests = "Need a quiet room.",
                NumberOfAdults = 1,
                NumberOfChildren = 0,
                PaymentStatus = Constants.PaymentStatus.Paid,

            },
            new Entities.Reservation
    {
        Id = Guid.NewGuid(),
        CustomerId = Guid.NewGuid(),
        CustomerFirstName = "Jane Doe",
        CustomerLastName = "Doe",
        CheckInDate = DateTime.Now.AddDays(1),
        CheckOutDate = DateTime.Now.AddDays(7),
        RoomType = Constants.RoomType.Deluxe,
        NumberOfGuests = 2,
        TotalPrice = 22000.00M,
        RoomNumber = 502,
        CustomerEmail = "jane.doe@example.com",
        ReservationStatus = Constants.ReservationStatus.Confirmed,
        SpecialRequests = "Need a room with a view.",
        NumberOfAdults = 2,
        NumberOfChildren = 0,
        PaymentStatus = Constants.PaymentStatus.Paid,

    },
            new Entities.Reservation
    {
        Id = Guid.NewGuid(),
        CustomerId = Guid.NewGuid(),
        CustomerFirstName = "Peter Parker",
        CustomerLastName = "Parker",
        CheckInDate = DateTime.Now.AddDays(2),
        CheckOutDate = DateTime.Now.AddDays(5),
        RoomType = Constants.RoomType.Suite,
        NumberOfGuests = 4,
        TotalPrice = 35000.75M,
        RoomNumber = 603,
        CustomerEmail = "peter.parker@example.com",
        ReservationStatus = Constants.ReservationStatus.Pending,
        SpecialRequests = "Need a room with two double beds.",
        NumberOfAdults = 2,
        NumberOfChildren = 2,
        PaymentStatus = Constants.PaymentStatus.PendingPayment,

    },
            new Entities.Reservation
    {
        Id = Guid.NewGuid(),
        CustomerId = Guid.NewGuid(),
        CustomerFirstName = "Ali Yılmaz",
        CustomerLastName = "Yılmaz",
        CheckInDate = DateTime.Now.AddDays(3),
        CheckOutDate = DateTime.Now.AddDays(5),
        RoomType = Constants.RoomType.Suite,
        NumberOfGuests = 3,
        TotalPrice = 45000.00M,
        RoomNumber = 701,
        CustomerEmail = "ali.yilmaz@example.com",
        ReservationStatus = Constants.ReservationStatus.Canceled,
        SpecialRequests = "Need a room with a balcony.",
        NumberOfAdults = 2,
        NumberOfChildren = 1,
        PaymentStatus = Constants.PaymentStatus.Refunded,

    },
            new Entities.Reservation
    {
        Id = Guid.NewGuid(),
        CustomerId = Guid.NewGuid(),
        CustomerFirstName = "Ayşegül Aktaş",
        CustomerLastName = "Aktaş",
        CheckInDate = DateTime.Now.AddDays(6),
        CheckOutDate = DateTime.Now.AddDays(9),
        RoomType = Constants.RoomType.Standard,
        NumberOfGuests = 1,
        TotalPrice = 10000.00M,
        RoomNumber = 201,
        CustomerEmail = "aysegul.aktas@example.com",
        ReservationStatus = Constants.ReservationStatus.Confirmed,
        SpecialRequests = "Need a room with a wheelchair accessible bathroom.",
        NumberOfAdults = 1,
        NumberOfChildren = 0,
        PaymentStatus = Constants.PaymentStatus.Paid,

    },
            new Entities.Reservation
    {
        Id = Guid.NewGuid(),
        CustomerId = Guid.NewGuid(),
        CustomerFirstName = "Mehmet Özdemir",
        CustomerLastName = "Özdemir",
        CheckInDate = DateTime.Now.AddDays(7),
        CheckOutDate = DateTime.Now.AddDays(10),
        RoomType = Constants.RoomType.Deluxe,
        NumberOfGuests = 2,
        TotalPrice = 25000.00M,
        RoomNumber = 402,
        CustomerEmail = "mehmet.ozdemir@example.com",
        ReservationStatus = Constants.ReservationStatus.Confirmed,
        SpecialRequests = "Need a room with a king-sized bed.",
        NumberOfAdults = 2,
        NumberOfChildren = 0,
        PaymentStatus = Constants.PaymentStatus.Paid,

    },
            new Entities.Reservation
    {
        Id = Guid.NewGuid(),
        CustomerId = Guid.NewGuid(),
        CustomerFirstName = "John Doe",
        CustomerLastName = "Doe",
        CheckInDate = DateTime.Now.AddDays(1),
        CheckOutDate = DateTime.Now.AddDays(3),
        RoomType = Constants.RoomType.Standard,
        NumberOfGuests = 1,
        TotalPrice = 8000.50M,
        RoomNumber = 101,
        CustomerEmail = "john.doe@example.com",
        ReservationStatus = Constants.ReservationStatus.Pending,
        SpecialRequests = "Need a quiet room.",
        NumberOfAdults = 1,
        NumberOfChildren = 0,
        PaymentStatus = Constants.PaymentStatus.PendingPayment,

    },
            new Entities.Reservation
    {
        Id = Guid.NewGuid(),
        CustomerId = Guid.NewGuid(),
        CustomerFirstName = "Jane Doe",
        CustomerLastName = "Doe",
        CheckInDate = DateTime.Now.AddDays(1),
        CheckOutDate = DateTime.Now.AddDays(7),
        RoomType = Constants.RoomType.Deluxe,
        NumberOfGuests = 2,
        TotalPrice = 22000.00M,
        RoomNumber = 502,
        CustomerEmail = "jane.doe@example.com",
        ReservationStatus = Constants.ReservationStatus.Confirmed,
        SpecialRequests = "Need a room with a view.",
        NumberOfAdults = 2,
        NumberOfChildren = 0,
        PaymentStatus = Constants.PaymentStatus.Paid,

    },
            new Entities.Reservation
    {
        Id = Guid.NewGuid(),
        CustomerId = Guid.NewGuid(),
        CustomerFirstName = "Peter Parker",
        CustomerLastName = "Parker",
        CheckInDate = DateTime.Now.AddDays(2),
        CheckOutDate = DateTime.Now.AddDays(5),
        RoomType = Constants.RoomType.Suite,
        NumberOfGuests = 4,
        TotalPrice = 35000.75M,
        RoomNumber = 603,
        CustomerEmail = "peter.parker@example.com",
        ReservationStatus = Constants.ReservationStatus.Pending,
        SpecialRequests = "Need a room with two double beds.",
        NumberOfAdults = 2,
        NumberOfChildren = 2,
        PaymentStatus = Constants.PaymentStatus.PendingPayment,

    });

    }
}
