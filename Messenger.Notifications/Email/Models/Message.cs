namespace MessengerX.Notifications.Email.Models;

public class Message
{
    public Address From { get; set; } = null!;
    public Address To { get; set; } = null!;
    public string Subject { get; set; } = null!;
    public string Content { get; set; } = null!;
}
