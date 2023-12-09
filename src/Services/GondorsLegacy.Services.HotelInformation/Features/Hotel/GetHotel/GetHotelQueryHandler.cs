using GondorsLegacy.CrossCuttingCorners.Caching;
using GondorsLegacy.CrossCuttingCorners.Exceptions;
using GondorsLegacy.Services.HotelInformation.Repositories;
using MediatR;
using Newtonsoft.Json;

namespace GondorsLegacy.Services.HotelInformation.Features.Hotel.GetHotel;

public class GetHotelQueryHandler : IRequestHandler<GetHotelQuery, Entities.Hotel>
{
    private readonly IHotelRepository _hotelRepository;
    private readonly ICache _cache;
    private readonly ILogger<GetHotelQueryHandler> _logger;

    public GetHotelQueryHandler(IHotelRepository hotelRepository, ICache cache, ILogger<GetHotelQueryHandler> logger)
    {
        _hotelRepository = hotelRepository;
        _cache = cache;
        _logger = logger;
    }

    public async Task<Entities.Hotel> Handle(GetHotelQuery request, CancellationToken cancellationToken)
    {
        var cacheKey = $"Hotel_{request.Id}";

        var hotel = TryGetHotelFromCache(cacheKey);

        if (hotel is null)
        {
            _logger.LogInformation("Hotel not found in cache. Trying to get it from the database.");

            hotel = await TryGetHotelFromDatabase(request);

            if (hotel is not null)
            {
                _logger.LogInformation("Hotel retrieved from the database and added to cache.");
            }
            else
            {
                _logger.LogInformation("Hotel not found in the database.");
            }
        }

        return hotel;

    }
    private Entities.Hotel TryGetHotelFromCache(string cacheKey)
    {
        var hotelJson = _cache.Get<string>(cacheKey);

        if (hotelJson is not null)
        {
            _logger.LogInformation("Hotel retrieved from cache.");
            return JsonConvert.DeserializeObject<Entities.Hotel>(hotelJson);
        }

        return null;
    }

    private async Task<Entities.Hotel> TryGetHotelFromDatabase(GetHotelQuery request)
    {
        _logger.LogInformation("Fetching hotel from the database.");
        var hotel = await _hotelRepository.FirstOrDefaultAsync(_hotelRepository.GetAll().Where(x => x.Id == request.Id));
        return hotel;
    }
}
