using MessengerX.Domain.Shared.Models;

namespace MessengerX.Infrastructure.NotificationTemplates;

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
