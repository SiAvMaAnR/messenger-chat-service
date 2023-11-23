using MessengerX.Domain.Exceptions.Common;
using MessengerX.Domain.Exceptions.StatusCode;

namespace MessengerX.Domain.Exceptions.ApiExceptions;

public class BadRequestException : BaseException
{
    public const string DefaultType = "Bad Request";
    public const ApiStatusCode DefaultStatus = ApiStatusCode.BadRequest;

    public BadRequestException(string systemMessage, string clientMessage)
        : base(
            new ExceptionArgs()
            {
                Type = DefaultType,
                Status = DefaultStatus,
                SystemMessage = systemMessage,
                ClientMessage = clientMessage,
                ClientMessageSettings = ClientMessageSettings.Custom
            }
        ) { }

    public BadRequestException(
        string systemMessage,
        ClientMessageSettings clientMessageSettings = ClientMessageSettings.Default
    )
        : base(
            new ExceptionArgs()
            {
                Type = DefaultType,
                Status = DefaultStatus,
                SystemMessage = systemMessage,
                ClientMessageSettings = clientMessageSettings
            }
        ) { }
}
