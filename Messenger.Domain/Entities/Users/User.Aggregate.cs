using MessengerX.Domain.Shared.Constants.Common;

namespace MessengerX.Domain.Entities.Users;

public partial class User : IAggregateRoot
{
    public User(string email, string login, byte[] passwordHash, byte[] passwordSalt)
        : base(email, login, passwordHash, passwordSalt)
    {
        Role = AccountRole.User;
    }

    public void UpdateBirthday(DateOnly? birthday)
    {
        Birthday = birthday;
    }

    public void UpdateIsBanned(bool isBanned)
    {
        IsBanned = isBanned;
    }
}
