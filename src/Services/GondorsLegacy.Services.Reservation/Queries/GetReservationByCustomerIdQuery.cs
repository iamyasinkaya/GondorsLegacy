using GondorsLegacy.CrossCuttingCorners.Caching;
using GondorsLegacy.CrossCuttingCorners.Exceptions;
using GondorsLegacy.Services.Reservation.Repositories;
using MediatR;
using Newtonsoft.Json;

namespace GondorsLegacy.Services.Reservation.Queries;

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

        // Öncelikle Redis'ten rezervasyonu almaya çalışın
        var reservationJson = _cache.Get<string>(cacheKey);
        var reservation = JsonConvert.DeserializeObject<Entities.Reservation>(reservationJson);

        if (reservation == null)
        {
            // Redis'te rezervasyon bulunamadı, veritabanından alın
            reservation = await _reservationRepository.FirstOrDefaultAsync(_reservationRepository.GetAll().Where(x => x.CustomerId == request.CustomerId));

            if (request.ThrowNotFoundIfNull)
            {
                _logger.LogError($"Reservation for CustomerId {request.CustomerId} not found.");
                throw new NotFoundException($"Reservation for CustomerId {request.CustomerId} not found.");
            }
            else
            {
                _logger.LogInformation($"Reservation for CustomerId {request.CustomerId} not found in cache or database.");
            }
        }
        else
        {
            _logger.LogInformation($"Reservation for CustomerId {request.CustomerId} found in cache.");
        }

        return reservation;
    }
}
