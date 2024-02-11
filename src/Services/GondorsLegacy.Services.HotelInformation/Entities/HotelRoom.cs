using GondorsLegacy.Domain.Entities;
using GondorsLegacy.Services.HotelInformation.Constants;

namespace GondorsLegacy.Services.HotelInformation.Entities;

public sealed class HotelRoom : Entity<Guid>
{
    public Guid HotelId { get; set; }
    public RoomType RoomType { get; set; }
    public int Capacity { get; set; }

}

