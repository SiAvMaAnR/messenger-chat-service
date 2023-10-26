namespace MessengerX.Application.Services.AccountService.Models;

public class LoginAccountResponse
{
    public string Token { get; set; } = null!;
    public string TokenType { get; set; } = null!;
}
