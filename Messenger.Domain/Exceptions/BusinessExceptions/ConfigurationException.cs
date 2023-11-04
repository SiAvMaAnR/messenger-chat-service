namespace MessengerX.Domain.Exceptions.ApiExceptions;

public class ConfigurationException : BadRequestException
{
    public new const string ClientMessage = DefaultType;
    public const string Code = "E002";

    public ConfigurationException(string systemMessage, string clientMessage)
        : base(systemMessage, clientMessage) { }

    public ConfigurationException(string systemMessage)
        : base(systemMessage, ClientMessage) { }
}
