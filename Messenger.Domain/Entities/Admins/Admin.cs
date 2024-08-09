using Messenger.Domain.Entities.Accounts;
using Messenger.Domain.Shared.Constants.Common;

namespace Messenger.Domain.Entities.Admins;

public partial class Admin : Account
{
    public Admin(string email, string login, byte[] passwordHash, byte[] passwordSalt)
        : base(email, login, passwordHash, passwordSalt)
    {
        Role = AccountRole.Admin;
    }

    public bool IsActive { get; private set; } = true;
}
