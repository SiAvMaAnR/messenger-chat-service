namespace Messenger.Domain.Entities.Admins;

public partial class Admin : IAggregateRoot
{
    public void UpdateActive(bool isActive)
    {
        IsActive = isActive;
    }
}
