using GondorsLegacy.Domain.Repositories;

namespace GondorsLegacy.Services.Reservation.Repositories
{
    public interface IReservationRepository : IRepository<Entities.Reservation,Guid>
	{

	}
}

