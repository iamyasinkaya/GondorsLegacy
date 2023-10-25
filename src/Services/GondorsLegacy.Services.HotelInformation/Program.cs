using GondorsLegacy.Infrastructure.Contracts;
using GondorsLegacy.Infrastructure.Services;
using GondorsLegacy.Services.HotelInformation.Configuration;
using GondorsLegacy.Services.HotelInformation.Services.Abstract;
using Microsoft.OpenApi.Models;
using Refit;

var builder = WebApplication.CreateBuilder(args);

// Yapılandırmayı oku
var appSettings = builder.Configuration.GetSection("RapidAPI").Get<AppSettings>();

// Refit servisi yapılandırma
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
builder.Services.AddContractsService();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1",new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "API Dokümantasyonu",
        Version = "v1",
        Description = "Otel Bilgilendirme Servisi",
        Contact = new OpenApiContact
        {
            Name = "Yasin Çınar SALVATOR",
            Email = "yasinsalvator@outlook.com",
            Url = new Uri("https://yasinkaya.org")
        }
    });

    c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "GondorsLegacy.Services.HotelInformation.xml"));

});

var app = builder.Build();



if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

