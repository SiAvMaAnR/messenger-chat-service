namespace Messenger.Domain.Shared.Settings;

public class SmtpSettings
{
    public const string Path = "Smtp";

    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string Host { get; set; } = null!;
    public int Port { get; set; }
}
