
using GondorsLegacy.Services.External;
using Refit;
using Microsoft.Extensions.Options;


var builder = WebApplication.CreateBuilder(args);


var configuration = builder.Configuration;


builder.Services.Configure<LodgifyApiSettings>(configuration.GetSection("LodgifyApiSettings"));


builder.Services.AddRefitClient<ILodgifyApi<Property>>()
    .ConfigureHttpClient((sp, client) =>
    {
        var settings = sp.GetRequiredService<IOptions<LodgifyApiSettings>>().Value;

    
        if (string.IsNullOrEmpty(settings.BaseUrl))
        {
            throw new InvalidOperationException("BaseUrl cannot be null or empty.");
        }

        client.BaseAddress = new Uri(settings.BaseUrl);
        client.DefaultRequestHeaders.Add("X-ApiKey", settings.ApiKey);
        client.DefaultRequestHeaders.Add("accept", settings.AcceptHeader);
    });

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());



builder.Services.AddTransient(typeof(LodgifyAdapter<>));



builder.Services.AddSingleton<ExternalServiceFactory>();


builder.Services.AddControllers();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseRouting();


app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});


app.Run();