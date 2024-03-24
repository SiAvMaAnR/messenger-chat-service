namespace MessengerX.Domain.Entities.Accounts.RefreshTokens;

public partial class RefreshToken : IAggregateRoot
{
    public RefreshToken(string token, DateTime expiryTime, int accountId)
    {
        Token = token;
        ExpiryTime = expiryTime;
        AccountId = accountId;
    }
}
