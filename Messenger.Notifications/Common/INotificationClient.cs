using MessengerX.Notifications.Email.Models;

namespace MessengerX.Notifications.Common;

public interface INotificationClient
{
    Task SendAsync(Message message);
}
