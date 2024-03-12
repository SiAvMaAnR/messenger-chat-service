using MessengerX.Domain.Entities.Accounts.RefreshTokens;
using MessengerX.Persistence.DBContext;
using MessengerX.Persistence.Repositories.Common;

namespace MessengerX.Persistence.Repositories;

public class RefreshTokenRepository : BaseRepository<RefreshToken>, IRefreshTokenRepository
{
    public RefreshTokenRepository(EFContext dbContext)
        : base(dbContext) { }
}
