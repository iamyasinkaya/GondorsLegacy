using Castle.DynamicProxy;
using GondorsLegacy.Application.Common.Services;
using GondorsLegacy.CrossCuttingCorners.Caching;
using GondorsLegacy.Infrastructure.Interceptors;
using MediatR;

namespace GondorsLegacy.Services.Reservation.Commands.Guest;

public class CreateGuestCommand : IRequest
{
    public Entities.Guest Guest { get; set; }
}

public class CreateGuestCommandHandler : IRequestHandler<CreateGuestCommand>
{

    private readonly ICrudService<Entities.Guest> _guestService;
    private readonly ICache _cacheService;
    private readonly ILogger<CreateGuestCommand> _logger;
    private readonly IProxyGenerator _proxyGenerator;
    private readonly LoggingInterceptor _interceptor;

    public CreateGuestCommandHandler(ICrudService<Entities.Guest> guestService,
                                           ICache cacheService,
                                           ILogger<CreateGuestCommand> logger,
                                           IProxyGenerator proxyGenerator,
                                           LoggingInterceptor interceptor)
    {
        _guestService = guestService;
        _cacheService = cacheService;
        _logger = logger;
        _proxyGenerator = proxyGenerator;
        _interceptor = interceptor;
    }

    public async Task Handle(CreateGuestCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var proxy = _proxyGenerator.CreateInterfaceProxyWithTarget(_guestService, _interceptor);

            await proxy.AddAsync(request.Guest, cancellationToken);

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
