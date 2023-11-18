using MimeKit;

namespace MessengerX.Notifications.Email.Interfaces;

public interface IHandler
{
    Task SendAsync(MimeMessage message);
}
