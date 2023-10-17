using System;
using GondorsLegacy.Application.Common.Services;
using GondorsLegacy.Domain.Entities;

namespace GondorsLegacy.Application.Common.Commands;

public class AddEntityCommand<TEntity> : ICommand
    where TEntity : Entity<Guid>
{
    public AddEntityCommand(TEntity entity)
    {
        Entity = entity;
    }

    public TEntity Entity { get; set; }
}

internal class AddEntityCommandHandler<TEntity> : ICommandHandler<AddEntityCommand<TEntity>>
where TEntity : Entity<Guid>
{
    private readonly ICrudService<TEntity> _crudService;

    public AddEntityCommandHandler(ICrudService<TEntity> crudService)
    {
        _crudService = crudService;
    }

    public async Task HandleAsync(AddEntityCommand<TEntity> command, CancellationToken cancellationToken = default)
    {
        await _crudService.AddAsync(command.Entity);
    }
}

