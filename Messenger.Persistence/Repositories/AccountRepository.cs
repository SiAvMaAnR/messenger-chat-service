using Messenger.Domain.Entities.Accounts;
using Messenger.Persistence.DBContext;
using Messenger.Persistence.Repositories.Common;

namespace Messenger.Persistence.Repositories;

public class AccountRepository : BaseRepository<Account>, IAccountRepository
{
    public AccountRepository(EFContext dbContext)
        : base(dbContext) { }
}
