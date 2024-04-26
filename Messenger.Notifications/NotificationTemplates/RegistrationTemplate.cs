using MessengerX.Notifications.Common;

namespace MessengerX.Notifications.NotificationTemplates;

public static partial class NotificationTemplate
{
    public static EmailTemplate Registration(string link)
    {
        return new EmailTemplate()
        {
            Subject = $"MessengerX",
            Content = $"<p>Confirmation link:</p> {link}"
        };
    }
}
