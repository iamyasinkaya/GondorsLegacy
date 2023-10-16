using System.Reflection;
using GondorsLegacy.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;


namespace GondorsLegacy.Services.Reservation.Repositories;

public class ReservationDbContext : DbContextUnitOfWork<ReservationDbContext>
{
    public ReservationDbContext(DbContextOptions<ReservationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Entities.Reservation> Reservations { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()); // Bu, tüm EntityTypeConfiguration sınıflarını tanımınıza ekler.
    }
}