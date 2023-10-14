using MessengerX.Domain.Entities;
using MessengerX.Domain.Interfaces.Repository;
using MessengerX.Persistence.DBContext;
using MessengerX.Persistence.QueryableExtension;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MessengerX.Persistence.Repositories.Common;

public class BaseRepository<TEntity> : IAsyncRepository<TEntity>
    where TEntity : BaseEntity
{
    protected readonly DbSet<TEntity> _dbSet;

    public BaseRepository(EFContext dbContext)
    {
        _dbSet = dbContext.Set<TEntity>();
    }

    public virtual async Task AddAsync(TEntity entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public virtual async Task UpdateAsync(TEntity entity)
    {
        await Task.FromResult(_dbSet.Update(entity));
    }

    public virtual async Task DeleteAsync(TEntity entity)
    {
        await Task.FromResult(_dbSet.Remove(entity));
    }

    public virtual async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await _dbSet.FirstOrDefaultAsync(predicate);
    }

    public virtual async Task<TEntity?> GetAsync(
        Expression<Func<TEntity, bool>> predicate,
        params Expression<Func<TEntity, object>>[] includeProperties
    )
    {
        return await _dbSet.MultipleInclude(includeProperties).FirstOrDefaultAsync(predicate);
    }

    public virtual async Task<IEnumerable<TEntity>?> GetAllAsync(
        Expression<Func<TEntity, bool>> predicate
    )
    {
        return await Task.FromResult(_dbSet.Where(predicate));
    }

    public virtual async Task<IEnumerable<TEntity>?> GetAllAsync()
    {
        return await Task.FromResult(_dbSet);
    }

    public virtual async Task<IEnumerable<TEntity>?> GetAllAsync(
        params Expression<Func<TEntity, object>>[] includeProperties
    )
    {
        return await Task.FromResult(_dbSet.MultipleInclude(includeProperties));
    }

    public virtual async Task<IEnumerable<TEntity>?> GetAllAsync(
        Expression<Func<TEntity, bool>> predicate,
        params Expression<Func<TEntity, object>>[] includeProperties
    )
    {
        return await Task.FromResult(
            _dbSet.MultipleInclude(includeProperties).Where(predicate)
        );
    }

    public virtual async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await _dbSet.AnyAsync(predicate);
    }

    public virtual async Task<bool> AllAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await _dbSet.AllAsync(predicate);
    }

    public virtual async Task<IQueryable<TEntity>> CustomAsync()
    {
        return await Task.FromResult(_dbSet);
    }
}
