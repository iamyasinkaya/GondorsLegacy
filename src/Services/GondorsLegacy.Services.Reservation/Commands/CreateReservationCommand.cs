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
                // Attempt to add the reservation to the service
                await _reservationService.AddAsync(request.Reservation);

                // Calculate the time remaining until checkout
                DateTime exitDate = request.Reservation.CheckOutDate;
                TimeSpan timeSpan = exitDate - DateTime.Now;

                // Serialize the reservation object to JSON
                string reservationJson = JsonConvert.SerializeObject(request.Reservation);

                // Log the reservation information
                _logger.LogInformation("Reservation created: {Reservation}", reservationJson);

                // Add the reservation data to the cache with a specified time span
                _cacheService.Add($"Reservation_{request.Reservation.Id}", reservationJson, timeSpan);
            }
            catch (Exception ex)
            {
                // Log any exceptions that occur during the reservation creation process
                _logger.LogError(ex, "Error while handling CreateReservationCommand");
            }
        }
    }

}

