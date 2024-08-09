using Messenger.Notifications.Common;

namespace Messenger.Notifications.NotificationTemplates;

public static partial class NotificationTemplate
{
    public static EmailTemplate Registration(string link)
    {
        return new EmailTemplate()
        {
            Subject = $"Messenger",
            Content = $"<p>Confirmation link:</p> {link}"
        };
    }
}
