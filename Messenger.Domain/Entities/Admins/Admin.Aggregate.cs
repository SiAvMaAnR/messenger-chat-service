using MessengerX.Domain.Shared.Constants.Common;

namespace MessengerX.Domain.Entities.Admins;

public partial class Admin : IAggregateRoot
{
    public Admin(string email, string login, byte[] passwordHash, byte[] passwordSalt)
        : base(email, login, passwordHash, passwordSalt)
    {
        Role = AccountRole.Admin;
    }

    public void UpdateActive(bool isActive)
    {
        IsActive = isActive;
    }
}
