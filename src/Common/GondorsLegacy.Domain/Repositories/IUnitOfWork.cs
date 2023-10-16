using System.Data;

namespace GondorsLegacy.Domain.Repositories;

/// <summary>
/// Bu arayüz, birim işlemi desenini uygulayan bir bileşeni temsil eder. Birim işlemi deseni, iş mantığını ve veri erişimini birleştirmek için kullanılan bir desendir. 
/// Bu desen, işlemleri bir bütün olarak ele alır ve tutarlılığı sağlamak için değişiklikleri toplu olarak kaydeder veya iptal eder. 
/// Bu arayüz, bir birim işlemini başlatma, işlemi onaylama veya iptal etme gibi temel işlevleri tanımlar ve bu işlemleri asenkron olarak gerçekleştirir
/// </summary>
public interface IUnitOfWork
{
    /// <summary>
    /// Değişiklikleri veri kaynağına kaydetmek için asenkron bir işlem olarak çalışır ve bir tamsayı değer olan etkilenen satır sayısını döndürür.
    /// </summary>
    /// <param name="cancellationToken">İptal belirteci (cancellation token) ile işlemi iptal etmek istenirse kullanılabilir.</param>
    /// <returns>Değişiklikleri veri kaynağına kaydetmek için asenkron bir işlem olarak çalışır ve bir tamsayı değer olan etkilenen satır sayısını döndürür.</returns>
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    /// <summary>
    ///  İşlemi başlatmak için asenkron bir işlem olarak çalışır ve bir IDisposable nesnesini döndürür. Bu nesne, işlem tamamlandığında kullanılarak işlemi onaylayabilir (commit) veya iptal edebilir (rollback). 
    /// </summary>
    /// <param name="ısolationLevel">Yalıtım seviyesi (isolation level)</param>
    /// <param name="cancellationToken">İptal belirteci (cancellation token) ile işlemi iptal etmek istenirse kullanılabilir.</param>
    /// <returns>İşlemi başlatmak için asenkron bir işlem olarak çalışır ve bir IDisposable nesnesini döndürür.</returns>
    Task<IDisposable> BeginTransactionAsync(IsolationLevel ısolationLevel = IsolationLevel.ReadCommitted, CancellationToken cancellationToken = default);

    /// <summary>
    /// İşlemi onaylamak için asenkron bir işlem olarak çalışır. Bu, birim işleminde yapılan değişiklikleri kalıcı hale getirir
    /// </summary>
    /// <param name="cancellationToken">İptal belirteci (cancellation token) ile işlemi iptal etmek istenirse kullanılabilir.</param>
    /// <returns>İşlemi onaylamak için asenkron bir işlem olarak çalışır. Bu, birim işleminde yapılan değişiklikleri kalıcı hale getirir</returns>
    Task CommitTransactionAsnyc(CancellationToken cancellationToken = default);
}