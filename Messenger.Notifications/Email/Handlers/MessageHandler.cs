using MessengerX.Notifications.Email.Models;
using MessengerX.Notifications.Email.Interfaces;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;

namespace MessengerX.Notifications.Email.Handlers;

public class MessageHandler : IHandler
{
    private Smtp _smtp;

    public MessageHandler(Smtp smtp)
    {
        _smtp = smtp;
    }

    public async Task SendAsync(MimeMessage message)
    {
        using var client = new SmtpClient();
        await client.ConnectAsync(_smtp.Host, _smtp.Port, SecureSocketOptions.StartTls);
        await client.AuthenticateAsync(_smtp.Email, _smtp.Password);
        await client.SendAsync(message);
        await client.DisconnectAsync(true);
    }
}
