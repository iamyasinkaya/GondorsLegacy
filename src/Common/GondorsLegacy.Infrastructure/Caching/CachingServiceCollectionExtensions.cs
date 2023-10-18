using GondorsLegacy.CrossCuttingCorners.Caching;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GondorsLegacy.Infrastructure.Caching;

public static class CachingServiceCollectionExtensions
{
    public static IServiceCollection AddCaches(this IServiceCollection services, IConfiguration configuration)
    {
        // Configuration'dan Redis yapılandırma ayarlarını alın
         configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var redisConfiguration = configuration.GetSection("Redis:Configuration").Value;
        var redisInstanceName = configuration.GetSection("Redis:InstanceName").Value;
       

        // Redis önbellek sağlayıcısını yapılandırın
        services.AddStackExchangeRedisCache(options =>
        {
            options.Configuration = redisConfiguration;
            options.InstanceName = redisInstanceName;
        });
        services.AddScoped<ICache, CacheService>();
        return services;
    }
}