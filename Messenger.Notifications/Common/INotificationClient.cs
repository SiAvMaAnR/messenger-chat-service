using Messenger.Notifications.Email.Models;

namespace Messenger.Notifications.Common;

public interface INotificationClient
{
    Task SendAsync(EmailMessage message);
}
