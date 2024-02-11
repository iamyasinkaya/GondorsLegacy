using GondorsLegacy.Services.HotelInformation.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GondorsLegacy.Services.HotelInformation.Mappings;

public class HotelPolicyConfiguration : IEntityTypeConfiguration<HotelPolicy>
{
    public void Configure(EntityTypeBuilder<HotelPolicy> builder)
    {
        builder.HasKey(x => x.Id);
        builder.ToTable("HotelPolicies");
        builder.HasData(new List<HotelPolicy>
        {
            new HotelPolicy
            {
                Id = Guid.NewGuid(),
                HotelId = new Guid("459f9270-9f33-488b-a6d6-0b441697c50c"),
                CreatedDateTime = DateTime.Now,
                HotelPolicyType = Constants.HotelPolicyType.AirportTransferAvailable,
                UpdatedDateTime = DateTime.Now,
            },
             new HotelPolicy
            {
                Id = Guid.NewGuid(),
                HotelId = new Guid("459f9270-9f33-488b-a6d6-0b441697c50c"),
                CreatedDateTime = DateTime.Now,
                HotelPolicyType = Constants.HotelPolicyType.AllInclusivePackagesAvailable,
                UpdatedDateTime = DateTime.Now,
            },
              new HotelPolicy
            {
                Id = Guid.NewGuid(),
                HotelId = new Guid("459f9270-9f33-488b-a6d6-0b441697c50c"),
                CreatedDateTime = DateTime.Now,
                HotelPolicyType = Constants.HotelPolicyType.BabysittingServicesAvailable,
                UpdatedDateTime = DateTime.Now,
            },
               new HotelPolicy
            {
                Id = Guid.NewGuid(),
                HotelId = new Guid("459f9270-9f33-488b-a6d6-0b441697c50c"),
                CreatedDateTime = DateTime.Now,
                HotelPolicyType = Constants.HotelPolicyType.BarAvailable,
                UpdatedDateTime = DateTime.Now,
            },

        });
    }
}
