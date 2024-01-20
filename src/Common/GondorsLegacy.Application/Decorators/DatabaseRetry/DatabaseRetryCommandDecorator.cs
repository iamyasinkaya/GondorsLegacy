using GondorsLegacy.Application.Common.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GondorsLegacy.Application.Decorators.DatabaseRetry;

/// <summary>
/// ICommandHandler<TCommand> arayüzünü uygulayan komut işleyici sınıflarını, veritabanı işlemlerini belirli bir
/// sayıda tekrar denemek için kullanılan bir dekoratör sınıf ile süsleyen sınıf.
/// </summary>
/// <typeparam name="TCommand">İşlenecek komut türü.</typeparam>
[Mapping(Type = typeof(DatabaseRetryAttribute))]
public class DatabaseRetryCommandDecorator<TCommand> : DatabaseRetryDecoratorBase, ICommandHandler<TCommand>
    where TCommand : ICommand
{
    private readonly ICommandHandler<TCommand> _handler;

    /// <summary>
    /// DatabaseRetryCommandDecorator sınıfının yapıcı metodu.
    /// </summary>
    /// <param name="handler">Temel komut işleyici sınıfı.</param>
    /// <param name="options">Veritabanı işlemlerini tekrar deneme seçenekleri.</param>
    public DatabaseRetryCommandDecorator(ICommandHandler<TCommand> handler, DatabaseRetryAttribute options)
    {
        DatabaseRetryOptions = options;
        _handler = handler;
    }

    /// <summary>
    /// Belirtilen komutu işlerken, veritabanı işlemlerini belirli bir sayıda tekrar deneyen metot.
    /// </summary>
    /// <param name="command">İşlenecek komut.</param>
    /// <param name="cancellationToken">İptal belirteci.</param>
    public async Task HandleAsync(TCommand command, CancellationToken cancellationToken = default)
    {
        // Veritabanı işlemlerini belirli sayıda tekrar denemek için işlemi saran (wrap) metot.
        await WrapExecutionAsync(() => _handler.HandleAsync(command, cancellationToken));
    }
}
