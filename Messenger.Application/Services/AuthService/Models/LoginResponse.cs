namespace MessengerX.Application.Services.AuthService.Models;

public class AuthServiceLoginResponse
{
    public string AccessToken { get; set; } = null!;
    public string RefreshToken { get; set; } = null!;
    public DateTime RefreshTokenExp { get; set; }
}
