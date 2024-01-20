using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GondorsLegacy.CrossCuttingCorners.Lock;

/// <summary>
/// Kilit alınamadığında ortaya çıkan özel bir istisna türü.
/// </summary>
public class CouldNotAcquireLockException : Exception
{
    /// <summary>
    /// CouldNotAcquireLockException sınıfının parametresiz yapıcı metodu.
    /// </summary>
    public CouldNotAcquireLockException()
    {
    }

    /// <summary>
    /// CouldNotAcquireLockException sınıfının mesajla oluşturulan yapıcı metodu.
    /// </summary>
    /// <param name="message">İstisna mesajı.</param>
    public CouldNotAcquireLockException(string message)
        : base(message)
    {
    }

    /// <summary>
    /// CouldNotAcquireLockException sınıfının mesaj ve iç istisna ile oluşturulan yapıcı metodu.
    /// </summary>
    /// <param name="message">İstisna mesajı.</param>
    /// <param name="innerException">İç istisna.</param>
    public CouldNotAcquireLockException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}
