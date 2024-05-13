using System.Linq.Expressions;
using MessengerX.Domain.Entities;

namespace MessengerX.Domain.Specification;

public abstract partial class Specification<TEntity> : ISpecification<TEntity>
    where TEntity : BaseEntity
{
    protected Specification() { }

    protected Specification(Expression<Func<TEntity, bool>> criteria)
    {
        Criteria = criteria;
    }

    public Expression<Func<TEntity, bool>>? Criteria { get; }
    public ICollection<Expression<Func<TEntity, object>>> Includes { get; } = [];
    public ICollection<string> IncludeStrings { get; } = [];
    public Expression<Func<TEntity, object>>? OrderBy { get; private set; }
    public Expression<Func<TEntity, object>>? OrderByDescending { get; private set; }
    public Expression<Func<TEntity, object>>? GroupBy { get; private set; }
    public int Take { get; private set; }
    public int Skip { get; private set; }
    public bool IsPagingEnabled { get; private set; } = false;
    public bool IsAsNoTracking { get; private set; } = true;
}
