using AutoMapper;
using GondorsLegacy.Services.Reservation.Endpoints;

namespace GondorsLegacy.Services.Reservation.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateReservationRequest, Entities.Reservation>()
                .ForMember(dest => dest.CreatedDateTime, opt => opt.MapFrom(src => DateTimeOffset.Now))
                .ForMember(dest => dest.UpdatedDateTime, opt => opt.MapFrom(src => DateTimeOffset.Now));
        }
    }

}

