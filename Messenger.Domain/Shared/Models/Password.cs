namespace MessengerX.Domain.Shared.Models;

public class Password
{
    public byte[] Salt { get; set; } = null!;
    public byte[] Hash { get; set; } = null!;
}
