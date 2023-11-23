using MessengerX.Domain.Exceptions.ApiExceptions;
using MessengerX.Domain.Exceptions.Common;
using MessengerX.Domain.Exceptions.StatusCode;

namespace MessengerX.Domain.Exceptions.BusinessExceptions;

public class PasswordException : InternalServerException, IBusinessException
{
    public const BusinessStatusCode Code = BusinessStatusCode.E006;

    public PasswordException(string systemMessage, string clientMessage)
        : base(systemMessage, clientMessage) { }

    public PasswordException(string systemMessage, ClientMessageSettings clientMessageSettings)
        : base(systemMessage, clientMessageSettings) { }

    public PasswordException(string systemMessage)
        : base(systemMessage) { }
}
