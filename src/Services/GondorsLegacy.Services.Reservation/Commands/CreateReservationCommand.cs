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

        public CreateReservationCommandHandler(ICrudService<Entities.Reservation> reservationService,ICache cacheService)
        {
            _reservationService = reservationService;
            _cacheService = cacheService;
        }

        public async Task Handle(CreateReservationCommand request, CancellationToken cancellationToken)
        {
            bool isReservationServiceSucceeded = false;

            if (cancellationToken.IsCancellationRequested)
            {
                if (request.Reservation.Id != Guid.Empty)
                {
                    await _reservationService.DeleteAsync(request.Reservation,cancellationToken);
                }

                if (_cacheService.Get<Entities.Reservation>(request.Reservation.Id.ToString()) != null)
                {
                    _cacheService.Remove(request.Reservation.Id.ToString());
                }

                return;
            }

            try
            {
                await _reservationService.AddAsync(request.Reservation);
                isReservationServiceSucceeded = true;

                DateTime exitDate = request.Reservation.CheckOutDate;
                TimeSpan timeSpan = exitDate - DateTime.Now;

                string reservationJson = JsonConvert.SerializeObject(request.Reservation);

                _cacheService.Add($"Reservation_{request.Reservation.Id.ToString()}", reservationJson, timeSpan);
            }
            catch (Exception)
            {
                // Veritabanı işlemi başarısız olduğunda veya hata aldığınızda cache'e kayıt edebilirsiniz.
                // Örnek olarak:
                if (!cancellationToken.IsCancellationRequested)
                {
                    DateTime exitDate = request.Reservation.CheckOutDate;
                    TimeSpan timeSpan = exitDate - DateTime.Now;

                    string reservationJson = JsonConvert.SerializeObject(request.Reservation);

                    _cacheService.Add(request.Reservation.Id.ToString(), reservationJson, timeSpan);
                }
            }

            // Geriye düşme (fallback) stratejisi: Eğer veritabanı işlemi başarısız olduysa ve önbellekte kayıt varsa,
            // önbellekten veriyi alarak veritabanına yeniden kaydedin.
            if (!isReservationServiceSucceeded)
            {
                if (!cancellationToken.IsCancellationRequested)
                {
                    var cachedReservation = _cacheService.Get<Entities.Reservation>(request.Reservation.Id.ToString());

                    if (cachedReservation != null)
                    {
                        await _reservationService.AddAsync(cachedReservation);
                    }
                }
            }
        }
    }
}

