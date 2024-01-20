using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GondorsLegacy.Application.Decorators.DatabaseRetry;

/// <summary>
/// DatabaseRetryAttribute, bir sınıfın veya bir metodun veritabanı işlemlerini tekrar denemek için kullanılan özel bir niteliktir.
/// </summary>
[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
public sealed class DatabaseRetryAttribute : Attribute
{
    /// <summary>
    /// Veritabanı işlemlerini tekrar deneme sayısını belirten bir özellik.
    /// </summary>
    public int RetryTimes { get; }

    /// <summary>
    /// DatabaseRetryAttribute sınıfının yapıcı metodu. Varsayılan olarak 3 tekrar deneme sayısıyla oluşturulur.
    /// </summary>
    /// <param name="retryTimes">Veritabanı işlemlerini tekrar deneme sayısı.</param>
    public DatabaseRetryAttribute(int retryTimes = 3)
    {
        RetryTimes = retryTimes;
    }
}
