namespace Messenger.Application.Services.UserService.Models;

public class UserServiceUserResponse
{
    public int Id { get; set; }
    public required string Login { get; set; }
    public required string Email { get; set; }
    public required string Role { get; set; }
    public byte[]? Image { get; set; }
    public DateOnly? Birthday { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}
