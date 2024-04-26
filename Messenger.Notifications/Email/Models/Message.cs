namespace MessengerX.Notifications.Email.Models;

public class EmailMessage
{
    public EmailAddress From { get; set; } = null!;
    public EmailAddress To { get; set; } = null!;
    public string Subject { get; set; } = null!;
    public string Content { get; set; } = null!;
}
