using MessengerX.Domain.Entities.Accounts;

namespace MessengerX.Domain.Entities.Users;

public partial class User : Account
{
    public DateOnly? Birthday { get; set; }
    public bool IsBanned { get; set; } = false;
}
