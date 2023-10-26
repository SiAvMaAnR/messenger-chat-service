namespace MessengerX.Domain.Shared.Models;

public class Confirmation
{
    public string Login { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public DateOnly? DateOfBirth { get; set; }
}
