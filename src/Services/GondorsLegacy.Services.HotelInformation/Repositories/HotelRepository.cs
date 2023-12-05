using GondorsLegacy.CrossCuttingCorners.DateTimes;

namespace GondorsLegacy.Services.HotelInformation.Repositories;

public class HotelRepository : Repository<Entities.Hotel, Guid>, IHotelRepository
{
    public HotelRepository(HotelDbContext dbContext,
                           IDateTimeProvider dateTimeProvider) : base(dbContext, dateTimeProvider)
    {
    }
}
