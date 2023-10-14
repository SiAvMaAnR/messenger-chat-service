namespace MessengerX.Domain.Exceptions.ApiExceptions;

public class UnknownException : BadRequestException
{
    public const string SystemMessage = DefaultClientMessage;
    public new const string ClientMessage = DefaultClientMessage;

    public UnknownException()
        : base(SystemMessage, ClientMessage) { }
}
