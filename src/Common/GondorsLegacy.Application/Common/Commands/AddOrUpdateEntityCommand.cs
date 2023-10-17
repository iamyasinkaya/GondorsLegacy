using GondorsLegacy.Application.Common.Services;
using GondorsLegacy.Domain.Entities;

namespace GondorsLegacy.Application.Common.Commands;

public class AddOrUpdateEntityCommand<TEntity> : ICommand
    where TEntity : Entity<Guid>
{
    public AddOrUpdateEntityCommand(TEntity entity)
    {
        Entity = entity;
    }

    public TEntity Entity { get; set; }
}

internal class AddOrUpdateEntityCommandHandler<TEntity> : ICommandHandler<AddOrUpdateEntityCommand<TEntity>>
where TEntity : Entity<Guid>
{
    private readonly ICrudService<TEntity> _crudService;

    public AddOrUpdateEntityCommandHandler(ICrudService<TEntity> crudService)
    {
        _crudService = crudService;
    }

    public async Task HandleAsync(AddOrUpdateEntityCommand<TEntity> command, CancellationToken cancellationToken = default)
    {
        await _crudService.AddOrUpdateAsync(command.Entity);
    }
}