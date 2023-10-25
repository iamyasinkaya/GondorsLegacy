using GondorsLegacy.CrossCuttingCorners.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace GondorsLegacy.Infrastructure.Contracts
{
    public static class ContractsServiceCollectionExtensions
	{
        public static IServiceCollection AddContractsService(this IServiceCollection services)
        {
            services.AddSingleton(typeof(IRetryPolicy<>), typeof(RetryPolicy<>));

            return services;
        }


    }
}

