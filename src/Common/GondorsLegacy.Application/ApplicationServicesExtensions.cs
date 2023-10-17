using GondorsLegacy.Application.Common;
using GondorsLegacy.Application.Common.Services;
using Microsoft.Extensions.DependencyInjection;

namespace GondorsLegacy.Application;

public static class ApplicationServicesExtensions
{
    /// <summary>
    /// Uygulama hizmetlerini eklemek için kullanılan uzantı yöntemi.
    /// </summary>
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<Dispatcher>();
        services.AddScoped(typeof(ICrudService<>), typeof(CrudService<>));
        return services;
    }
}


