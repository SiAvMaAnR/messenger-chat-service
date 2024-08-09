namespace Messenger.Domain.Entities.Users;

public partial class User : IAggregateRoot
{
    public void UpdateBirthday(DateOnly? birthday)
    {
        Birthday = birthday;
    }

    public void UpdateIsBanned(bool isBanned)
    {
        IsBanned = isBanned;
    }
}
