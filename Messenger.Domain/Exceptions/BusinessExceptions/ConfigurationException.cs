using MessengerX.Domain.Exceptions.ApiExceptions;
using MessengerX.Domain.Exceptions.Common;
using MessengerX.Domain.Exceptions.StatusCode;

namespace MessengerX.Domain.Exceptions.BusinessExceptions;

public class ConfigurationException : InternalServerException, IBusinessException
{
    public const BusinessStatusCode Code = BusinessStatusCode.E002;

    public ConfigurationException(string systemMessage, string clientMessage)
        : base(systemMessage, clientMessage) { }

    public ConfigurationException(string systemMessage, ClientMessageSettings clientMessageSettings)
        : base(systemMessage, clientMessageSettings) { }

    public ConfigurationException(string systemMessage)
        : base(systemMessage) { }
}
