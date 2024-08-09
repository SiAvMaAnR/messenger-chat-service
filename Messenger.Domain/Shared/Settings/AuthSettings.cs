namespace Messenger.Domain.Shared.Settings;

public class AuthSettings
{
    public const string Path = "Auth";
    public string Audience { get; set; } = null!;
    public string Issuer { get; set; } = null!;
    public string AccessTokenLifeTime { get; set; } = null!;
    public string RefreshTokenLifeTime { get; set; } = null!;
}
