namespace Messenger.Application.Services.UserService.Models;

public class UserServiceRegistrationRequest
{
    public required string Login { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    public DateOnly? Birthday { get; set; }
}
