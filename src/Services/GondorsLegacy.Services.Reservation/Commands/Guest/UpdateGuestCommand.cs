using AutoMapper;
using Castle.DynamicProxy;
using GondorsLegacy.Application.Common.Services;
using GondorsLegacy.CrossCuttingCorners.Caching;
using GondorsLegacy.CrossCuttingCorners.Exceptions;
using GondorsLegacy.Infrastructure.Interceptors;
using GondorsLegacy.Services.Reservation.Validations;
using MediatR;

namespace GondorsLegacy.Services.Reservation.Commands.Guest;

public class UpdateGuestCommand : IRequest
{
    public Entities.Guest Guest { get; set; }
}

public class UpdateGuestCommandHandler : IRequestHandler<UpdateGuestCommand>
{
    private readonly ICrudService<Entities.Guest> _guestService;
    private readonly ICache _cacheService;
    private readonly ILogger<UpdateGuestCommand> _logger;
    private readonly IProxyGenerator _proxyGenerator;
    private readonly LoggingInterceptor _interceptor;
    private readonly IMapper _mapper;

    public UpdateGuestCommandHandler(ICrudService<Entities.Guest> guestService,
                                     ICache cacheService,
                                     ILogger<UpdateGuestCommand> logger,
                                     IProxyGenerator proxyGenerator,
                                     LoggingInterceptor interceptor,
                                     IMapper mapper)
    {
        _guestService = guestService;
        _cacheService = cacheService;
        _logger = logger;
        _proxyGenerator = proxyGenerator;
        _interceptor = interceptor;
        _mapper = mapper;
    }

    public async Task Handle(UpdateGuestCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var guest = _mapper.Map<Entities.Guest>(request.Guest);

            var validator = new GuestValidator();

            var result = validator.Validate(guest);

            if (result.IsValid)
            {
                var proxy = _proxyGenerator.CreateInterfaceProxyWithTarget(_guestService, _interceptor);

                var oldGuest = proxy.GetByIdAsync(request.Guest.Id, cancellationToken);

                if (oldGuest == null)
                {
                    throw new NotFoundException($"Entity with id {request.Guest.Id} not found");
                }

                oldGuest.Result.Firstname = request.Guest.Firstname;
                oldGuest.Result.Lastname = request.Guest.Lastname;
                oldGuest.Result.PhoneNumber = request.Guest.PhoneNumber;
                oldGuest.Result.DateOfBirth = request.Guest.DateOfBirth;
                oldGuest.Result.EmailAddress = request.Guest.EmailAddress;
                oldGuest.Result.Gender = request.Guest.Gender;

                await proxy.UpdateAsync(oldGuest.Result, cancellationToken);
            }
            else
            {
                IEnumerable<string> errorMessages = result.Errors.Select(x => x.ErrorMessage);

                foreach (var errorMessage in errorMessages)
                {
                    throw new ValidationException(errorMessage);
                }
                
            }

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
