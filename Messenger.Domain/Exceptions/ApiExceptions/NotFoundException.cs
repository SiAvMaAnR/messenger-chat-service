using MessengerX.Domain.Exceptions.Common;
using MessengerX.Domain.Exceptions.StatusCode;

namespace MessengerX.Domain.Exceptions.ApiExceptions;

public class NotFoundException : BaseException
{
    public const string DefaultType = "Not Found";
    public const ApiStatusCode DefaultStatus = ApiStatusCode.NotFound;

    public NotFoundException(string systemMessage, string clientMessage)
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

    public NotFoundException(
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
