namespace MessengerX.Domain.Shared.Settings;

public class FilePathSettings
{
    public const string Path = "FilePath";

    public string Image { get; set; } = null!;
    public string Logger { get; set; } = null!;
}
