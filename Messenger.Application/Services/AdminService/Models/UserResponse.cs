namespace MessengerX.Application.Services.AdminService.Models;

public class AdminServiceUserResponse
{
    public int Id { get; set; }
    public string Login { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Role { get; set; } = null!;
    public byte[]? Image { get; set; }
    public DateOnly? Birthday { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}
