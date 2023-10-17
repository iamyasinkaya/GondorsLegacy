using GondorsLegacy.Application.Common.Services;
using MediatR;

namespace GondorsLegacy.Services.Reservation.Commands
{
    public class CreateUpdateReservationCommand : IRequest
    {
		public Entities.Reservation Reservation { get; set; }
	}

    public class CreateUpdateReservationCommandHandler : IRequestHandler<CreateUpdateReservationCommand>
    {
        private readonly ICrudService<Entities.Reservation> _reservationService;

        public CreateUpdateReservationCommandHandler(ICrudService<Entities.Reservation> reservationService)
        {
            _reservationService = reservationService;
        }

        public async Task Handle(CreateUpdateReservationCommand request, CancellationToken cancellationToken)
        {
            await _reservationService.AddOrUpdateAsync(request.Reservation);
        }
    }

}

