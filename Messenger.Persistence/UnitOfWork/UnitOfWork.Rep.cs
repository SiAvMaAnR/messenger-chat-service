using MessengerX.Domain.Entities.Accounts;
using MessengerX.Domain.Entities.Accounts.RefreshTokens;
using MessengerX.Domain.Entities.Admins;
using MessengerX.Domain.Entities.Channels;
using MessengerX.Domain.Entities.Channels.Messages;
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
    public IMessageRepository Message { get; } = new MessageRepository(eFContext);
    public IChannelRepository Channel { get; } = new ChannelRepository(eFContext);
}
