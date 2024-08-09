using Messenger.Domain.Entities.Users;
using Messenger.Persistence.DBContext;
using Messenger.Persistence.Repositories.Common;

namespace Messenger.Persistence.Repositories;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(EFContext dbContext)
        : base(dbContext) { }
}
