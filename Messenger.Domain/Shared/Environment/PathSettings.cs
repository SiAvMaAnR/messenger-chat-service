namespace MessengerX.Domain.Shared.Environment;

public class PathSettings
{
    public const string Path = "Path";

    public string Registration { get; set; } = null!;
    public string Confirmation { get; set; } = null!;
    public string ResetToken { get; set; } = null!;
}
