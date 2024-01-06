using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

namespace GondorsLegacy.Infrastructure.Monitoring.OpenTelemetry
{
    public static class OpenTelemetryExtension
    {
        public static IServiceCollection AddOpenTelemetryExtension(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<OpenTelemetryOptions>(configuration.GetSection("OpenTelemetry"));
            var openTelemetrySource = configuration.GetSection("OpenTelemetry").Get<OpenTelemetryOptions>();
            services.AddOpenTelemetry().WithTracing(builder =>
            {
                builder.AddSource(openTelemetrySource.ActivitySourceName)
                    .ConfigureResource(rsc =>
                    {
                        rsc.AddService(openTelemetrySource.ServiceName, serviceVersion: openTelemetrySource.ServiceVersion);
                    });

                builder.AddAspNetCoreInstrumentation(options =>
                {
                    // Add a filter to only instrument traces for requests with "/api" in the path
                    options.Filter = (httpContext) =>
                    {
                        return httpContext.Request.Path.StartsWithSegments("/api");
                    };
                });

                builder.AddOtlpExporter();
            });

            ActivitySourceProvider.Source = new System.Diagnostics.ActivitySource(openTelemetrySource.ActivitySourceName);
            return services;
        }
    }

}
