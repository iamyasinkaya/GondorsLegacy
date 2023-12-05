using AutoMapper;
using GondorsLegacy.Domain.Repositories;
using GondorsLegacy.Services.HotelInformation.Mappers;
using GondorsLegacy.Services.HotelInformation.Repositories;
using GondorsLegacy.Services.HotelInformation.Validations;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace GondorsLegacy.Services.HotelInformation;

public static class HotelModuleServiceCollectionExtensions
{
    public static IServiceCollection AddHotelModule(this IServiceCollection services, IConfiguration Configuration)
    {
        services.AddScoped<IRepository<Entities.Hotel,Guid>,Repository<Entities.Hotel,Guid>>();
        services.AddScoped<IHotelRepository,HotelRepository>();
        services.AddDbContext<HotelDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("HotelDatabase")));

        services.AddMediatR(config => config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        services.AddTransient<HotelValidator>();

        // AutoMapper yapılandırması
        var mappingConfig = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new MappingProfile()); // Önceki cevapta oluşturduğumuz profili kullanın
        });

        IMapper mapper = mappingConfig.CreateMapper();

        services.AddSingleton(mapper);


        return services;
    }
    public static void MigrateReservationDb(this IApplicationBuilder app)
    {
        using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
        {
            serviceScope.ServiceProvider.GetRequiredService<HotelDbContext>().Database.Migrate();
        }
    }
}
