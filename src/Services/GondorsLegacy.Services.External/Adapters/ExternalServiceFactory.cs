
namespace GondorsLegacy.Services.External;
public class ExternalServiceFactory
{
    private readonly IServiceProvider _serviceProvider;

    /// <summary>
    /// Creates adapters for external services such as Lodgify, Hostaway and Guesty.
    /// </summary>
    /// <param name="serviceProvider">The service provider to use to create the adapters.</param>
    public ExternalServiceFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    /// <summary>
    /// Creates an external service adapter for the given <paramref name="externalType"/>.
    /// </summary>
    /// <typeparam name="T">The type of the adapter.</typeparam>
    /// <param name="externalType">The external service type to create the adapter for.</param>
    /// <returns>The external service adapter.</returns>
    /// <exception cref="ArgumentOutOfRangeException">The <paramref name="externalType"/> is not supported.</exception>
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

    /// <summary>
    /// Creates an external service adapter for Lodgify.
    /// </summary>
    /// <typeparam name="T">The type of the adapter.</typeparam>
    /// <returns>The Lodgify external service adapter.</returns>
    private IExternalServiceAdapter<T> CreateLodgifyAdapter<T>()
    {
        var adapterType = typeof(LodgifyAdapter<>).MakeGenericType(typeof(T));
        return (IExternalServiceAdapter<T>)_serviceProvider.GetRequiredService(adapterType);
    }

    /// <summary>
    /// Creates an external service adapter for Hostaway.
    /// </summary>
    /// <typeparam name="T">The type of the adapter.</typeparam>
    /// <returns>The Hostaway external service adapter.</returns>

    private IExternalServiceAdapter<T> CreateHostawayAdapter<T>()
    {
        var adapterType = typeof(HostawayAdapter<>).MakeGenericType(typeof(T));
        return (IExternalServiceAdapter<T>)_serviceProvider.GetRequiredService(adapterType);
    }

    /// <summary>
    /// Creates an external service adapter for Guesty.
    /// </summary>
    /// <typeparam name="T">The type of the adapter.</typeparam>
    /// <returns>The Guesty external service adapter.</returns>
    private IExternalServiceAdapter<T> CreateGuestyAdapter<T>()
    {
        var adapterType = typeof(GuestyAdapter<>).MakeGenericType(typeof(T));
        return (IExternalServiceAdapter<T>)_serviceProvider.GetRequiredService(adapterType);
    }
}
