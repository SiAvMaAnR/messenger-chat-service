using MessengerX.Application.Services.AdminService.Models;
using MessengerX.Domain.Entities.Users;

namespace MessengerX.Application.Services.AdminService.Adapters;

public class AdminServiceUserAdapter : AdminServiceUserResponsePayload
{
    public AdminServiceUserAdapter(User user)
    {
        Id = user.Id;
        Login = user.Login;
        Email = user.Email;
        Role = user.Role;
        Image = user.Image;
        Birthday = user.Birthday;
        CreatedAt = user.CreatedAt;
        UpdatedAt = user.UpdatedAt;
    }
}
