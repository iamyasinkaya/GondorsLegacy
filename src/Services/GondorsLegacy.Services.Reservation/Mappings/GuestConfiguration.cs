using GondorsLegacy.Services.Reservation.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GondorsLegacy.Services.Reservation
{
    public class GuestConfiguration : IEntityTypeConfiguration<Guest>
    {
        public void Configure(EntityTypeBuilder<Guest> builder)
        {
            builder.HasKey(g => g.Id);

            // ReservationId alanı bir dış anahtar (foreign key)
            builder.Property(g => g.ReservationId)
                   .IsRequired();

            // Firstname
            builder.Property(g => g.Firstname)
                   .IsRequired()
                   .HasMaxLength(50);

            // Lastname
            builder.Property(g => g.Lastname)
                   .IsRequired()
                   .HasMaxLength(50);

            // Gender
            builder.Property(g => g.Gender)
                   .IsRequired();

            // PhoneNumber
            builder.Property(g => g.PhoneNumber)
                   .IsRequired()
                   .HasMaxLength(11);

            // DateOfBirth
            builder.Property(g => g.DateOfBirth)
                   .IsRequired();

            // EmailAddress
            builder.Property(g => g.EmailAddress)
                   .IsRequired()
                   .HasMaxLength(100);

            // Age
            builder.Ignore(g => g.Age);

            builder.HasData(new Guest
            {
                Id = Guid.NewGuid(),
                Firstname = "Yasin Mirza",
                Lastname = "Kanberoğlu",
                Gender = Gender.Male,
                DateOfBirth = new DateTime(1995, 7, 10),
                EmailAddress = "yasin.kanberoglu@gmail.com",
                PhoneNumber = "05303288200",
                ReservationId = new Guid("b8a07d3e-ca94-4a51-bc7d-ef1db4a566c6"),
                UpdatedDateTime = DateTime.Now,
                CreatedDateTime = DateTime.Now,

            },
                    new Guest
                    {
                        Id = Guid.NewGuid() ,
                        Firstname = "Aslı",
                        Lastname = "Kanberoğlu",
                        Gender = Gender.Male,
                        DateOfBirth = new DateTime(1994, 1, 8),
                        EmailAddress = "asli.kanberoglu@gmail.com",
                        PhoneNumber = "05303288201",
                        ReservationId = new Guid("b8a07d3e-ca94-4a51-bc7d-ef1db4a566c6"),
                        UpdatedDateTime = DateTime.Now,
                        CreatedDateTime = DateTime.Now,
                    });
        }
    }
}
