using GondorsLegacy.Application.Common.Services;
using GondorsLegacy.CrossCuttingCorners.Caching;
using MediatR;
using Newtonsoft.Json;

namespace GondorsLegacy.Services.Reservation.Commands
{
    public class CreateReservationCommand : IRequest
    {
		public Entities.Reservation Reservation { get; set; }
	}

    public class CreateReservationCommandHandler : IRequestHandler<CreateReservationCommand>
    {
        private readonly ICrudService<Entities.Reservation> _reservationService;
        private readonly ICache _cacheService;
        private readonly ILogger<CreateReservationCommand> _logger;

        public CreateReservationCommandHandler(
            ICrudService<Entities.Reservation> reservationService,
            ICache cacheService,
            ILogger<CreateReservationCommand> logger)
        {
            _reservationService = reservationService;
            _cacheService = cacheService;
            _logger = logger;
        }

        public async Task Handle(CreateReservationCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // Reservation eklemeye çalışın
                await _reservationService.AddAsync(request.Reservation);

                // Rezervasyonun sonuna kadar kalan süreyi hesaplayın
                var exitDate = request.Reservation.CheckOutDate;
                var timeSpan = exitDate - DateTime.Now;

                // Rezervasyon nesnesini JSON'a dönüştürün
                var reservationJson = JsonConvert.SerializeObject(request.Reservation);

                // Rezervasyon bilgilerini daha ayrıntılı şekilde kaydedin
                _logger.LogInformation("Reservation created by customer {Id}: {Reservation}", request.Reservation.CustomerId, reservationJson);

                // Önbelleğe rezervasyon verilerini belirli bir süreyle ekleyin
                var cacheKey = $"Reservation_{request.Reservation.CustomerId}";
                _cacheService.Add(cacheKey, reservationJson, timeSpan);
            }
            catch (Exception ex)
            {
                // Hataları daha ayrıntılı bir şekilde ele alın ve uygun log mesajları ekleyin
                _logger.LogError(ex, "Error while handling CreateReservationCommand. customerId: {Id}", request.Reservation.CustomerId);
                throw; // Hata yeniden fırlatılıyor, daha üst seviyede işlenebilir.
            }
        }
    }
}

