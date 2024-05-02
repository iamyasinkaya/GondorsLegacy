using GondorsLegacy.CrossCuttingCorners.Caching;
using GondorsLegacy.CrossCuttingCorners.Exceptions;
using GondorsLegacy.Services.Reservation.Repositories;
using MediatR;
using Newtonsoft.Json;

namespace GondorsLegacy.Services.Reservation.Queries.Reservation;

public class GetReservationByCustomerIdQuery : IRequest<Entities.Reservation>
{
    public Guid CustomerId { get; set; }
    public bool ThrowNotFoundIfNull { get; set; }
}



public class GetReservationByCustomerIdQueryHandler : IRequestHandler<GetReservationByCustomerIdQuery, Entities.Reservation>
{
    private readonly IReservationRepository _reservationRepository;
    private readonly ICache _cache;
    private readonly ILogger<GetReservationByCustomerIdQueryHandler> _logger;

    public GetReservationByCustomerIdQueryHandler(IReservationRepository reservationRepository, ICache cache, ILogger<GetReservationByCustomerIdQueryHandler> logger)
    {
        _reservationRepository = reservationRepository;
        _cache = cache;
        _logger = logger;
    }

    public async Task<Entities.Reservation> Handle(GetReservationByCustomerIdQuery request, CancellationToken cancellationToken)
    {
        var cacheKey = $"Reservation_{request.CustomerId}";
        Entities.Reservation reservation = TryGetReservationFromCache(cacheKey);

        if (reservation == null)
        {
            _logger.LogInformation($"Reservation for CustomerId {request.CustomerId} not found in cache. Trying to get it from the database.");
            reservation = await TryGetReservationFromDatabase(request);

            if (reservation != null)
            {
                _logger.LogInformation($"Reservation for CustomerId {request.CustomerId} retrieved from the database and added to cache.");
            }
            else
            {
                _logger.LogWarning($"Reservation for CustomerId {request.CustomerId} not found in the database.");

                if (!request.ThrowNotFoundIfNull)
                {
                    throw new NotFoundException($"Reservation for CustomerId {request.CustomerId} not found.");
                }
            }
        }

        return reservation;
    }

    private Entities.Reservation TryGetReservationFromCache(string cacheKey)
    {
        var reservationJson = _cache.Get<string>(cacheKey);

        if (reservationJson != null)
        {
            _logger.LogInformation($"Reservation retrieved from cache for key: {cacheKey}");
            return JsonConvert.DeserializeObject<Entities.Reservation>(reservationJson);
        }

        return null;
    }

    private async Task<Entities.Reservation> TryGetReservationFromDatabase(GetReservationByCustomerIdQuery request)
    {
        _logger.LogInformation($"Fetching reservation for CustomerId {request.CustomerId} from the database.");

        var reservation = await _reservationRepository.FirstOrDefaultAsync(_reservationRepository.GetAll().Where(x => x.CustomerId == request.CustomerId));

        return reservation;
    }
}
