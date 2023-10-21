using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;

namespace GondorsLegacy.Infrastructure.Interceptors;

public static class InterceptorServiceCollectionExtensions
{
    public static IServiceCollection AddInterceptors(this IServiceCollection services)
    {
        // Interceptor'ı servis olarak kaydedin
        services.AddScoped<LoggingInterceptor>();

        // DynamicProxy'yi etkinleştirin
        services.AddTransient<IProxyGenerator, ProxyGenerator>();

        return services;
    }
}