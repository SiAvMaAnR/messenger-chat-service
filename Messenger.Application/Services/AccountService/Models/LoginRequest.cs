namespace MessengerX.Application.Services.AccountService.Models;

public class AccountServiceLoginRequest
{
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
}
