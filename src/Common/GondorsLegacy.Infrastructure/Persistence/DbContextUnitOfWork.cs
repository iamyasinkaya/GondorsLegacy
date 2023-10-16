using GondorsLegacy.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;
using System.Reflection;

namespace GondorsLegacy.Infrastructure.Persistence;

/// <summary>
/// Bir <see cref="DbContext"/> kullanarak bir iş birimi (unit of work) uygulamasını temsil eder.
/// Bu sınıf, işlemleri birleştirmek ve veritabanı işlemlerini birleşik bir şekilde yönetmek için yöntemler sağlar.
/// </summary>
/// <typeparam name="TDbContext">İş biriminde kullanılacak <see cref="DbContext"/> türü.</typeparam>
public class DbContextUnitOfWork<TDbContext> : DbContext, IUnitOfWork
    where TDbContext : DbContext
{
    private IDbContextTransaction _dbContextTransaction;

    /// <summary>
    /// <see cref="DbContext"/> için seçenekleri kullanarak yeni bir <see cref="DbContextUnitOfWork{TDbContext}"/> örneği oluşturur.
    /// </summary>
    /// <param name="options"><see cref="DbContext"/> için yapılandırma seçenekleri.</param>
    public DbContextUnitOfWork(DbContextOptions<TDbContext> options)
        : base(options)
    {
    }

    /// <summary>
    /// Yeni bir veritabanı işlemi başlatır.
    /// </summary>
    /// <param name="isolationLevel">İşlem izolasyon seviyesi.</param>
    /// <param name="cancellationToken">İptal belirteci.</param>
    /// <returns>İşlemi onaylayabileceğiniz veya geri alabileceğiniz bir IDisposable nesnesini döndürür.</returns>
    public async Task<IDisposable> BeginTransactionAsync(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted, CancellationToken cancellationToken = default)
    {
        _dbContextTransaction = await Database.BeginTransactionAsync(isolationLevel, cancellationToken);
        return _dbContextTransaction;
    }

    /// <summary>
    /// Mevcut veritabanı işlemini onaylar.
    /// </summary>
    /// <param name="cancellationToken">İptal belirteci.</param>
    /// <returns>Asenkron onay işlemini temsil eden bir görev.</returns>
    public async Task CommitTransactionAsnyc(CancellationToken cancellationToken = default)
    {
        await _dbContextTransaction.CommitAsync(cancellationToken);
    }

    /// <summary>
    /// Mevcut veritabanı işlemini geri alır.
    /// </summary>
    /// <param name="cancellationToken">İptal belirteci.</param>
    /// <returns>Asenkron geri alma işlemini temsil eden bir görev.</returns>
    public async Task RollbackTransactionAsync(CancellationToken cancellationToken = default)
    {
        if (_dbContextTransaction != null)
        {
            await _dbContextTransaction.RollbackAsync(cancellationToken);
        }
    }

    /// <inheritdoc/>
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}