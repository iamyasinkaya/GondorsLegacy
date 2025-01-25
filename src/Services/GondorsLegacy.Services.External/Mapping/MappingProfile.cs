using AutoMapper;

namespace GondorsLegacy.Services.External
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<GetLodgifyPropertyResponse, Property>()
                .ForMember(dest => dest.ExternalPropertyId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
                .ForMember(dest => dest.HideAddress, opt => opt.MapFrom(src => src.HideAddress))
                .ForMember(dest => dest.Zip, opt => opt.MapFrom(src => src.Zip))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City))
                .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.State))
                .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Country))
                .ForMember(dest => dest.Rating, opt => opt.MapFrom(src => src.Rating))
                .ForMember(dest => dest.Currency, opt => opt.MapFrom(src => src.CurrencyCode))
                .ForMember(dest => dest.IsAvailable, opt => opt.MapFrom(src => src.IsActive))
                .ForMember(dest => dest.PropertyImagesUrl, opt => opt.MapFrom(src => src.ImageUrl))
                .ForMember(dest => dest.DateListed, opt => opt.MapFrom(src => src.CreatedAt))
                .ForMember(dest => dest.OwnerName, opt => opt.Ignore())
                .ForMember(dest => dest.OwnerContact, opt => opt.Ignore())
                .ForMember(dest => dest.PhoneNumber, opt => opt.Ignore())
                .ForMember(dest => dest.Email, opt => opt.Ignore())
                .ForMember(dest => dest.Website, opt => opt.Ignore())
                .ForMember(dest => dest.MaxGuests, opt => opt.Ignore())
                .ForMember(dest => dest.Bedrooms, opt => opt.Ignore())
                .ForMember(dest => dest.Bathrooms, opt => opt.Ignore())
                .ForMember(dest => dest.TotalAreaInSqFt, opt => opt.Ignore())
                .ForMember(dest => dest.IsPetFriendly, opt => opt.Ignore())
                .ForMember(dest => dest.PropertyType, opt => opt.Ignore())
                .ForMember(dest => dest.Amenities, opt => opt.Ignore())
                .ForMember(dest => dest.CheckInTime, opt => opt.Ignore())
                .ForMember(dest => dest.CheckOutTime, opt => opt.Ignore())
                .ForMember(dest => dest.IsVerified, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
