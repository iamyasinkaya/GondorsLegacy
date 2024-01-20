using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GondorsLegacy.Application.Decorators.DatabaseRetry;

/// <summary>
/// Veritabanı işlemlerini belirli bir sayıda tekrar deneme mantığını uygulayan soyut bir dekoratör sınıfı.
/// </summary>
public abstract class DatabaseRetryDecoratorBase
{
    /// <summary>
    /// Veritabanı işlemlerini tekrar deneme seçeneklerini içeren özellik.
    /// </summary>
    protected DatabaseRetryAttribute DatabaseRetryOptions { get; set; }

    /// <summary>
    /// Belirtilen aksiyonu belirli bir sayıda tekrar deneme mantığıyla saran metot.
    /// </summary>
    /// <param name="action">Denenecek aksiyon.</param>
    protected void WrapExecution(Action action)
    {
        int executedTimes = 0;

        while (true)
        {
            try
            {
                executedTimes++;
                action();
                return;
            }
            catch (Exception ex)
            {
                if (executedTimes >= DatabaseRetryOptions.RetryTimes || !IsDatabaseException(ex))
                {
                    throw;
                }
            }
        }
    }

    /// <summary>
    /// Belirtilen asenkron aksiyonu belirli bir sayıda tekrar deneme mantığıyla saran metot.
    /// </summary>
    /// <param name="action">Denenecek asenkron aksiyon.</param>
    protected async Task WrapExecutionAsync(Func<Task> action)
    {
        int executedTimes = 0;

        while (true)
        {
            try
            {
                executedTimes++;
                await action();
                return;
            }
            catch (Exception ex)
            {
                if (executedTimes >= DatabaseRetryOptions.RetryTimes || !IsDatabaseException(ex))
                {
                    throw;
                }
            }
        }
    }

    /// <summary>
    /// Veritabanı hatası olup olmadığını kontrol eden özel bir metot.
    /// </summary>
    /// <param name="exception">Kontrol edilecek istisna.</param>
    /// <returns>Veritabanı hatası ise true, değilse false.</returns>
    private static bool IsDatabaseException(Exception exception)
    {
        string message = exception.InnerException?.Message;

        if (message == null)
        {
            return false;
        }

        return message.Contains("The connection is broken and recovery is not possible")
            || message.Contains("error occurred while establishing a connection");
    }
}
