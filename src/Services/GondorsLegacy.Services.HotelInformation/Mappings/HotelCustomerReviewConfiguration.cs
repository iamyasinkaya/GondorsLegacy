using GondorsLegacy.Services.HotelInformation.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace GondorsLegacy.Services.HotelInformation.Mappings
{
    public class HotelCustomerReviewConfiguration : IEntityTypeConfiguration<HotelCustomerReview>
    {
        public void Configure(EntityTypeBuilder<HotelCustomerReview> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("HotelCustomerReviews");

            builder.HasData(new List<HotelCustomerReview>()
            {
                new HotelCustomerReview
                {
                    Id = Guid.NewGuid(),
                    CustomerId = Guid.NewGuid(),
                    HotelId =new Guid("459f9270-9f33-488b-a6d6-0b441697c50c"),
                    CreatedDateTime = DateTime.Now,
                    IsHelpful = true,
                    ReviewTitle ="Bu otele bayıldım!",
                    ReviewText = "Bu otele bayıldım",
                    ReviewDate = DateTime.Now,
                    Dislikes = 10,
                    IsRecommended = true,
                    IsVerified = true,
                    Likes = 10,
                    UpdatedDateTime = DateTime.Now,
                    
                },
                new HotelCustomerReview
                {
                    Id = Guid.NewGuid(),
                    CustomerId = Guid.NewGuid(),
                    HotelId = new Guid("459f9270-9f33-488b-a6d6-0b441697c50c"),
                    CreatedDateTime = DateTime.Now,
                    IsHelpful = true,
                    ReviewTitle ="Bu otel güzeldi!",
                    ReviewText = "Bu otele güzeldi",
                    ReviewDate = DateTime.Now,
                    Dislikes = 12,
                    IsRecommended = true,
                    IsVerified = true,
                    Likes = 17,
                    UpdatedDateTime = DateTime.Now,

                }
            });
        }
    }
}
