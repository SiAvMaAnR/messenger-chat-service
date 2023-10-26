namespace MessengerX.Application.Services.AccountService.Models;

public class LoginAccountRequest
{
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
}