using MessengerX.Domain.Entities.Accounts;

namespace MessengerX.Domain.Entities.Admins;

public partial class Admin : Account
{
    public bool IsActive { get; private set; } = true;
}
