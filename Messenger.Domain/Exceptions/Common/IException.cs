namespace CSN.Domain.Exceptions.Common;

public interface IException
{
    int Status { get; }
    string Type { get; }
    string? ClientMessage { get; }
}
