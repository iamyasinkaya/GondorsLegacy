using Castle.DynamicProxy;
using GondorsLegacy.Application.Common.Services;
using GondorsLegacy.CrossCuttingCorners.MessageBrokers.Rabbit;
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
    private readonly IPublisher<CancelReservationCommand> _publisher;

    public CancelReservationCommandHandler(
        ICrudService<Entities.Reservation> reservationService,
        IProxyGenerator proxyGenerator,
        LoggingInterceptor interceptor,
        IPublisher<CancelReservationCommand> publisher)
    {
        _reservationService = reservationService;
        _proxyGenerator = proxyGenerator;
        _interceptor = interceptor;
        _publisher = publisher;
    }

    public async Task Handle(CancelReservationCommand request, CancellationToken cancellationToken)
    {
        try
        {
            // Proxy'i oluşturun
            var proxy = _proxyGenerator.CreateInterfaceProxyWithTarget(_reservationService, _interceptor);

            // Rezervasyonu proxy üzerinden alın
            var reservation = await proxy.GetByIdAsync(request.ReservationId);

            // Eğer rezervasyon daha önce iptal edilmediyse işlemi yapın
            if (!reservation.IsReservationCancelled)
            {
                // İptal işaretini true yapın
                reservation.IsReservationCancelled = true;

                // Rezervasyonu güncelleyin
                await proxy.UpdateAsync(reservation);

                _publisher.Publish(request);
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

}