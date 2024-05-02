
using GondorsLegacy.CrossCuttingCorners.Exceptions;
using GondorsLegacy.Domain.Entities;
using GondorsLegacy.Domain.Events;
using GondorsLegacy.Domain.Repositories;


namespace GondorsLegacy.Application.Common.Services;

public class CrudService<T> : ICrudService<T>
    where T : Entity<Guid>
{
    private readonly IUnitOfWork _unitOfWork;
    protected readonly IRepository<T, Guid> _repository;
    protected readonly Dispatcher _dispatcher;

    public CrudService(IRepository<T, Guid> repository, Dispatcher dispatcher)
    {
        _unitOfWork = repository.UnitOfWork;
        _repository = repository;
        _dispatcher = dispatcher;
    }

    public Task<List<T>> GetAsync(CancellationToken cancellationToken = default)
    {
        return _repository.ToListAsync(_repository.GetAll());
    }

    public Task<T> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        ValidationException.Requires(id != Guid.Empty, "Invalid Id");
        return _repository.FirstOrDefaultAsync(_repository.GetAll().Where(x => x.Id == id));
    }

    public async Task AddOrUpdateAsync(T entity, CancellationToken cancellationToken = default)
    {
        if (entity.Id.Equals(default))
        {
            await AddAsync(entity, cancellationToken);
        }
        else
        {
            await UpdateAsync(entity, cancellationToken);
        }
    }

    public async Task AddAsync(T entity, CancellationToken cancellationToken = default)
    {
        await _repository.InsertAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        await _dispatcher.DispatchAsync(new EntityCreatedEvent<T>(entity, DateTime.UtcNow), cancellationToken);
    }

    public async Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
    {
        var existingEntity = await GetByIdAsync(entity.Id, cancellationToken);
        if (existingEntity == null)
        {
            throw new Exception($"Entity with id {entity.Id} not found");
        }

        await _repository.UpdateAsync(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        await _dispatcher.DispatchAsync(new EntityUpdatedEvent<T>(entity, DateTime.UtcNow), cancellationToken);
    }

    public async Task DeleteAsync(T entity, CancellationToken cancellationToken = default)
    {
        var existingEntity = await GetByIdAsync(entity.Id, cancellationToken);
        if (existingEntity == null)
        {
            throw new Exception($"Entity with id {entity.Id} not found");
        }

        _repository.Delete(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        await _dispatcher.DispatchAsync(new EntityDeletedEvent<T>(entity, DateTime.UtcNow), cancellationToken);
    }
}