using GondorsLegacy.CrossCuttingCorners.Caching;
using GondorsLegacy.CrossCuttingCorners.Exceptions;
using GondorsLegacy.Services.Reservation.Repositories;
using MediatR;
using Newtonsoft.Json;

namespace GondorsLegacy.Services.Reservation.Queries.Reservation;

public class GetReservationQuery : IRequest<Entities.Reservation>
{
    public Guid Id { get; set; }
    public bool ThrowNotFoundIfNull { get; set; }
}

public class GetReservationQueryHandler : IRequestHandler<GetReservationQuery, Entities.Reservation>
{
    private readonly IReservationRepository _reservationRepository;
    private readonly ICache _cache;
    private readonly ILogger<GetReservationQueryHandler> _logger;

    public GetReservationQueryHandler(IReservationRepository reservationRepository, ICache cache, ILogger<GetReservationQueryHandler> logger)
    {
        _reservationRepository = reservationRepository;
        _cache = cache;
        _logger = logger;
    }

    public async Task<Entities.Reservation> Handle(GetReservationQuery request, CancellationToken cancellationToken)
    {
        var cacheKey = $"Reservation_{request.Id}";

        var reservation = TryGetReservationFromCache(cacheKey);

        if (reservation == null)
        {
            _logger.LogInformation("Reservation not found in cache. Trying to get it from the database.");

            reservation = await TryGetReservationFromDatabase(request);

            if (reservation != null)
            {
                _logger.LogInformation("Reservation retrieved from the database and added to cache.");
            }
            else
            {
                _logger.LogInformation("Reservation not found in the database.");
            }
        }

        if (reservation == null && request.ThrowNotFoundIfNull)
        {
            _logger.LogWarning($"Reservation {request.Id} not found.");

            return reservation;
        }

        return reservation;
    }

    private Entities.Reservation TryGetReservationFromCache(string cacheKey)
    {
        var reservationJson = _cache.Get<string>(cacheKey);

        if (reservationJson != null)
        {
            _logger.LogInformation("Reservation retrieved from cache.");
            return JsonConvert.DeserializeObject<Entities.Reservation>(reservationJson);
        }

        return null;
    }

    private async Task<Entities.Reservation> TryGetReservationFromDatabase(GetReservationQuery request)
    {
        _logger.LogInformation("Fetching reservation from the database.");
        var reservation = await _reservationRepository.FirstOrDefaultAsync(_reservationRepository.GetAll().Where(x => x.Id == request.Id));
        return reservation;
    }
}

