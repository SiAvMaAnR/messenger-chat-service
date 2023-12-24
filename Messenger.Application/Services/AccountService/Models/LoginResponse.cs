namespace MessengerX.Application.Services.AccountService.Models;

public class AccountServiceLoginResponse
{
    public string AccessToken { get; set; } = null!;
    public string RefreshToken { get; set; } = null!;
    public DateTime RefreshTokenExp { get; set; }
}
