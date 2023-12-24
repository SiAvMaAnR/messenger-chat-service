using MessengerX.Domain.Shared.Settings;
using Microsoft.Extensions.Options;

namespace MessengerX.Infrastructure.AppSettings;

public class AppSettings(
    IOptions<CommonSettings> commonSettings,
    IOptions<SmtpSettings> smtpSettings,
    IOptions<RoutePathSettings> routePathSettings,
    IOptions<FilePathSettings> filePathSettings,
    IOptions<ClientSettings> clientSettings,
    IOptions<AuthSettings> authSettings
    ) : IAppSettings
{
    public CommonSettings Common { get; } = commonSettings.Value;
    public SmtpSettings Smtp { get; } = smtpSettings.Value;
    public RoutePathSettings RoutePath { get; } = routePathSettings.Value;
    public FilePathSettings FilePath { get; } = filePathSettings.Value;
    public ClientSettings Client { get; } = clientSettings.Value;
    public AuthSettings Auth { get; } = authSettings.Value;
}
