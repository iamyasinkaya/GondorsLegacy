using GondorsLegacy.Application.Common.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GondorsLegacy.Application.Decorators.DatabaseRetry;

/// <summary>
/// IQueryHandler<TQuery, TResult> arayüzünü uygulayan sorgu işleyici sınıflarını, veritabanı işlemlerini belirli bir
/// sayıda tekrar denemek için kullanılan bir dekoratör sınıf ile süsleyen sınıf.
/// </summary>
/// <typeparam name="TQuery">İşlenecek sorgu türü.</typeparam>
/// <typeparam name="TResult">Sorgunun sonucu.</typeparam>
[Mapping(Type = typeof(DatabaseRetryAttribute))]
public class DatabaseRetryQueryDecorator<TQuery, TResult> : DatabaseRetryDecoratorBase, IQueryHandler<TQuery, TResult>
    where TQuery : IQuery<TResult>
{
    private readonly IQueryHandler<TQuery, TResult> _handler;

    /// <summary>
    /// DatabaseRetryQueryDecorator sınıfının yapıcı metodu.
    /// </summary>
    /// <param name="handler">Temel sorgu işleyici sınıfı.</param>
    /// <param name="options">Veritabanı işlemlerini tekrar deneme seçenekleri.</param>
    public DatabaseRetryQueryDecorator(IQueryHandler<TQuery, TResult> handler, DatabaseRetryAttribute options)
    {
        DatabaseRetryOptions = options;
        _handler = handler;
    }

    /// <summary>
    /// Belirtilen sorguyu işlerken, veritabanı işlemlerini belirli bir sayıda tekrar deneyen metot.
    /// </summary>
    /// <param name="query">İşlenecek sorgu.</param>
    /// <param name="cancellationToken">İptal belirteci.</param>
    /// <returns>Sorgunun sonucu.</returns>
    public async Task<TResult> HandleAsync(TQuery query, CancellationToken cancellationToken = default)
    {
        Task<TResult> result = default;

        // Veritabanı işlemlerini belirli sayıda tekrar denemek için işlemi saran (wrap) metot.
        await WrapExecutionAsync(() => result = _handler.HandleAsync(query, cancellationToken));

        return await result;
    }
}
