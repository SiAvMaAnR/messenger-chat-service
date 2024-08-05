namespace Messenger.Domain.Shared.Settings;

public class RoutePathSettings
{
    public const string Path = "RoutePath";

    public string ConfirmRegistration { get; set; } = null!;
    public string ResetToken { get; set; } = null!;
}
