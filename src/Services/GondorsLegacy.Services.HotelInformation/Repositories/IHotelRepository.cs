using GondorsLegacy.Domain.Repositories;

namespace GondorsLegacy.Services.HotelInformation.Repositories;

public interface IHotelRepository : IRepository<Entities.Hotel,Guid>
{
}
