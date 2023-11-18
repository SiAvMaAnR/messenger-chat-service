using MessengerX.Domain.Exceptions.Common;
using MessengerX.Domain.Exceptions.StatusCode;

namespace MessengerX.Domain.Exceptions.ApiExceptions;

public class AlreadyExistsException : BadRequestException, IBusinessException
{
    public const BusinessStatusCode Code = BusinessStatusCode.E001;

    public AlreadyExistsException(string systemMessage, string clientMessage)
        : base(systemMessage, clientMessage) { }

    public AlreadyExistsException(string systemMessage, ClientMessageSettings clientMessageSettings)
        : base(systemMessage, clientMessageSettings) { }

    public AlreadyExistsException(string systemMessage)
        : base(systemMessage) { }
}
