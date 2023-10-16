using Microsoft.Extensions.DependencyInjection;

namespace GondorsLegacy.Application;

public static class ApplicationServicesExtensions
{
    /// <summary>
    /// Uygulama hizmetlerini eklemek için kullanılan uzantı yöntemi.
    /// </summary>
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        return services;
    }
}


