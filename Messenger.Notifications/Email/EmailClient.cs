using MailKit.Net.Smtp;
using MailKit.Security;
using Messenger.Notifications.Common;
using Messenger.Notifications.Email.Models;
using MimeKit;
using MimeKit.Text;

namespace Messenger.Notifications.Email;

public interface IEmailClient : INotificationClient { }

public class EmailClient : IEmailClient
{
    private readonly SmtpClient _smtpClient = new();
    private readonly SmtpConfig _smtpConfig;

    public EmailClient(SmtpConfig smtpConfig)
    {
        _smtpConfig = smtpConfig;
    }

    public async Task SendAsync(EmailMessage message)
    {
        MimeMessage emailMessage = CreateMessage(message);

        await ConnectAsync(_smtpConfig.Host, _smtpConfig.Port);
        await AuthenticateAsync(_smtpConfig.Email, _smtpConfig.Password);
        await SendEmailAsync(emailMessage);
        await DisconnectAsync();
    }

    private MimeMessage CreateMessage(EmailMessage message)
    {
        var emailMessage = new MimeMessage()
        {
            From = { new MailboxAddress(message.From.Name, message.From.Email) },
            To = { new MailboxAddress(message.To.Name, message.To.Email) },
            Subject = message.Subject,
            Body = new TextPart(TextFormat.Html) { Text = message.Content }
        };

        return emailMessage;
    }

    private async Task ConnectAsync(string host, int port)
    {
        await _smtpClient.ConnectAsync(host, port, SecureSocketOptions.StartTls);
    }

    private async Task AuthenticateAsync(string email, string password)
    {
        await _smtpClient.AuthenticateAsync(email, password);
    }

    private async Task SendEmailAsync(MimeMessage emailMessage)
    {
        await _smtpClient.SendAsync(emailMessage);
    }

    private async Task DisconnectAsync()
    {
        await _smtpClient.DisconnectAsync(true);
    }
}
