using Messenger.Notifications.Common;

namespace Messenger.Notifications.NotificationTemplates;

public static partial class NotificationTemplate
{
    public static EmailTemplate ResetToken(string link)
    {
        return new EmailTemplate()
        {
            Subject = $"Messenger",
            Content = $"<p>Reset password link:</p> {link}"
        };
    }
}
