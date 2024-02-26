namespace MessengerX.Domain.Entities.Users;

public partial class User : IAggregateRoot
{
    public void UpdateIsBanned(bool isBanned)
    {
        IsBanned = isBanned;
    }
}
