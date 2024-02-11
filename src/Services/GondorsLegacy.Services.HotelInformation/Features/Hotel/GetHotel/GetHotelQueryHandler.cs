using GondorsLegacy.CrossCuttingCorners.Caching;
using GondorsLegacy.CrossCuttingCorners.Exceptions;
using GondorsLegacy.Services.HotelInformation.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace GondorsLegacy.Services.HotelInformation.Features.Hotel.GetHotel
{
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
                _logger.LogInformation("Otel önbellekte bulunamadı. Veritabanından alınmaya çalışılıyor.");

                hotel = await TryGetHotelFromDatabase(request);

                if (hotel is not null)
                {
                    _logger.LogInformation("Otel veritabanından alındı ve önbelleğe eklendi.");
                }
                else
                {
                    _logger.LogInformation("Otel veritabanında bulunamadı.");
                }
            }

            return hotel;
        }

        private Entities.Hotel TryGetHotelFromCache(string cacheKey)
        {
            var hotelJson = _cache.Get<string>(cacheKey);

            if (hotelJson is not null)
            {
                _logger.LogInformation("Otel önbellekten alındı.");
                return JsonConvert.DeserializeObject<Entities.Hotel>(hotelJson);
            }

            return null;
        }

        private async Task<Entities.Hotel> TryGetHotelFromDatabase(GetHotelQuery request) => await _hotelRepository
    .GetAll()
    .Include(x => x.HotelRatings)
    .Include(x => x.HotelCustomerReviews)
    .Include(x => x.Services)
    .Include(x => x.Policies)
    .Include(x => x.Addresses)
    .Include(x => x.Rooms)
    .FirstOrDefaultAsync(x => x.Id == request.Id);

    }
}
