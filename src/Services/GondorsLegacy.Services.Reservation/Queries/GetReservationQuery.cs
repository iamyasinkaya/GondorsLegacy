using GondorsLegacy.CrossCuttingCorners.Caching;
using GondorsLegacy.CrossCuttingCorners.Exceptions;
using GondorsLegacy.Services.Reservation.Repositories;
using MediatR;
using Newtonsoft.Json;

namespace GondorsLegacy.Services.Reservation.Queries;

public class GetReservationQuery : IRequest<Entities.Reservation>
{
    public Guid Id { get; set; }
    public bool ThrowNotFoundIfNull { get; set; }
}

public class GetReservationQueryHandler : IRequestHandler<GetReservationQuery, Entities.Reservation>
{
    private readonly IReservationRepository _reservationRepository;
    private readonly ICache _cache;

    public GetReservationQueryHandler(IReservationRepository reservationRepository, ICache cache)
    {
        _reservationRepository = reservationRepository;
        _cache = cache;
    }

    public async Task<Entities.Reservation> Handle(GetReservationQuery request, CancellationToken cancellationToken)
    {
        var cacheKey = $"Reservation_{request.Id}";

        // Öncelikle Redis'ten rezervasyonu almaya çalışın
        var reservationJson = _cache.Get<string>(cacheKey);
        var reservation = JsonConvert.DeserializeObject<Entities.Reservation>(reservationJson);


        if (reservation == null)
        {
            // Redis'te rezervasyon bulunamadı, veritabanından alın
            reservation = await _reservationRepository.FirstOrDefaultAsync(_reservationRepository.GetAll().Where(x => x.Id == request.Id));

            if (request.ThrowNotFoundIfNull)
            {
                throw new NotFoundException($"Reservation {request.Id} not found.");
            }
        }

        return reservation;
    }
}
