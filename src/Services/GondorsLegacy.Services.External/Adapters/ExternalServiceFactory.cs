
namespace GondorsLegacy.Services.External;
public class ExternalServiceFactory
{
    private readonly IServiceProvider _serviceProvider;

    public ExternalServiceFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public IExternalServiceAdapter<T> CreateAdapter<T>(ExternalType externalType)
    {
        switch (externalType)
        {
            case ExternalType.Lodgify:
                return CreateLodgifyAdapter<T>();
            case ExternalType.Hostaway:
                return CreateHostawayAdapter<T>();
            case ExternalType.Guesty:
                return CreateGuestyAdapter<T>();
            default:
                throw new ArgumentOutOfRangeException(nameof(externalType), externalType, "Unsupported external service type.");
        }
    }

    private IExternalServiceAdapter<T> CreateLodgifyAdapter<T>()
    {
        var adapterType = typeof(LodgifyAdapter<>).MakeGenericType(typeof(T));
        return (IExternalServiceAdapter<T>)_serviceProvider.GetRequiredService(adapterType);
    }

    private IExternalServiceAdapter<T> CreateHostawayAdapter<T>()
    {
        var adapterType = typeof(HostawayAdapter<>).MakeGenericType(typeof(T));
        return (IExternalServiceAdapter<T>)_serviceProvider.GetRequiredService(adapterType);
    }

    private IExternalServiceAdapter<T> CreateGuestyAdapter<T>()
    {
        var adapterType = typeof(GuestyAdapter<>).MakeGenericType(typeof(T));
        return (IExternalServiceAdapter<T>)_serviceProvider.GetRequiredService(adapterType);
    }
}
