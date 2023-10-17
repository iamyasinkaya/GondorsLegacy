using GondorsLegacy.Application.Common.Services;
using GondorsLegacy.Domain.Entities;

namespace GondorsLegacy.Application.Common.Commands;

public class DeleteEntityCommand<TEntity> : ICommand
     where TEntity : Entity<Guid>
{
    public TEntity Entity { get; set; }
}

internal class DeleteEntityCommandHandler<TEntity> : ICommandHandler<DeleteEntityCommand<TEntity>>
where TEntity : Entity<Guid>
{
    private readonly ICrudService<TEntity> _crudService;

    public DeleteEntityCommandHandler(ICrudService<TEntity> crudService)
    {
        _crudService = crudService;
    }

    public async Task HandleAsync(DeleteEntityCommand<TEntity> command, CancellationToken cancellationToken = default)
    {
        await _crudService.DeleteAsync(command.Entity);
    }
}