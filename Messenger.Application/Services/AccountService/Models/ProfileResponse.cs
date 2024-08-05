namespace Messenger.Application.Services.AccountService.Models;

public class AccountServiceProfileResponse
{
    public required string Login { get; set; }
    public required string Email { get; set; }
    public required string Role { get; set; }
    public DateOnly? Birthday { get; set; }
}
