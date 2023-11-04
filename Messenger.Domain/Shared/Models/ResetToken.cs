namespace MessengerX.Domain.Shared.Models;

public class ResetToken
{
    public int Id { get; set; }
    public string Email { get; set; } = null!;
}
