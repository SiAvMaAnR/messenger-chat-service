using Messenger.Domain.Entities;

namespace Messenger.Domain.Specification;

public class DefaultSpec<TEntity> : Specification<TEntity>
    where TEntity : BaseEntity
{
    public DefaultSpec()
    {
        ApplyTracking();
    }
}
