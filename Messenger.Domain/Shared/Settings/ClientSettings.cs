namespace MessengerX.Domain.Shared.Settings;

public class ClientSettings
{
    public const string Path = "Client";
    public required string BaseUrl { get; set; }
}
