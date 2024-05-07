using MessengerX.Domain.Entities;

namespace MessengerX.Domain.Specification;

public class DefaultSpec<TEntity> : Specification<TEntity>
    where TEntity : BaseEntity
{
    public DefaultSpec()
    {
        ApplyTracking();
    }
}
