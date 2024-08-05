namespace Messenger.Domain.Shared.Models;

public class Confirmation
{
    public required string Login { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    public DateOnly? Birthday { get; set; }
    public DateTime ExpirationDate { get; set; }
}
