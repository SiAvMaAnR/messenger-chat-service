using MessengerX.Domain.Exceptions.StatusCode;

namespace MessengerX.Domain.Exceptions.Common;

public class ExceptionArgs
{
    public ApiStatusCode Status { get; set; }
    public string? ClientMessage { get; set; }
    public string SystemMessage { get; set; } = null!;
    public string Type { get; set; } = null!;
    public ClientMessageSettings ClientMessageSettings { get; set; }
}
