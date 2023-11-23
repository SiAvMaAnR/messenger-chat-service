using MessengerX.Domain.Exceptions.ApiExceptions;
using MessengerX.Domain.Exceptions.Common;
using MessengerX.Domain.Exceptions.StatusCode;

namespace MessengerX.Domain.Exceptions.BusinessExceptions;

public class IncorrectDataException : InternalServerException, IBusinessException
{
    public const BusinessStatusCode Code = BusinessStatusCode.E007;

    public IncorrectDataException(string systemMessage, string clientMessage)
        : base(systemMessage, clientMessage) { }

    public IncorrectDataException(string systemMessage, ClientMessageSettings clientMessageSettings)
        : base(systemMessage, clientMessageSettings) { }

    public IncorrectDataException(string systemMessage)
        : base(systemMessage) { }
}
