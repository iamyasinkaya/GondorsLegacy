using GondorsLegacy.CrossCuttingCorners.DateTimes;
using GondorsLegacy.Domain.Entities;
using GondorsLegacy.Infrastructure.Persistence;

namespace GondorsLegacy.Services.HotelInformation.Repositories;

public class Repository<T, TKey> : DbContextRepository<HotelDbContext, T, TKey>
    where T : Entity<TKey>
{
    public Repository(HotelDbContext dbContext, IDateTimeProvider dateTimeProvider)
        : base(dbContext, dateTimeProvider)
    {
    }
}