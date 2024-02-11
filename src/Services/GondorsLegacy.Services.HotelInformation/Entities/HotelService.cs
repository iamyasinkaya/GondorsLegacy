using GondorsLegacy.Domain.Entities;
using GondorsLegacy.Services.HotelInformation.Constants;

namespace GondorsLegacy.Services.HotelInformation.Entities;

public sealed class HotelService : Entity<Guid>
{
    public Guid HotelId { get; set; }
    public HotelServiceType HotelServiceType { get; set; }
}

