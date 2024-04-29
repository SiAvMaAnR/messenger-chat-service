namespace MessengerX.Application.Services.UserService.Models;

public class UserServiceProfileResponse
{
    public required string Login { get; set; }
    public required string Email { get; set; }
    public required string Role { get; set; }
    public DateOnly? Birthday { get; set; }
}
