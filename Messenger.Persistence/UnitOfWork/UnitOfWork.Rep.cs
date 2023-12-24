using MessengerX.Domain.Entities.Accounts;
using MessengerX.Domain.Entities.Admins;
using MessengerX.Domain.Entities.RefreshTokens;
using MessengerX.Domain.Entities.Users;
using MessengerX.Persistence.DBContext;
using MessengerX.Persistence.Repositories;

namespace MessengerX.Persistence.UnitOfWork;

public partial class UnitOfWork(EFContext eFContext)
{
    private readonly EFContext _eFContext = eFContext;

    public IUserRepository User { get; } = new UserRepository(eFContext);
    public IAccountRepository Account { get; } = new AccountRepository(eFContext);
    public IAdminRepository Admin { get; } = new AdminRepository(eFContext);
    public IRefreshTokenRepository RefreshToken { get; } = new RefreshTokenRepository(eFContext);
}
