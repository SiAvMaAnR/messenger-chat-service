namespace MessengerX.Application.Services.AccountService.Models;

public class AccountServiceRevokeTokenRequest
{
    public string RefreshToken { get; set; } = null!;
}
