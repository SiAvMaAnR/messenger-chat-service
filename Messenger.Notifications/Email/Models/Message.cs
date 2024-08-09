namespace Messenger.Notifications.Email.Models;

public class EmailMessage
{
    public required EmailAddress From { get; set; }
    public required EmailAddress To { get; set; }
    public required string Subject { get; set; }
    public required string Content { get; set; }
}
