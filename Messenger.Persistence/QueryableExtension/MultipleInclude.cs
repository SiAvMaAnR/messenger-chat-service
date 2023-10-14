using MessengerX.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MessengerX.Persistence.QueryableExtension;

public static partial class QueryableExtension
{
    public static IQueryable<TEntity> MultipleInclude<TEntity>(
        this IQueryable<TEntity> dbSet,
        params Expression<Func<TEntity, object>>[] includeProperties
    )
        where TEntity : BaseEntity
    {
        return includeProperties.Aggregate(
            dbSet,
            (current, includeProperty) => current.Include(includeProperty)
        );
    }
}
