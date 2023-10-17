using GondorsLegacy.Domain.Entities;
using GondorsLegacy.Domain.Repositories;

namespace GondorsLegacy.Application.Common.Queries;
public class GetEntititesQuery<TEntity> : IQuery<List<TEntity>>
     where TEntity : Entity<Guid>
{
}

internal class GetEntititesQueryHandler<TEntity> : IQueryHandler<GetEntititesQuery<TEntity>, List<TEntity>>
where TEntity : Entity<Guid>
{
    private readonly IRepository<TEntity, Guid> _repository;

    public GetEntititesQueryHandler(IRepository<TEntity, Guid> repository)
    {
        _repository = repository;
    }

    public Task<List<TEntity>> HandleAsync(GetEntititesQuery<TEntity> query, CancellationToken cancellationToken = default)
    {
        return _repository.ToListAsync(_repository.GetAll());
    }
}