using MessengerX.Domain.Entities.Accounts;
using MessengerX.Domain.Shared.Constants.Common;

namespace MessengerX.Domain.Entities.Admins;

public partial class Admin : Account
{
    public Admin(string email, string login, byte[] passwordHash, byte[] passwordSalt)
        : base(email, login, passwordHash, passwordSalt)
    {
        Role = AccountRole.Admin;
    }

    public bool IsActive { get; private set; } = true;
}
