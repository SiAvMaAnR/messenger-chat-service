namespace Messenger.Application.Services.UserService.Models;

public class UserServiceUpdateRequest
{
    public required string Login { get; set; }
    public DateOnly? Birthday { get; set; }
}
