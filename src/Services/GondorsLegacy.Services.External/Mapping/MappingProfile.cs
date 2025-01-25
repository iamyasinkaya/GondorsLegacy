using AutoMapper;

namespace GondorsLegacy.Services.External;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<GetLodgifyPropertyResponse, Property>()
            .ForMember(dest => dest.ExternalPropertyId, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
            .ReverseMap();
    }
}