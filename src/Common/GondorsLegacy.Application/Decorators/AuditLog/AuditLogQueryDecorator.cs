using GondorsLegacy.Application.Common.Queries;
using System.Text.Json;

namespace GondorsLegacy.Application.Decorators.AuditLog;

/// <summary>
/// IQueryHandler<TQuery, TResult> arayüzünü uygulayan sorgu işleyici sınıflarını denetim (audit) günlüğü ile
/// süsleyen bir dekoratör sınıf.
/// </summary>
/// <typeparam name="TQuery">İşlenecek sorgu türü.</typeparam>
/// <typeparam name="TResult">Sorgunun sonucu.</typeparam>
[Mapping(Type = typeof(AuditLogAttribute))]
public class AuditLogQueryDecorator<TQuery, TResult> : IQueryHandler<TQuery, TResult>
    where TQuery : IQuery<TResult>
{
    private readonly IQueryHandler<TQuery, TResult> _handler;

    /// <summary>
    /// AuditLogQueryDecorator sınıfının yapıcı metodu.
    /// </summary>
    /// <param name="handler">Temel sorgu işleyici sınıfı.</param>
    public AuditLogQueryDecorator(IQueryHandler<TQuery, TResult> handler)
    {
        _handler = handler;
    }

    /// <summary>
    /// Belirtilen sorguyu işlerken, denetim günlüğüne ilgili bilgileri kaydeden metot.
    /// </summary>
    /// <param name="query">İşlenecek sorgu.</param>
    /// <param name="cancellationToken">İptal belirteci.</param>
    /// <returns>Sorgunun sonucu.</returns>
    public Task<TResult> HandleAsync(TQuery query, CancellationToken cancellationToken = default)
    {
        // Sorgunun JSON temsilini oluştur ve konsola yazdır.
        string queryJson = JsonSerializer.Serialize(query);
        Console.WriteLine($"Query of type {query.GetType().Name}: {queryJson}");

        // Temel sorgu işleyici sınıfına işlemi ileterek devam et.
        return _handler.HandleAsync(query, cancellationToken);
    }
}
