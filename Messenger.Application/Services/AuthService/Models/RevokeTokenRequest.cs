namespace MessengerX.Application.Services.AuthService.Models;

public class AuthServiceRevokeTokenRequest
{
    public string RefreshToken { get; set; } = null!;
}
