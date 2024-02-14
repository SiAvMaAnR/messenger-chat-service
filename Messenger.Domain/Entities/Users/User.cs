using MessengerX.Domain.Entities.Accounts;
using MessengerX.Domain.Shared.Constants.Common;

namespace MessengerX.Domain.Entities.Users;

public partial class User : Account
{
    public DateOnly? Birthday { get; set; }

    public bool IsBanned { get; set; } = false;

    public User()
    {
        Role = AccountRole.User;
    }
}
