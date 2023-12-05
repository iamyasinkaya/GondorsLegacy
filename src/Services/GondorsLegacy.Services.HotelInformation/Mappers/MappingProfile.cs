using AutoMapper;
using GondorsLegacy.Services.HotelInformation.Entities;
using GondorsLegacy.Services.HotelInformation.Features.Hotel;

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
        }
    }
}
