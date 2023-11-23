using MessengerX.Domain.Exceptions.ApiExceptions;
using MessengerX.Domain.Exceptions.Common;
using MessengerX.Domain.Exceptions.StatusCode;

namespace MessengerX.Domain.Exceptions.BusinessExceptions;

public class NotExistsException : NotFoundException, IBusinessException
{
    public const BusinessStatusCode Code = BusinessStatusCode.E004;

    public NotExistsException(string systemMessage, string clientMessage)
        : base(systemMessage, clientMessage) { }

    public NotExistsException(string systemMessage, ClientMessageSettings clientMessageSettings)
        : base(systemMessage, clientMessageSettings) { }

    public NotExistsException(string systemMessage)
        : base(systemMessage) { }
}
