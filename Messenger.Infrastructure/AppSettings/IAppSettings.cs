using MessengerX.Domain.Shared.Environment;

namespace MessengerX.Infrastructure.AppSettings;

public interface IAppSettings
{
    CommonSettings Common { get; }
    SmtpSettings Smtp { get; }
    PathSettings Path { get; }
    ClientSettings Client { get; }
    AuthSettings Auth { get; }
}
