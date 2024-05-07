using MessengerX.Domain.Entities.Channels;
using MessengerX.Domain.Entities.Messages;
using MessengerX.Domain.Entities.RefreshTokens;

namespace MessengerX.Domain.Entities.Accounts;

public partial class Account : IAggregateRoot
{
    public void UpdateLogin(string login)
    {
        Login = login;
    }

    public void UpdateActivityStatus(string activityStatus)
    {
        ActivityStatus = activityStatus;
    }

    public void UpdateImage(string? image)
    {
        Image = image;
    }

    public void AddRefreshToken(RefreshToken refreshToken)
    {
        RefreshTokens.Add(refreshToken);
    }

    public void UpdatePassword(byte[] passwordHash, byte[] passwordSalt)
    {
        PasswordHash = passwordHash;
        PasswordSalt = passwordSalt;
    }

    public void AddChannel(Channel channel)
    {
        Channels.Add(channel);
    }

    public void AddReadMessage(Message message)
    {
        ReadMessages.Add(message);
    }

    public void AddMessage(Message message)
    {
        Messages.Add(message);
    }
}
