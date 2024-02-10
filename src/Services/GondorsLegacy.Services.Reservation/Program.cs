using Asp.Versioning;
using GondorsLegacy.Application;
using GondorsLegacy.Infrastructure.Caching;
using GondorsLegacy.Infrastructure.DateTimes;
using GondorsLegacy.Infrastructure.Interceptors;
using GondorsLegacy.Infrastructure.Logging;
using GondorsLegacy.Infrastructure.MessagesBrokers;
using GondorsLegacy.Infrastructure.Web.MinimalApis;
using GondorsLegacy.Services.Reservation;
using GondorsLegacy.Services.Reservation.Commands;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.OpenApi.Models;
using RabbitMQ.Client;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddInterceptors();


builder.Services.AddReservationModule(builder.Configuration);

builder.Services.AddDateTimeProvider();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddApplicationServices();

builder.Services.AddCaches(builder.Configuration);

builder.Services.AddMessageBrokers< CancelReservationCommand>(builder.Configuration);

builder.Services.AddElasticsearchLogging(builder.Environment,builder.Configuration);


builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Reservation API",
        Version = "v1",
        Description = "Reservation API",
        Contact = new OpenApiContact
        {
            Name = "Yasin Kaya",
            Email = "iamyasinkaya@gmail.com",
            Url = new Uri("https://yasinkaya.tech")
        }
    });
    //var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    //var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    //c.IncludeXmlComments(xmlPath);

    // Yetkilendirme tanımını ekleyin
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme.",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Name = "Authorization"
    });

    // Yetkilendirme gereksinimini ekleyin
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] { }

        }
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
{
    {
        new OpenApiSecurityScheme
        {
            Reference = new OpenApiReference
            {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
            }
        },
        new List<string> { "role1", "role2" } // Roller buraya eklenir
    }
});

    c.AddSecurityDefinition("OAuth2", new OpenApiSecurityScheme
    {
        Type = SecuritySchemeType.OAuth2,
        Flows = new OpenApiOAuthFlows
        {
            Implicit = new OpenApiOAuthFlow
            {
                AuthorizationUrl = new Uri("https://example.com/auth"),
                TokenUrl = new Uri("https://example.com/token"),
                Scopes = new Dictionary<string, string>
            {
                { "read", "Read access" },
                { "write", "Write access" }
            }
            }
        }
    });

});

builder.Services.AddHealthChecks()
                .AddSqlServer(builder.Configuration
                .GetConnectionString("ReservationDatabase"))
                .AddRedis("localhost:6379")
                .AddRabbitMQ(options =>
               {
                   options.ConnectionFactory = new ConnectionFactory
                   {
                       HostName = "localhost",
                       Port = 5672,
                       VirtualHost = "localhost",
                       UserName = "",
                       Password = ""
                   };
               });

builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new ApiVersion(1);
    options.ReportApiVersions = true;
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ApiVersionReader = ApiVersionReader.Combine(
        new UrlSegmentApiVersionReader(),
        new HeaderApiVersionReader("X-Api-Version"));
}).AddApiExplorer(options =>
{
    options.GroupNameFormat = "'v'V";
    options.SubstituteApiVersionInUrl = true;
});

var app = builder.Build();



app.MapHealthChecks("/health",
    new HealthCheckOptions
    {
        ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse,
        AllowCachingResponses = false,
        ResultStatusCodes = new Dictionary<HealthStatus, int>
        {
            {HealthStatus.Healthy, 200},
            {HealthStatus.Degraded,503},
            {HealthStatus.Unhealthy, 500}
        }
    });

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Reservation API V1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapEndpointHandlers(Assembly.GetCallingAssembly());

app.Run();

