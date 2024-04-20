using MessengerX.Domain.Entities.Accounts;
using MessengerX.Domain.Entities.Accounts.RefreshTokens;
using MessengerX.Domain.Entities.Admins;
using MessengerX.Domain.Entities.Channels;
using MessengerX.Domain.Entities.Channels.Messages;
using MessengerX.Domain.Entities.Users;

namespace MessengerX.Domain.Interfaces.UnitOfWork;

public partial interface IUnitOfWork
{
    IAccountRepository Account { get; }
    IUserRepository User { get; }
    IAdminRepository Admin { get; }
    IRefreshTokenRepository RefreshToken { get; }
    IChannelRepository Channel { get; }
    IMessageRepository Message { get; }
}
