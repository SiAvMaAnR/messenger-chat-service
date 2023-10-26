using MessengerX.Notifications.Common;
using MessengerX.Notifications.Email.Interfaces;
using MessengerX.Notifications.Email.Models;
using MimeKit;
using MimeKit.Text;

namespace MessengerX.Notifications;

public class EmailClient : INotificationClient
{
    private readonly IHandler _messageHandler;

    public EmailClient(IHandler handler)
    {
        _messageHandler = handler;
    }

    public async Task SendAsync(Message message)
    {
        var emailMessage = new MimeMessage();

        emailMessage.From.Add(new MailboxAddress(message.From.Name, message.From.Email));
        emailMessage.To.Add(new MailboxAddress(message.To.Name, message.To.Email));
        emailMessage.Subject = message.Subject;
        emailMessage.Body = new TextPart(TextFormat.Html) { Text = message.Content };

        await _messageHandler.SendAsync(emailMessage);
    }
}
