namespace MessengerX.Domain.Exceptions.Common;

public class ExceptionArgs
{
    public int Status { get; set; }
    public string? ClientMessage { get; set; }
    public string SystemMessage { get; set; } = null!;
    public string Type { get; set; } = null!;
}
