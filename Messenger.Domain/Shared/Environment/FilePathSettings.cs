namespace MessengerX.Domain.Shared.Environment;

public class FilePathSettings
{
    public const string Path = "FilePath";

    public string Image { get; set; } = null!;
    public string Logger { get; set; } = null!;
}
