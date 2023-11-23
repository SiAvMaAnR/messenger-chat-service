namespace MessengerX.Domain.Shared.Environment;

public class RoutePathSettings
{
    public const string Path = "RoutePath";

    public string Registration { get; set; } = null!;
    public string Confirmation { get; set; } = null!;
    public string ResetToken { get; set; } = null!;
}
