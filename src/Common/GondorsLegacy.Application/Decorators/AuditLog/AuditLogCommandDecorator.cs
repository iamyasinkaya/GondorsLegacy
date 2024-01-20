using GondorsLegacy.Application.Common.Commands;
using System.Text.Json;

namespace GondorsLegacy.Application.Decorators.AuditLog;

/// <summary>
/// ICommandHandler<TCommand> arayüzünü uygulayan komut işleyici sınıflarını denetim (audit) günlüğü ile
/// süsleyen bir dekoratör sınıf.
/// </summary>
/// <typeparam name="TCommand">İşlenecek komut türü.</typeparam>
[Mapping(Type = typeof(AuditLogAttribute))]
public class AuditLogCommandDecorator<TCommand> : ICommandHandler<TCommand>
    where TCommand : ICommand
{
    private readonly ICommandHandler<TCommand> _handler;

    /// <summary>
    /// AuditLogCommandDecorator sınıfının yapıcı metodu.
    /// </summary>
    /// <param name="handler">Temel komut işleyici sınıfı.</param>
    public AuditLogCommandDecorator(ICommandHandler<TCommand> handler)
    {
        _handler = handler;
    }

    /// <summary>
    /// Belirtilen komutu işlerken, denetim günlüğüne ilgili bilgileri kaydeden metot.
    /// </summary>
    /// <param name="command">İşlenecek komut.</param>
    /// <param name="cancellationToken">İptal belirteci.</param>
    public async Task HandleAsync(TCommand command, CancellationToken cancellationToken = default)
    {
        // Komutun JSON temsilini oluştur ve konsola yazdır.
        var commandJson = JsonSerializer.Serialize(command);
        Console.WriteLine($"Command of type {command.GetType().Name}: {commandJson}");

        // Temel komut işleyici sınıfına işlemi ileterek devam et.
        await _handler.HandleAsync(command, cancellationToken);
    }
}
