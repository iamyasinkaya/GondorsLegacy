using GondorsLegacy.Domain.Entities;

namespace GondorsLegacy.Services.HotelInformation.Entities;

public sealed class Hotel : Entity<Guid>
{
    public string Name { get; set; }
    public string Description { get; set; }
}
