namespace MessengerX.Application.Services.UserService.Models;

public class RegistrationUserRequest
{
    public string Login { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public DateTime? Birthday { get; set; }
}
