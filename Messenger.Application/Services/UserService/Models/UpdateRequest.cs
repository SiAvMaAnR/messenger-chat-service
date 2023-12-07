namespace MessengerX.Application.Services.UserService.Models;

public class UserServiceUpdateRequest
{
    public string Login { get; set; } = null!;
    public DateOnly? Birthday { get; set; }
}
