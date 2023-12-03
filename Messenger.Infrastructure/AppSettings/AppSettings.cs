using MessengerX.Domain.Shared.Settings;
using Microsoft.Extensions.Options;

namespace MessengerX.Infrastructure.AppSettings;

public class AppSettings : IAppSettings
{
    public CommonSettings Common { get; }
    public SmtpSettings Smtp { get; }
    public RoutePathSettings RoutePath { get; }
    public FilePathSettings FilePath { get; }
    public ClientSettings Client { get; }
    public AuthSettings Auth { get; }

    public AppSettings(
        IOptions<CommonSettings> commonSettings,
        IOptions<SmtpSettings> smtpSettings,
        IOptions<RoutePathSettings> routePathSettings,
        IOptions<FilePathSettings> filePathSettings,
        IOptions<ClientSettings> clientSettings,
        IOptions<AuthSettings> authSettings
    )
    {
        Common = commonSettings.Value;
        Smtp = smtpSettings.Value;
        RoutePath = routePathSettings.Value;
        FilePath = filePathSettings.Value;
        Client = clientSettings.Value;
        Auth = authSettings.Value;
    }
}
