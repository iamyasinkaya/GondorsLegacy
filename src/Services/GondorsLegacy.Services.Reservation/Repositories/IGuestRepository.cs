using GondorsLegacy.Domain.Repositories;

namespace GondorsLegacy.Services.Reservation.Repositories;

public interface IGuestRepository : IRepository<Entities.Guest, Guid>
{
}
