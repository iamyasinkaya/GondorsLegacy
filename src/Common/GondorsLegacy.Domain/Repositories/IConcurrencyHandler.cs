namespace GondorsLegacy.Domain.Repositories;

/// <summary>
///  Bu arayüz, eş zamanlılık (concurrency) işlemlerini yönetmek için kullanılan bir arayüzü temsil eder.
/// </summary>
/// <typeparam name="TEntity"></typeparam>
public interface IConcurrencyHandler<TEntity>
{
    /// <summary>
    ///  Bu yöntem, bir varlık (entity) ve ilgili sürüm (version) bilgisini alır ve varlık nesnesinin sürüm bilgisini ayarlamak için kullanılır. Sürüm bilgisi, genellikle bir veritabanı tablosundaki bir alan veya sütun tarafından temsil edilen bir veridir.
    /// </summary>
    /// <param name="entity">TEntity bilgisini ifade eder</param>
    /// <param name="version">Versiyon bilgisini ifade eder</param>
    void SetRowVersion(TEntity entity, byte[] version);

    /// <summary>
    /// Bu yöntem, bir özel durumun (exception) veritabanı güncelleme eş zamanlılık hatası (concurrency exception) olup olmadığını belirlemek için kullanılır. Eş zamanlılık hatası, bir veritabanı işlemi sırasında başka bir işlem tarafından aynı veriye yapılan değişiklikler nedeniyle ortaya çıkabilir. 
    /// </summary>
    /// <param name="ex">İstisna bilgisini ifade eder</param>
    bool IsDbUpdateConcurrencyException(Exception ex);
}