using GondorsLegacy.Infrastructure.Persistence;
using GondorsLegacy.Services.HotelInformation.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace GondorsLegacy.Services.HotelInformation.Repositories
{
    public class HotelDbContext : DbContextUnitOfWork<HotelDbContext>
    {
        public HotelDbContext(DbContextOptions<HotelDbContext> options) : base(options) { }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<HotelCustomerReview> HotelCustomerReviews { get; set; }
        public DbSet<HotelPolicy> HotelPolicies { get; set; }
        public DbSet<HotelRating> HotelRatings { get; set; }
        public DbSet<HotelRoom> HotelRooms { get; set; }
        public DbSet<HotelService> HotelServices { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()); // Bu, tüm EntityTypeConfiguration sınıflarını tanımınıza ekler.
        }
    }
}
