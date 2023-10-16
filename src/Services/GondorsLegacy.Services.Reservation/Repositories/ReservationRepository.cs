using GondorsLegacy.CrossCuttingCorners.DateTimes;

namespace GondorsLegacy.Services.Reservation.Repositories
{
    public class ReservationRepository : Repository<Entities.Reservation,Guid>, IReservationRepository
    {
		public ReservationRepository(ReservationDbContext dbContext, IDateTimeProvider dateTimeProvider) : base(dbContext,dateTimeProvider)
		{

		}
	}
}

