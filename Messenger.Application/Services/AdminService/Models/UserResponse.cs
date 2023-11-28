namespace MessengerX.Application.Services.AdminService.Models;

public class AdminServiceUserResponse
{
    public string Login { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Role { get; set; } = null!;
    public string? Image { get; set; }
    public DateOnly? Birthday { get; set; }
}
