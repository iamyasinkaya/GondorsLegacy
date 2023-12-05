using GondorsLegacy.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace GondorsLegacy.Services.HotelInformation.Repositories
{
    public class HotelDbContext : DbContextUnitOfWork<HotelDbContext>
    {
        public HotelDbContext(DbContextOptions<HotelDbContext> options) : base(options) { }

        public DbSet<Entities.Hotel> HotelSet { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()); // Bu, tüm EntityTypeConfiguration sınıflarını tanımınıza ekler.
        }
    }
}
