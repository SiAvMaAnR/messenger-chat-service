using MessengerX.Domain.Exceptions.ApiExceptions;
using MessengerX.Domain.Exceptions.Common;
using MessengerX.Domain.Exceptions.StatusCode;

namespace MessengerX.Domain.Exceptions.BusinessExceptions;

public class AccessException : ForbiddenException, IBusinessException
{
    public const BusinessStatusCode Code = BusinessStatusCode.E001;

    public AccessException(string systemMessage, string clientMessage)
        : base(systemMessage, clientMessage) { }

    public AccessException(string systemMessage, ClientMessageSettings clientMessageSettings)
        : base(systemMessage, clientMessageSettings) { }

    public AccessException(string systemMessage)
        : base(systemMessage) { }
}
