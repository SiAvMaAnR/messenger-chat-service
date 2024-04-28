namespace MessengerX.Domain.Exceptions.Common;

public interface IException
{
    ApiStatusCode ApiStatusCode { get; }
    BusinessStatusCode BusinessStatusCode { get; }
    string? ClientMessage { get; }
}
