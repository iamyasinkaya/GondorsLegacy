using GondorsLegacy.CrossCuttingCorners.DateTimes;

namespace GondorsLegacy.Services.Reservation.Repositories;

public class GuestRepository : Repository<Entities.Guest, Guid>, IGuestRepository
{
    public GuestRepository(ReservationDbContext dbContext, IDateTimeProvider dateTimeProvider) : base(dbContext, dateTimeProvider)
    {
    }
}
