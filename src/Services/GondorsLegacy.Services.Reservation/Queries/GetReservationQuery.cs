using GondorsLegacy.CrossCuttingCorners.Exceptions;
using GondorsLegacy.Services.Reservation.Repositories;
using MediatR;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace GondorsLegacy.Services.Reservation.Queries;

public class GetReservationQuery : IRequest<Entities.Reservation>
{
    public Guid Id { get; set; }
    public bool ThrowNotFoundIfNull { get; set; }
}

public class GetReservationQueryHandler : IRequestHandler<GetReservationQuery, Entities.Reservation>
{
    private readonly IReservationRepository _reservationRepository;

    public GetReservationQueryHandler(IReservationRepository reservationRepository)
    {
        _reservationRepository = reservationRepository;
    }

    public async Task<Entities.Reservation> Handle(GetReservationQuery request, CancellationToken cancellationToken)
    {
        var reservation = await _reservationRepository.FirstOrDefaultAsync(_reservationRepository.GetAll().Where(x => x.Id == request.Id));

        if (request.ThrowNotFoundIfNull &&reservation == null )
        {
            throw new NotFoundException($"Reservation {request.Id} not found.");

        }
        return reservation;
    }
}