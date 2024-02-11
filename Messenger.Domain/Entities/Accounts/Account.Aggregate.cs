namespace MessengerX.Domain.Entities.Accounts;

public partial class Account : IAggregateRoot
{
    public void UpdateActivityStatus(string activityStatus)
    {
        ActivityStatus = activityStatus;
    }

    public void UpdateImage(string? image)
    {
        Image = image;
    }
}
