using GondorsLegacy.Services.Reservation;
using GondorsLegacy.Infrastructure.DateTimes;
using Microsoft.OpenApi.Models;
using GondorsLegacy.Infrastructure.Web.MinimalApis;
using System.Reflection;
using GondorsLegacy.Application;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();
builder.Services.AddReservationModule(builder.Configuration);
builder.Services.AddDateTimeProvider();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddApplicationServices();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Reservation API",
        Version = "v1",
        Description = "Reservation API",
        Contact = new OpenApiContact
        {
            Name = "Yasin Çınar SALVATOR",
            Email = "yasin.salvator@gmail.com",
            Url = new Uri("https://www.yasinsalvator.com")
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
var app = builder.Build();

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

