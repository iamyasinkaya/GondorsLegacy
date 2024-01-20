namespace GondorsLegacy.CrossCuttingCorners.Lock;

/// <summary>
/// Dağıtılmış kilit yönetimini temsil eden arayüz.
/// </summary>
public interface IDistributedLock
{
    /// <summary>
    /// Belirli bir kilit adıyla bir dağıtılmış kilit alanını alır.
    /// </summary>
    /// <param name="lockName">Kilit adı.</param>
    /// <returns>Dağıtılmış kilit alanı (scope).</returns>
    IDistributedLockScope Acquire(string lockName);

    /// <summary>
    /// Belirli bir kilit adıyla bir dağıtılmış kilit alanını almaya çalışır.
    /// </summary>
    /// <param name="lockName">Kilit adı.</param>
    /// <returns>Dağıtılmış kilit alanı (scope) veya null.</returns>
    IDistributedLockScope TryAcquire(string lockName);
}
