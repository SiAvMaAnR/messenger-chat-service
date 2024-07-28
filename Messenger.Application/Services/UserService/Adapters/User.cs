using MessengerX.Application.Services.UserService.Models;
using MessengerX.Domain.Entities.Users;
using MessengerX.Persistence.Extensions;

namespace MessengerX.Application.Services.UserService.Adapters;

public class UserServiceUserAdapter : UserServiceUserResponseData
{
    private readonly string? _imagePath;

    public UserServiceUserAdapter(User user)
    {
        _imagePath = user.Image;

        Id = user.Id;
        Login = user.Login;
        Email = user.Email;
        Role = user.Role;
        Birthday = user.Birthday;
        IsBanned = user.IsBanned;
        ActivityStatus = user.ActivityStatus;
        CreatedAt = user.CreatedAt;
        UpdatedAt = user.UpdatedAt;
    }

    public async Task LoadImageAsync()
    {
        Image = await FileManager.ReadToBytesAsync(_imagePath);
    }
}
