namespace MessengerX.Application.Services.AuthService.Models;

public class AuthServiceLoginRequest
{
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
}
