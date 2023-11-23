using MessengerX.Domain.Exceptions.ApiExceptions;
using MessengerX.Domain.Exceptions.Common;
using MessengerX.Domain.Exceptions.StatusCode;

namespace MessengerX.Domain.Exceptions.BusinessExceptions;

public class AlreadyExistsException : InternalServerException, IBusinessException
{
    public const BusinessStatusCode Code = BusinessStatusCode.E001;

    public AlreadyExistsException(string systemMessage, string clientMessage)
        : base(systemMessage, clientMessage) { }

    public AlreadyExistsException(string systemMessage, ClientMessageSettings clientMessageSettings)
        : base(systemMessage, clientMessageSettings) { }

    public AlreadyExistsException(string systemMessage)
        : base(systemMessage) { }
}
