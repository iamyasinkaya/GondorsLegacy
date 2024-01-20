namespace GondorsLegacy.CrossCuttingCorners.Lock;

/// <summary>
/// Kilitleme yöneticisinin temel işlevselliğini tanımlayan arayüz.
/// </summary>
public interface ILockManager
{
    /// <summary>
    /// Belirli bir varlık için kilidin alınması.
    /// </summary>
    /// <param name="entityName">Varlık adı.</param>
    /// <param name="entityId">Varlık kimliği.</param>
    /// <param name="ownerId">Kilidi alan sahibin kimliği.</param>
    /// <param name="expirationIn">Kilidin süresi.</param>
    /// <returns>Kilidin başarıyla alınıp alınamadığı.</returns>
    bool AcquireLock(string entityName, string entityId, string ownerId, TimeSpan expirationIn);

    /// <summary>
    /// Belirli bir varlık için kilidin süresini uzatma.
    /// </summary>
    /// <param name="entityName">Varlık adı.</param>
    /// <param name="entityId">Varlık kimliği.</param>
    /// <param name="ownerId">Kilidi alan sahibin kimliği.</param>
    /// <param name="expirationIn">Kilidin yeni süresi.</param>
    /// <returns>Kilidin başarıyla süresinin uzatılıp uzatılamadığı.</returns>
    bool ExtendLock(string entityName, string entityId, string ownerId, TimeSpan expirationIn);

    /// <summary>
    /// Belirli bir varlık için kilidin serbest bırakılması.
    /// </summary>
    /// <param name="entityName">Varlık adı.</param>
    /// <param name="entityId">Varlık kimliği.</param>
    /// <param name="ownerId">Kilidi alan sahibin kimliği.</param>
    /// <returns>Kilidin başarıyla serbest bırakılıp bırakılamadığı.</returns>
    bool ReleaseLock(string entityName, string entityId, string ownerId);

    /// <summary>
    /// Belirli bir sahibe ait tüm kilidin serbest bırakılması.
    /// </summary>
    /// <param name="ownerId">Kilidin sahibinin kimliği.</param>
    /// <returns>İşlem başarılıysa true, değilse false.</returns>
    bool ReleaseLocks(string ownerId);

    /// <summary>
    /// Süresi dolmuş kilidin serbest bırakılması.
    /// </summary>
    /// <returns>İşlem başarılıysa true, değilse false.</returns>
    bool ReleaseExpiredLocks();

    /// <summary>
    /// Belirli bir varlık için kilidin alınmasını sağlar ve kilidi alana kadar bekler.
    /// </summary>
    /// <param name="entityName">Varlık adı.</param>
    /// <param name="entityId">Varlık kimliği.</param>
    /// <param name="ownerId">Kilidi alacak sahibin kimliği.</param>
    /// <param name="expirationIn">Kilidin süresi.</param>
    void EnsureAcquiringLock(string entityName, string entityId, string ownerId, TimeSpan expirationIn);
}
