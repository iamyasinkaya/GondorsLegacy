using GondorsLegacy.Domain.Entities;
using GondorsLegacy.Services.HotelInformation.Constants;

namespace GondorsLegacy.Services.HotelInformation.Entities;


public sealed class HotelPolicy : Entity<Guid>
{
    public Guid HotelId { get; set; }
    public HotelPolicyType HotelPolicyType { get; set; }

}
