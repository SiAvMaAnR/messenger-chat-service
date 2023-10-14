namespace MessengerX.Domain.Shared.Types;

public class PasswordType
{
    public byte[] Salt { get; set; } = null!;
    public byte[] Hash { get; set; } = null!;
}
