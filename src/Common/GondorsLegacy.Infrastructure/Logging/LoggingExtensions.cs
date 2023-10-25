using System.Reflection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Configuration;
using Serilog.Events;
using Serilog.Exceptions;
using Serilog.Sinks.Elasticsearch;

namespace GondorsLegacy.Infrastructure.Logging;

public static class LoggingExtensions
{
    public static LoggerConfiguration Elasticsearch(this LoggerSinkConfiguration loggerConfiguration, string elasticsearchUrl, string indexName)
    {
        return loggerConfiguration.Sink(new ElasticsearchSink(new ElasticsearchSinkOptions(new Uri(elasticsearchUrl))
        {
            MinimumLogEventLevel = LogEventLevel.Debug,
            AutoRegisterTemplate = true,
            AutoRegisterTemplateVersion = AutoRegisterTemplateVersion.ESv6,
            IndexFormat = indexName + "-{0:yyyy.MM.dd}",
            InlineFields = true,
            EmitEventFailure = EmitEventFailureHandling.WriteToFailureSink
        }));
    }

    public static IServiceCollection AddElasticsearchLogging(this IServiceCollection services, IWebHostEnvironment env, IConfiguration configuration)
    {
        var assemblyName = Assembly.GetEntryAssembly()?.GetName().Name;
        string elasticsearchUrl = configuration.GetSection("Elasticsearch:Url").Value;
        string indexName = configuration.GetSection("Elasticsearch:IndexName").Value;

        Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()  // İsteğe bağlı, logların konsola da yazılmasını sağlar
            .WriteTo.Elasticsearch(elasticsearchUrl,indexName)
            .Enrich.With<ActivityEnricher>()
            .Enrich.WithMachineName()
            .Enrich.WithEnvironmentUserName()
            .Enrich.WithProperty("Assembly", assemblyName)
            .Enrich.WithProperty("Application", env.ApplicationName)
            .Enrich.WithProperty("EnvironmentName", env.EnvironmentName)
            .Enrich.WithProperty("ContentRootPath", env.ContentRootPath)
            .Enrich.WithProperty("WebRootPath", env.WebRootPath)
            .Enrich.WithExceptionDetails()
            .Enrich.FromLogContext() // Log olaylarına LogContext'ten gelen özellikleri ekler
            .CreateLogger();

        services.AddLogging(loggingBuilder =>
        {
            loggingBuilder.AddSerilog();
        });

        return services;
    }
}
