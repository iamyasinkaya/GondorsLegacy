using GondorsLegacy.CrossCuttingCorners.DateTimes;
using Microsoft.Extensions.DependencyInjection;

namespace GondorsLegacy.Infrastructure.DateTimes;

public static class DateTimeProviderExtensions
{
    public static IServiceCollection AddDateTimeProvider(this IServiceCollection services)
    {
        _ = services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        return services;
    }
}