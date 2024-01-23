using AutoMapper;
using GondorsLegacy.Domain.Repositories;
using GondorsLegacy.Infrastructure.Monitoring.OpenTelemetry;
using GondorsLegacy.Services.Reservation.Mappers;
using GondorsLegacy.Services.Reservation.RateLimiterPolicies;
using GondorsLegacy.Services.Reservation.Repositories;
using GondorsLegacy.Services.Reservation.Validations;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace GondorsLegacy.Services.Reservation;

public static class ReservationModuleServiceCollectionExtensions
{
    public static IServiceCollection AddReservationModule(this IServiceCollection services, IConfiguration Configuration)
    {
        services.AddScoped<IRepository<Entities.Reservation, Guid>, Repository<Entities.Reservation, Guid>>();
        services.AddScoped<IReservationRepository, ReservationRepository>();
        services.AddDbContext<ReservationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ReservationDatabase")));

        services.AddMediatR(config => config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        services.AddTransient<ReservationValidator>();

        // AutoMapper yapılandırması
        var mappingConfig = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new MappingProfile()); // Önceki cevapta oluşturduğumuz profili kullanın
        });

        IMapper mapper = mappingConfig.CreateMapper();

        services.AddSingleton(mapper);

        services.AddOpenTelemetryExtension(Configuration);

        services.AddRateLimiter(options =>
        {
            options.AddPolicy<string, DefaultRateLimiterPolicy>(RateLimiterPolicyNames.DefaultPolicy);
        });

        return services;
    }

    public static void MigrateReservationDb(this IApplicationBuilder app)
    {
        using(var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
        {
            serviceScope.ServiceProvider.GetRequiredService<ReservationDbContext>().Database.Migrate();
        }
    }
}

