namespace Messenger.Application.Services.UserService.Models;

public class UserServiceUserRequest
{
    public int Id { get; set; }

    public bool IsLoadImage { get; set; } = false;
}
