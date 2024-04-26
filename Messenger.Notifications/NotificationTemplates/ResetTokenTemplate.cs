using MessengerX.Notifications.Common;

namespace MessengerX.Notifications.NotificationTemplates;

public static partial class NotificationTemplate
{
    public static EmailTemplate ResetToken(string link)
    {
        return new EmailTemplate()
        {
            Subject = $"MessengerX",
            Content = $"<p>Reset password link:</p> {link}"
        };
    }
}
