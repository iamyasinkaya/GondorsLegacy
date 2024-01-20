using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GondorsLegacy.CrossCuttingCorners.Lock;

/// <summary>
/// Dağıtılmış kilit alanının (scope) kullanımını temsil eden arayüz.
/// </summary>
public interface IDistributedLockScope : IDisposable
{
    /// <summary>
    /// Kilit alanının hala elde tutulup tutulmadığını kontrol eder.
    /// </summary>
    /// <returns>Kilit alanı hala elde tutuluyorsa true, aksi halde false.</returns>
    bool StillHoldingLock();
}
