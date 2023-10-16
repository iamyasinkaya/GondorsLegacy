using System.Linq.Expressions;
using EntityFrameworkCore.SqlServer.SimpleBulks.BulkDelete;
using EntityFrameworkCore.SqlServer.SimpleBulks.BulkInsert;
using EntityFrameworkCore.SqlServer.SimpleBulks.BulkMerge;
using EntityFrameworkCore.SqlServer.SimpleBulks.BulkUpdate;
using GondorsLegacy.CrossCuttingCorners.DateTimes;
using GondorsLegacy.Domain.Entities;
using GondorsLegacy.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GondorsLegacy.Infrastructure.Persistence;

/// <summary>
/// Entity Framework Core tabanlı bir veritabanı erişim katmanını temsil eden genel sınıf.
/// </summary>
public class DbContextRepository<TDbContext, TEntity, TKey> : IRepository<TEntity, TKey>
    where TEntity : Entity<TKey>
    where TDbContext : DbContext, IUnitOfWork
{
    private readonly TDbContext _dbContext;
    private readonly IDateTimeProvider _dateTimeProvider;

    protected DbSet<TEntity> DbSet => _dbContext.Set<TEntity>();

    /// <summary>
    /// İş birimi örneğini döndürür.
    /// </summary>
    public IUnitOfWork UnitOfWork => _dbContext;

    public DbContextRepository(TDbContext dbContext, IDateTimeProvider dateTimeProvider)
    {
        _dbContext = dbContext;
        _dateTimeProvider = dateTimeProvider;
    }

    public IQueryable<TEntity> GetAll()
    {
        return DbSet;
    }

    /// <summary>
    /// Varlığı ekle veya güncelle.
    /// </summary>
    /// <param name="entity">Eklenecek veya güncellenecek varlık örneği</param>
    /// <param name="cancellationToken">İptal belirteci</param>
    /// <returns>Asenkron işlem sonucunu temsil eden görev</returns>
    public async Task UpsertAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        if (entity.Id.Equals(default(TKey)))
        {
            await InsertAsync(entity, cancellationToken);
        }
        else
        {
            await UpdateAsync(entity, cancellationToken);
        }
    }


    /// <summary>
    /// Varlığı veritabanına eklemek için kullanılan metot.
    /// </summary>
    /// <param name="entity">Eklenecek varlık örneği</param>
    /// <param name="cancellationToken">İptal belirteci</param>
    /// <returns>Asenkron işlem sonucunu temsil eden görev</returns>
    public async Task InsertAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        entity.CreatedDateTime = _dateTimeProvider.OffsetNow;
        await DbSet.AddAsync(entity, cancellationToken);
    }


    /// <summary>
    /// Varlığı veritabanında güncellemek için kullanılan metot.
    /// </summary>
    /// <param name="entity">Güncellenecek varlık örneği</param>
    /// <param name="cancellationToken">İptal belirteci</param>
    /// <returns>Asenkron işlem sonucunu temsil eden görev</returns>
    public async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        entity.UpdatedDateTime = _dateTimeProvider.OffsetNow;
        DbSet.Update(entity);
        await Task.CompletedTask; // Görev tamamlandı olarak işaretlenir
    }


    /// <summary>
    /// Varlığı veritabanından silmek için kullanılan metot.
    /// </summary>
    /// <param name="entity">Silinecek varlık örneği</param>
    public void Delete(TEntity entity)
    {
        DbSet.Remove(entity);
    }


    /// <summary>
    /// Belirtilen sorgunun sonuçları arasında ilk öğeyi asenkron olarak almak için kullanılan metot.
    /// </summary>
    /// <typeparam name="T">Sorgu sonuç türü</typeparam>
    /// <param name="query">Sorgu</param>
    /// <returns>Asenkron işlem sonucunu temsil eden görev</returns>
    public async Task<T> FirstOrDefaultAsync<T>(IQueryable<T> query)
    {
        return await query.FirstOrDefaultAsync();
    }


    /// <summary>
    /// Belirtilen sorgunun sonuçları arasında tek bir öğeyi asenkron olarak almak için kullanılan metot.
    /// </summary>
    /// <typeparam name="T">Sorgu sonuç türü</typeparam>
    /// <param name="query">Sorgu</param>
    /// <returns>Asenkron işlem sonucunu temsil eden görev</returns>
    public async Task<T> SingleOrDefaultAsync<T>(IQueryable<T> query)
    {
        return await query.SingleOrDefaultAsync();
    }


    /// <summary>
    /// Belirtilen sorgunun sonuçlarını bir liste olarak asenkron olarak almak için kullanılan metot.
    /// </summary>
    /// <typeparam name="T">Sorgu sonuç türü</typeparam>
    /// <param name="query">Sorgu</param>
    /// <returns>Asenkron işlem sonucunu temsil eden görev</returns>
    public async Task<List<T>> ToListAsync<T>(IQueryable<T> query)
    {
        return await query.ToListAsync();
    }


    /// <summary>
    /// Birden fazla varlık örneğini toplu olarak veritabanına eklemek için kullanılan metot.
    /// </summary>
    /// <param name="entities">Eklenecek varlık örneklerinin koleksiyonu</param>
    public void BulkInsert(IEnumerable<TEntity> entities)
    {
        _dbContext.BulkInsert(entities);
    }


    /// <summary>
    /// Birden fazla varlık örneğini toplu olarak veritabanına eklemek için kullanılan metot.
    /// </summary>
    /// <param name="entities">Eklenecek varlık örneklerinin koleksiyonu</param>
    /// <param name="predicates">Eklenecek sütunları belirlemek için lambda ifadesi</param>
    public void BulkInsert(IEnumerable<TEntity> entities, Expression<Func<TEntity, object>> predicates)
    {
        _dbContext.BulkInsert(entities, predicates);
    }


    /// <summary>
    /// Birden fazla varlık örneğini toplu olarak veritabanında güncellemek için kullanılan metot.
    /// </summary>
    /// <param name="entities">Güncellenecek varlık örneklerinin koleksiyonu</param>
    /// <param name="predicates">Güncellenecek sütunları belirlemek için lambda ifadesi</param>
    public void BulkUpdate(IEnumerable<TEntity> entities, Expression<Func<TEntity, object>> predicates)
    {
        _dbContext.BulkUpdate(entities, predicates);
    }

    /// <summary>
    /// Birden fazla varlık örneğini toplu olarak veritabanına eklemek veya güncellemek için kullanılan metot.
    /// </summary>
    /// <param name="entities">Eklenecek veya güncellenecek varlık örneklerinin koleksiyonu</param>
    /// <param name="idSelector">Kimlik seçicisi</param>
    /// <param name="predicates">Güncellenecek sütunları belirlemek için lambda ifadesi</param>
    public void BulkMerge(IEnumerable<TEntity> entities, Expression<Func<TEntity, object>> idSelector, Expression<Func<TEntity, object>> predicates)
    {
        _dbContext.BulkMerge(entities, idSelector, predicates, predicates);
    }

    /// <summary>
    /// Birden fazla varlık örneğini toplu olarak veritabanından silmek için kullanılan metot.
    /// </summary>
    /// <param name="entities">Silinecek varlık örneklerinin koleksiyonu</param>
    public void BulkDelete(IEnumerable<TEntity> entities)
    {
        _dbContext.BulkDelete(entities);
    }

    /// <summary>
    /// Bir varlık örneğinin sürüm bilgisini ayarlamak için kullanılan metot.
    /// </summary>
    /// <param name="entity">Varlık örneği</param>
    /// <param name="version">Sürüm bilgisi</param>
    public void SetRowVersion(TEntity entity, byte[] version)
    {
        _dbContext.Entry(entity).OriginalValues[nameof(entity.RowVersion)] = version;
    }

    /// <summary>
    /// Bir hata nesnesinin bir veritabanı güncelleme eşzamanlılık istisnası olup olmadığını kontrol eder.
    /// </summary>
    /// <param name="ex">Hata nesnesi</param>
    /// <returns>Eğer bir güncelleme eşzamanlılık istisnası ise true; aksi halde false</returns>
    public bool IsDbUpdateConcurrencyException(Exception ex)
    {
        return ex is DbUpdateConcurrencyException;
    }
}