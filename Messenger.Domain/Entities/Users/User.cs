using MessengerX.Domain.Entities.Accounts;
using MessengerX.Domain.Shared.Constants.Common;

namespace MessengerX.Domain.Entities.Users;

public partial class User : Account
{
    public User(string email, string login, byte[] passwordHash, byte[] passwordSalt)
        : base(email, login, passwordHash, passwordSalt)
    {
        Role = AccountRole.User;
    }

    public DateOnly? Birthday { get; set; }
    public bool IsBanned { get; set; } = false;
}
