using GondorsLegacy.Application.Common.Services;
using GondorsLegacy.Domain.Entities;

namespace GondorsLegacy.Application.Common.Commands;

public class UpdateEntityCommand<TEntity> : ICommand
    where TEntity : Entity<Guid>
{
    public UpdateEntityCommand(TEntity entity)
    {
        Entity = entity;
    }

    public TEntity Entity { get; set; }
}

internal class UpdateEntityCommandHandler<TEntity> : ICommandHandler<UpdateEntityCommand<TEntity>>
where TEntity : Entity<Guid>
{
    private readonly ICrudService<TEntity> _crudService;

    public UpdateEntityCommandHandler(ICrudService<TEntity> crudService)
    {
        _crudService = crudService;
    }

    public async Task HandleAsync(UpdateEntityCommand<TEntity> command, CancellationToken cancellationToken = default)
    {
        await _crudService.UpdateAsync(command.Entity);
    }
}