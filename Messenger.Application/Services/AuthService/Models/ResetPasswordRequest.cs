namespace MessengerX.Application.Services.AuthService.Models;

public class AuthServiceResetPasswordRequest
{
    public string ResetToken { get; set; } = null!;
    public string Password { get; set; } = null!;
}
