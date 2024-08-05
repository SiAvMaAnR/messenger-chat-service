using Messenger.Domain.Entities.RefreshTokens;
using Messenger.Domain.Specification;

namespace Messenger.Domain.Entities.Accounts;

public class RefreshTokenByTokenSpec : Specification<RefreshToken>
{
    public RefreshTokenByTokenSpec(string? refreshToken)
        : base((token) => token.Token == refreshToken) { }
}
