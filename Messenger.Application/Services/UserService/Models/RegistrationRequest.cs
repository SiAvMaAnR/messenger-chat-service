namespace MessengerX.Application.Services.UserService.Models;

public class UserServiceRegistrationRequest
{
    public string Login { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public DateOnly? Birthday { get; set; }
}
