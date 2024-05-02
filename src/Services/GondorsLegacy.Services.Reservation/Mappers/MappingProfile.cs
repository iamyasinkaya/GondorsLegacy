using AutoMapper;
using GondorsLegacy.Services.Reservation.Models.Requests.Guest;
using GondorsLegacy.Services.Reservation.Models.Responses.Reservation;

namespace GondorsLegacy.Services.Reservation.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateReservationRequest, Entities.Reservation>()
                .ForMember(dest => dest.CreatedDateTime, opt => opt.MapFrom(src => DateTimeOffset.Now))
                .ForMember(dest => dest.UpdatedDateTime, opt => opt.MapFrom(src => DateTimeOffset.Now));

            CreateMap<CreateGuestRequest, Entities.Guest>()
                .ForMember(dest => dest.CreatedDateTime, opt => opt.MapFrom(src => DateTimeOffset.Now))
                .ForMember(dest => dest.UpdatedDateTime, opt => opt.MapFrom(src => DateTimeOffset.Now));
            CreateMap<UpdateGuestRequest, Entities.Guest>()
                .ForMember(dest => dest.CreatedDateTime, opt => opt.MapFrom(src => DateTimeOffset.Now))
                .ForMember(dest => dest.UpdatedDateTime, opt => opt.MapFrom(src => DateTimeOffset.Now));
        }
    }

}

