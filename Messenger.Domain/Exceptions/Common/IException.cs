using MessengerX.Domain.Exceptions.StatusCode;

namespace MessengerX.Domain.Exceptions.Common;

public interface IException
{
    ApiStatusCode Status { get; }
    string Type { get; }
    string? ClientMessage { get; }
}
