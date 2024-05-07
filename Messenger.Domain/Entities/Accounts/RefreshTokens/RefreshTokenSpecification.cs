using MessengerX.Domain.Entities.RefreshTokens;
using MessengerX.Domain.Specification;

namespace MessengerX.Domain.Entities.Accounts;

public class RefreshTokenByTokenSpec : Specification<RefreshToken>
{
    public RefreshTokenByTokenSpec(string? refreshToken)
        : base((token) => token.Token == refreshToken) { }
}
