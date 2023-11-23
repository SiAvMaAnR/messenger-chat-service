namespace MessengerX.Application.Services.AccountService.Models;

public class AccountServiceResetPasswordRequest
{
    public string ResetToken { get; set; } = null!;
    public string Password { get; set; } = null!;
}
