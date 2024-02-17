using GondorsLegacy.Application;
using GondorsLegacy.Infrastructure.Caching;
using GondorsLegacy.Infrastructure.Contracts;
using GondorsLegacy.Infrastructure.DateTimes;
using GondorsLegacy.Infrastructure.Interceptors;
using GondorsLegacy.Infrastructure.Services;
using GondorsLegacy.Infrastructure.Web.MinimalApis;
using GondorsLegacy.Services.HotelInformation;
using GondorsLegacy.Services.HotelInformation.Configuration;
using GondorsLegacy.Services.HotelInformation.Services.Abstract;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.OpenApi.Models;
using Refit;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Yapılandırmadan 'RapidAPI' bölümünü alıp, AppSettings sınıfına dönüştürür.
var appSettings = builder.Configuration.GetSection("RapidAPI").Get<AppSettings>();

// ApiService ve RefitClient'lar hizmetlere eklenir, yapılandırılır ve RapidAPI anahtarları ayarlanır.
builder.Services.AddApiService(builder.Configuration);
builder.Services.AddRefitClient<IExchangeRateApi>()
    .ConfigureHttpClient(c =>
    {
        c.BaseAddress = new Uri(appSettings.ApiHost);
        c.DefaultRequestHeaders.Add("X-RapidAPI-Key", appSettings.ApiKey);
        c.DefaultRequestHeaders.Add("X-RapidAPI-Host", "apidojo-booking-v1.p.rapidapi.com");
    });

builder.Services.AddRefitClient<IBookingApi>()
    .ConfigureHttpClient(c =>
    {
        c.BaseAddress = new Uri(appSettings.ApiHost);
        c.DefaultRequestHeaders.Add("X-RapidAPI-Key", appSettings.ApiKey);
        c.DefaultRequestHeaders.Add("X-RapidAPI-Host", "apidojo-booking-v1.p.rapidapi.com");
    });

// ContractsService, Controllers, Interceptors, HotelModule ve diğer servisler eklenir.
builder.Services.AddContractsService();
builder.Services.AddControllers();
builder.Services.AddInterceptors();
builder.Services.AddHotelModule(builder.Configuration);
builder.Services.AddDateTimeProvider();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddApplicationServices();
builder.Services.AddCaches(builder.Configuration);

// Swagger belgelendirmesi yapılandırılır.
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "API Dokümantasyonu",
        Version = "v1",
        Description = "Otel Bilgilendirme Servisi",
        Contact = new OpenApiContact
        {
            Name = "Yasin Kaya",
            Email = "iamyasinkaya@gmail.com",
            Url = new Uri("https://yasinkaya.tech")
        }
    });
});

// Sağlık kontrolü eklenir.
builder.Services.AddHealthChecks()
    .AddSqlServer(builder.Configuration.GetConnectionString("HotelDatabase"));

var app = builder.Build();

// '/health' endpoint'ine sağlık kontrolü eklendi.
app.MapHealthChecks("/health",
    new HealthCheckOptions
    {
        ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse,
        AllowCachingResponses = false,
        ResultStatusCodes = new Dictionary<HealthStatus, int>
        {
            {HealthStatus.Healthy, 200},
            {HealthStatus.Degraded, 503},
            {HealthStatus.Unhealthy, 500}
        }
    });

// Geliştirme ortamında Swagger ve Swagger UI kullanılır.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

// Controller'lar ve diğer uygulama işleyicileri eşleştirilir.
app.MapControllers();
app.MapEndpointHandlers(Assembly.GetCallingAssembly());

// Uygulama başlatılır.
app.Run();
