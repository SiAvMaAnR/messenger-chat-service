using MessengerX.Domain.Exceptions.Common;
using MessengerX.Domain.Exceptions.StatusCode;

namespace MessengerX.Domain.Exceptions.ApiExceptions;

public class InvalidCredentialsException : UnauthorizedException, IBusinessException
{
    public const BusinessStatusCode Code = BusinessStatusCode.E005;

    public InvalidCredentialsException(string systemMessage, string clientMessage)
        : base(systemMessage, clientMessage) { }

    public InvalidCredentialsException(
        string systemMessage,
        ClientMessageSettings clientMessageSettings
    )
        : base(systemMessage, clientMessageSettings) { }

    public InvalidCredentialsException(string systemMessage)
        : base(systemMessage) { }
}
