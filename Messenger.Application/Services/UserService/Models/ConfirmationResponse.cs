namespace Messenger.Application.Services.UserService.Models;

public class UserServiceConfirmationResponse
{
    public required string Email { get; set; }
    public required string Password { get; set; }
}
