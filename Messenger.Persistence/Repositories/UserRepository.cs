using MessengerX.Domain.Entities.Users;
using MessengerX.Persistence.DBContext;
using MessengerX.Persistence.Repositories.Common;

namespace MessengerX.Persistence.Repositories;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(EFContext dbContext)
        : base(dbContext) { }
}
