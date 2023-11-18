using MessengerX.Domain.Shared.Environment;
using Microsoft.Extensions.Options;

namespace MessengerX.Infrastructure.AppSettings;

public class AppSettings : IAppSettings
{
    public CommonSettings Common { get; }
    public SmtpSettings Smtp { get; }
    public PathSettings Path { get; }
    public ClientSettings Client { get; }
    public AuthSettings Auth { get; }

    public AppSettings(
        IOptions<CommonSettings> commonSettings,
        IOptions<SmtpSettings> smtpSettings,
        IOptions<PathSettings> pathSettings,
        IOptions<ClientSettings> clientSettings,
        IOptions<AuthSettings> authSettings
    )
    {
        Common = commonSettings.Value;
        Smtp = smtpSettings.Value;
        Path = pathSettings.Value;
        Client = clientSettings.Value;
        Auth = authSettings.Value;
    }
}
