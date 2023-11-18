using MessengerX.Domain.Entities.Accounts;
using MessengerX.Persistence.DBContext;
using MessengerX.Persistence.Repositories.Common;

namespace MessengerX.Persistence.Repositories;

public class AccountRepository : BaseRepository<Account>, IAccountRepository
{
    public AccountRepository(EFContext dbContext)
        : base(dbContext) { }
}
