using GondorsLegacy.Domain.Entities;
using System.Linq.Expressions;

namespace GondorsLegacy.Domain.Repositories;

/// <summary>
///  Bu arayüz, bir veritabanı işlemcisi gibi davranan bir veri erişim katmanı için temel işlevleri tanımlamaktadır.
/// </summary>
/// <typeparam name="TEntity"></typeparam>
/// <typeparam name="TKey"></typeparam>
public interface IRepository<TEntity, TKey> : IConcurrencyHandler<TEntity>
    where TEntity : Entity<TKey>
{
    IUnitOfWork UnitOfWork { get; }

    /// <summary>
    /// Tüm TEntity nesnelerini içeren bir IQueryable<TEntity> döndürür.
    /// </summary>
    /// <returns>Tüm TEntity nesnelerini içeren bir IQueryable<TEntity> döndürür.</returns>
    IQueryable<TEntity> GetAll();

    /// <summary>
    /// Bir TEntity nesnesini ekleme veya güncelleme işlemi yapar. İşlemi asenkron olarak gerçekleştirir.
    /// </summary>
    /// <param name="entity">TEntity nesnesi ifade eder</param>
    /// <param name="cancellationToken">İptal belirteci (cancellation token) ile işlemi iptal etmek istenirse kullanılabilir.</param>
    /// <returns>Eşzamansız bir görevi temsil eder</returns>
    Task UpsertAsync(TEntity entity, CancellationToken cancellationToken = default);

    /// <summary>
    /// Bir TEntity nesnesini ekler. İşlemi asenkron olarak gerçekleştirir.
    /// </summary>
    /// <param name="entity">TEntity nesnesini ifade eder</param>
    /// <param name="cancellationToken">İptal belirteci (cancellation token) ile işlemi iptal etmek istenirse kullanılabilir.</param>
    /// <returns>Eşzamansız bir görevi temsil eder</returns>
    Task InsertAsync(TEntity entity, CancellationToken cancellationToken = default);

    /// <summary>
    /// Bir TEntity nesnesini günceller. İşlemi asenkron olarak gerçekleştirir.
    /// </summary>
    /// <param name="entity">TEntity nesnesini ifade eder</param>
    /// <param name="cancellationToken">İptal belirteci (cancellation token) ile işlemi iptal etmek istenirse kullanılabilir.</param>
    /// <returns>Eşzamansız bir görevi temsil eder</returns>
    Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);

    /// <summary>
    /// Bir TEntity nesnesini siler.
    /// </summary>
    /// <param name="entity">TEntity nesnesini ifade eder</param>
    void Delete(TEntity entity);

    /// <summary>
    /// Bir IQueryable<T> sorgusunun sonucunda ilk öğeyi veya varsayılan değeri asenkron olarak döndürür.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="query"></param>
    /// <returns>Bir IQueryable<T> sorgusunun sonucunda ilk öğeyi veya varsayılan değeri asenkron olarak döndürür.</returns>
    Task<T> FirstOrDefaultAsync<T>(IQueryable<T> query);

    /// <summary>
    ///  Bir IQueryable<T> sorgusunun sonucunda tek bir öğeyi veya varsayılan değeri asenkron olarak döndürür.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="query"></param>
    /// <returns> Bir IQueryable<T> sorgusunun sonucunda tek bir öğeyi veya varsayılan değeri asenkron olarak döndürür.</returns>
    Task<T> SingleOrDefaultAsync<T>(IQueryable<T> query);

    /// <summary>
    ///  Bir IQueryable<T> sorgusunun sonucunu bir liste olarak asenkron olarak döndürür.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="query"></param>
    /// <returns> Bir IQueryable<T> sorgusunun sonucunu bir liste olarak asenkron olarak döndürür.</returns>
    Task<List<T>> ToListAsync<T>(IQueryable<T> query);

    /// <summary>
    /// Birden fazla TEntity nesnesini toplu olarak ekler.
    /// </summary>
    /// <param name="entities">TEntity nesnesini ifade eder</param>
    void BulkInsert(IEnumerable<TEntity> entities);

    /// <summary>
    /// Birden fazla TEntity nesnesini belirli bir koşula göre toplu olarak ekler.
    /// </summary>
    /// <param name="entities">TEntity nesnesini ifade eder</param>
    /// <param name="predicates"></param>
    void BulkInsert(IEnumerable<TEntity> entities, Expression<Func<TEntity, object>> predicates);

    /// <summary>
    ///  Birden fazla TEntity nesnesini belirli bir koşula göre toplu olarak günceller.
    /// </summary>
    /// <param name="entities">TEntity nesnesini ifade eder</param>
    /// <param name="predicates"></param>
    void BulkUpdate(IEnumerable<TEntity> entities, Expression<Func<TEntity, object>> predicates);

    /// <summary>
    /// Birden fazla TEntity nesnesini belirli bir kimlik seçici ve koşula göre birleştirir.
    /// </summary>
    /// <param name="entities">TEntity nesnesine ifade eder</param>
    /// <param name="idSelector"></param>
    /// <param name="predicates"></param>
    void BulkMerge(IEnumerable<TEntity> entities, Expression<Func<TEntity, object>> idSelector, Expression<Func<TEntity, object>> predicates);

    /// <summary>
    /// Birden fazla TEntity nesnesini toplu olarak siler.
    /// </summary>
    /// <param name="entities">TEntity nesnesini ifade eder</param>
    void BulkDelete(IEnumerable<TEntity> entities);
}