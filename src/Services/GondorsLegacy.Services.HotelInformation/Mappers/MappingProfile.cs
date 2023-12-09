using AutoMapper;
using GondorsLegacy.Services.HotelInformation.Entities;
using GondorsLegacy.Services.HotelInformation.Features.Hotel.CreateHotel;
using GondorsLegacy.Services.HotelInformation.Features.Hotel.GetHotel;
using GondorsLegacy.Services.HotelInformation.Features.Hotel.UpdateHotel;

namespace GondorsLegacy.Services.HotelInformation.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Hotel, HotelResponse>()
                .ForMember(dest => dest.HotelId, opt => opt.MapFrom(src => src.Id))
                // Diğer özel eşleştirmeleri buraya ekleyebilirsiniz
                .ReverseMap(); // Gerekirse ters eşleştirmeyi de ekleyebilirsiniz

            CreateMap<Hotel, CreateHotelRequest>()
                .ReverseMap();
            CreateMap<Hotel, UpdateHotelRequest>()
                .ReverseMap();
        }
    }
}
