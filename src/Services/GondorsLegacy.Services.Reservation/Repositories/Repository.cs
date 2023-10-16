using GondorsLegacy.CrossCuttingCorners.DateTimes;
using GondorsLegacy.Domain.Entities;
using GondorsLegacy.Infrastructure.Persistence;

namespace GondorsLegacy.Services.Reservation.Repositories;


public class Repository<T, TKey> : DbContextRepository<ReservationDbContext, T, TKey>
    where T : Entity<TKey>
{
    public Repository(ReservationDbContext dbContext, IDateTimeProvider dateTimeProvider)
        : base(dbContext, dateTimeProvider)
    {
    }
}