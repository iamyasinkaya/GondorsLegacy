using GondorsLegacy.CrossCuttingCorners.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refit;

namespace GondorsLegacy.Infrastructure.Services;

public static class ApiServiceCollectionExtensions
	{
    public static IServiceCollection AddApiService(this IServiceCollection services, IConfiguration configuration)
    {
        string apiHost = configuration["ApiHost"];
        string apiKey = configuration["ApiKey"];

        //TODO: Generic yöntem uygulanacak
        services.AddRefitClient<IApiService>().ConfigureHttpClient(c =>
        {
            c.BaseAddress = new Uri(apiHost);
            c.DefaultRequestHeaders.Add("X-RapidAPI-Key", apiKey);
            c.DefaultRequestHeaders.Add("X-RapidAPI-Host", apiHost);
        });

        services.AddTransient<ApiService>();

        return services;
    }
}


