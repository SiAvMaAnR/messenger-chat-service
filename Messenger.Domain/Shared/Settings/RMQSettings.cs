namespace Messenger.Domain.Shared.Settings;

public class RMQSettings
{
    public const string Path = "RMQ";
    public string HostName { get; set; } = null!;
    public string UserName { get; set; } = null!;
    public string Password { get; set; } = null!;
    public int Timeout { get; set; }
}
