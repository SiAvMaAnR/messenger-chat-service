using Messenger.Domain.Entities.Accounts;
using Messenger.Domain.Entities.Admins;
using Messenger.Domain.Entities.Channels;
using Messenger.Domain.Entities.Messages;
using Messenger.Domain.Entities.RefreshTokens;
using Messenger.Domain.Entities.Users;

namespace Messenger.Domain.Common;

public partial interface IUnitOfWork
{
    IAccountRepository Account { get; }
    IUserRepository User { get; }
    IAdminRepository Admin { get; }
    IRefreshTokenRepository RefreshToken { get; }
    IChannelRepository Channel { get; }
    IMessageRepository Message { get; }
}
