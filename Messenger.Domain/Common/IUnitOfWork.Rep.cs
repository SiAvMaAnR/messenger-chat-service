using MessengerX.Domain.Entities.Accounts;
using MessengerX.Domain.Entities.Admins;
using MessengerX.Domain.Entities.RefreshTokens;
using MessengerX.Domain.Entities.Users;

namespace MessengerX.Domain.Interfaces.UnitOfWork;

public partial interface IUnitOfWork
{
    IAccountRepository Account { get; }
    IUserRepository User { get; }
    IAdminRepository Admin { get; }
    IRefreshTokenRepository RefreshToken { get; }
}
