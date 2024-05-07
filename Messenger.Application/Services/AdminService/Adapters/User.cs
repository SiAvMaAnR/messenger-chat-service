using MessengerX.Application.Services.AdminService.Models;
using MessengerX.Domain.Entities.Users;
using MessengerX.Persistence.Extensions;

namespace MessengerX.Application.Services.AdminService.Adapters;

public class AdminServiceUserAdapter : AdminServiceUserResponseData
{
    private readonly string? _imagePath;

    public AdminServiceUserAdapter(User user)
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
