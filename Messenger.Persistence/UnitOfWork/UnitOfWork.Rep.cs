using MessengerX.Domain.Entities.Accounts;
using MessengerX.Domain.Entities.Users;
using MessengerX.Persistence.DBContext;
using MessengerX.Persistence.Repositories;

namespace MessengerX.Persistence.UnitOfWork;

public partial class UnitOfWork
{
    private readonly EFContext _eFContext;

    public IUserRepository User { get; }
    public IAccountRepository Account { get; }

    public UnitOfWork(EFContext eFContext)
    {
        _eFContext = eFContext;
        User = new UserRepository(eFContext);
        Account = new AccountRepository(eFContext);
    }
}
