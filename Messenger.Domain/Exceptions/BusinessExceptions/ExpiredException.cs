using MessengerX.Domain.Exceptions.ApiExceptions;
using MessengerX.Domain.Exceptions.Common;
using MessengerX.Domain.Exceptions.StatusCode;

namespace MessengerX.Domain.Exceptions.BusinessExceptions;

public class ExpiredException : BadRequestException, IBusinessException
{
    public const BusinessStatusCode Code = BusinessStatusCode.E008;

    public ExpiredException(string systemMessage, string clientMessage)
        : base(systemMessage, clientMessage) { }

    public ExpiredException(string systemMessage, ClientMessageSettings clientMessageSettings)
        : base(systemMessage, clientMessageSettings) { }

    public ExpiredException(string systemMessage)
        : base(systemMessage) { }
}
