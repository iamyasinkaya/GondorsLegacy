using AutoMapper;
using GondorsLegacy.Domain.Repositories;
using GondorsLegacy.Infrastructure.Monitoring.OpenTelemetry;
using GondorsLegacy.Services.HotelInformation.Mappers;
using GondorsLegacy.Services.HotelInformation.RateLimiterPolicies;
using GondorsLegacy.Services.HotelInformation.Repositories;
using GondorsLegacy.Services.HotelInformation.Validations;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace GondorsLegacy.Services.HotelInformation;

public static class HotelModuleServiceCollectionExtensions
{
    public static IServiceCollection AddHotelModule(this IServiceCollection services, IConfiguration Configuration)
    {
        // IRepository arayüzünü ve Entities.Hotel tipi ile eşleştiren ve bu eşleştirmeyi yaparken Repository sınıfını kullanan bir hizmet tanımlama
        services.AddScoped<IRepository<Entities.Hotel, Guid>, Repository<Entities.Hotel, Guid>>();

        // IHotelRepository arayüzünü ve HotelRepository sınıfı ile eşleştiren bir hizmet tanımlama
        services.AddScoped<IHotelRepository, HotelRepository>();

        // HotelDbContext tipini kullanarak bir DbContext eklemek
        services.AddDbContext<HotelDbContext>(options =>
        {
            // SQL Server veritabanı bağlantısını yapılandırma
            options.UseSqlServer(Configuration.GetConnectionString("HotelDatabase"));

            // Sorgu izleme davranışını NoTracking olarak ayarlama
            options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        });


        // MediatR'ı yapılandırma ve hizmetleri mevcut yürütülen derlemeden kaydetme
        services.AddMediatR(config => config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        // HotelValidator sınıfını geçici bir hizmet olarak eklemek
        services.AddTransient<HotelValidator>();


        // Bir MapperConfiguration nesnesi oluşturuluyor. Bu, AutoMapper kütüphanesinin haritalama yapılandırmasını tanımlar.
        var mappingConfig = new MapperConfiguration(cfg =>
        {
            // MapperConfiguration'a bir profil ekleniyor. Bu profil, MappingProfile sınıfından türetilmiş bir sınıftır ve AutoMapper'a özel haritalama kurallarını içerir.
            cfg.AddProfile(new MappingProfile()); // Önceki cevapta oluşturduğumuz profili kullanın
        });

        // Oluşturulan MapperConfiguration nesnesi kullanılarak bir IMapper nesnesi oluşturuluyor.
        // Bu, gerçek haritalama işlemlerini yapmak için kullanılacaktır.
        IMapper mapper = mappingConfig.CreateMapper();

        // Servislerin koleksiyonunu kullanarak bu IMapper nesnesi bir Singleton olarak ekleniyor.
        // Bu, uygulama boyunca aynı nesnenin kullanılmasını sağlar.
        services.AddSingleton(mapper);

        // OpenTelemetryExtension, uygulamanın izleme ve telemetri verilerini toplamak için bir genişletme sağlar.
        // Bu genişletme yapılandırması yapılandırma dosyasından alınır.
        services.AddOpenTelemetryExtension(Configuration);

        // RateLimiter, uygulamaya gelen belirli isteklerin hızını sınırlamak için bir genişletmedir.
        // Burada, varsayılan politikaların kullanılacağı belirtiliyor.
        services.AddRateLimiter(options =>
        {
            // options.AddPolicy metodu, bir anahtar (string) ve bir politika türü (DefaultRateLimiterPolicy) alır ve bu anahtarla politikayı ilişkilendirir.
            options.AddPolicy<string, DefaultRateLimiterPolicy>(RateLimiterPolicyNames.DefaultPolicy);
        });

        return services;
    }
    public static void MigrateReservationDb(this IApplicationBuilder app)
    {
        // Uygulamanın hizmetlerine erişmek için IServiceScopeFactory alınır.
        using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
        {
            // Bir hizmet kapsamı oluşturulur.
            // Bu, hizmetlerin belirli bir kapsam içinde yönetilmesini sağlar.
            // Bu kapsam, belirli bir işlem veya operasyon için hizmetlerin erişilebilir olmasını sağlar.

            // Hizmet kapsamından HotelDbContext tipindeki hizmet alınır.
            // HotelDbContext, uygulamanın veritabanı bağlantısını yönetir ve Entity Framework Core tarafından kullanılır.
            var dbContext = serviceScope.ServiceProvider.GetRequiredService<HotelDbContext>();

            // Veritabanı geçiş işlemi yapılır.
            // Migrate() metodu, veritabanındaki şemanın güncellenmesini sağlar.
            // Bu, var olan şemanın mevcut modelle eşleşmesini sağlar.
            dbContext.Database.Migrate();
        }
    }

}
