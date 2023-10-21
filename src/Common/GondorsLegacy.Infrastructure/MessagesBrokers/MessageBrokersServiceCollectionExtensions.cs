using GondorsLegacy.CrossCuttingCorners.MessageBrokers.Rabbit;
using GondorsLegacy.Infrastructure.MessagesBrokers.Rabbit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace GondorsLegacy.Infrastructure.MessagesBrokers;

public static class MessageBrokersServiceCollectionExtensions
{
    public static IServiceCollection AddMessageBrokers<T>(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<RabbitMQOptions>(configuration.GetSection("RabbitMQ"));
        services.AddScoped<IPublisher<T>>(provider =>
        {
            var options = provider.GetRequiredService<IOptions<RabbitMQOptions>>().Value;
            return new RabbitMQService<T>(options.HostName, options.QueueName);
        });
        services.AddScoped<IConsumer<T>>(provider =>
        {
            var options = provider.GetRequiredService<IOptions<RabbitMQOptions>>().Value;
            return new RabbitMQService<T>(options.HostName, options.QueueName);
        });
        return services;
    }

}



