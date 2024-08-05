using Messenger.Domain.Entities.Accounts;
using Messenger.Domain.Entities.Admins;
using Messenger.Domain.Entities.Channels;
using Messenger.Domain.Entities.Messages;
using Messenger.Domain.Entities.RefreshTokens;
using Messenger.Domain.Entities.Users;
using Messenger.Persistence.DBContext;
using Messenger.Persistence.Repositories;

namespace Messenger.Persistence.UnitOfWork;

public partial class UnitOfWork(EFContext eFContext)
{
    private readonly EFContext _eFContext = eFContext;

    public IUserRepository User { get; } = new UserRepository(eFContext);
    public IAccountRepository Account { get; } = new AccountRepository(eFContext);
    public IAdminRepository Admin { get; } = new AdminRepository(eFContext);
    public IRefreshTokenRepository RefreshToken { get; } = new RefreshTokenRepository(eFContext);
    public IMessageRepository Message { get; } = new MessageRepository(eFContext);
    public IChannelRepository Channel { get; } = new ChannelRepository(eFContext);
}
