namespace MessengerX.Application.Services.UserService.Models;

public class UserServiceProfileResponse
{
    public string Login { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Role { get; set; } = null!;
    public DateTime? Birthday { get; set; }
}
