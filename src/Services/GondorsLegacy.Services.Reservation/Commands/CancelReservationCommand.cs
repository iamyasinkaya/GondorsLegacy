using Castle.DynamicProxy;
using GondorsLegacy.Application.Common.Services;
using GondorsLegacy.Infrastructure.Interceptors;
using MediatR;

namespace GondorsLegacy.Services.Reservation.Commands;

public class CancelReservationCommand : IRequest
{
    public Guid ReservationId { get; set; }
    public Guid CustomerId { get; set; }
    public bool IsReservationCancelled { get; set; }
}

public class CancelReservationCommandHandler : IRequestHandler<CancelReservationCommand>
{
    private readonly ICrudService<Entities.Reservation> _reservationService;
    private readonly IProxyGenerator _proxyGenerator;
    private readonly LoggingInterceptor _interceptor;

    public CancelReservationCommandHandler(
        ICrudService<Entities.Reservation> reservationService,
        IProxyGenerator proxyGenerator,
        LoggingInterceptor interceptor)
    {
        _reservationService = reservationService;
        _proxyGenerator = proxyGenerator;
        _interceptor = interceptor;
    }

    public async Task Handle(CancelReservationCommand request, CancellationToken cancellationToken)
    {
        try
        {
            // Proxy'i oluşturun
            var proxy = _proxyGenerator.CreateInterfaceProxyWithTarget(_reservationService, _interceptor);

            // Metot çağrısını proxy üzerinden yapın
            var reservation = await proxy.GetByIdAsync(request.ReservationId);

            reservation.IsReservationCancelled = true;

            await proxy.UpdateAsync(reservation);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }

    }
}