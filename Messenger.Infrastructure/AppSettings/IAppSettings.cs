using MessengerX.Domain.Shared.Environment;

namespace MessengerX.Infrastructure.AppSettings;

public interface IAppSettings
{
    CommonSettings Common { get; }
    SmtpSettings Smtp { get; }
    RoutePathSettings RoutePath { get; }
    FilePathSettings FilePath { get; }
    ClientSettings Client { get; }
    AuthSettings Auth { get; }
}
