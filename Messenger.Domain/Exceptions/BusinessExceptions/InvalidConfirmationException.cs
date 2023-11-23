using MessengerX.Domain.Exceptions.ApiExceptions;
using MessengerX.Domain.Exceptions.Common;
using MessengerX.Domain.Exceptions.StatusCode;

namespace MessengerX.Domain.Exceptions.BusinessExceptions;

public class InvalidConfirmationException : ForbiddenException, IBusinessException
{
    public const BusinessStatusCode Code = BusinessStatusCode.E003;

    public InvalidConfirmationException(string systemMessage, string clientMessage)
        : base(systemMessage, clientMessage) { }

    public InvalidConfirmationException(
        string systemMessage,
        ClientMessageSettings clientMessageSettings
    )
        : base(systemMessage, clientMessageSettings) { }

    public InvalidConfirmationException(string systemMessage)
        : base(systemMessage) { }
}
