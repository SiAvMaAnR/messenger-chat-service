using System.Linq.Expressions;
using MessengerX.Domain.Entities;
using MessengerX.Persistence.DBContext;
using MessengerX.Persistence.QueryableExtension;
using Microsoft.EntityFrameworkCore;

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

    public virtual void Update(TEntity entity)
    {
        _dbSet.Update(entity);
    }

    public virtual void Delete(TEntity entity)
    {
        _dbSet.Remove(entity);
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

    public virtual IEnumerable<TEntity>? GetAll(Expression<Func<TEntity, bool>> predicate)
    {
        return _dbSet.Where(predicate).AsNoTracking();
    }

    public virtual IEnumerable<TEntity>? GetAll()
    {
        return _dbSet.AsNoTracking();
    }

    public virtual IEnumerable<TEntity>? GetAll(
        params Expression<Func<TEntity, object>>[] includeProperties
    )
    {
        return _dbSet.MultipleInclude(includeProperties).AsNoTracking();
    }

    public virtual IEnumerable<TEntity>? GetAll(
        Expression<Func<TEntity, bool>> predicate,
        params Expression<Func<TEntity, object>>[] includeProperties
    )
    {
        return _dbSet.MultipleInclude(includeProperties).Where(predicate).AsNoTracking();
    }

    public virtual async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await _dbSet.AnyAsync(predicate);
    }

    public virtual async Task<bool> AllAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await _dbSet.AllAsync(predicate);
    }

    public virtual IQueryable<TEntity> QueryBuilder()
    {
        return _dbSet;
    }
}
