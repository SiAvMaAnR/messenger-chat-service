using MessengerX.Domain.Exceptions.Common;
using MessengerX.Domain.Exceptions.StatusCode;

namespace MessengerX.Domain.Exceptions.ApiExceptions;

public class ForbiddenException : BaseException
{
    public const string DefaultType = "Forbidden";
    public const ApiStatusCode DefaultStatus = ApiStatusCode.Forbidden;

    public ForbiddenException(string systemMessage, string clientMessage)
        : base(
            new ExceptionArgs()
            {
                Type = DefaultType,
                Status = DefaultStatus,
                SystemMessage = systemMessage,
                ClientMessage = clientMessage,
                ClientMessageSettings = ClientMessageSettings.Custom
            }
        )
    { }

    public ForbiddenException(
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
        )
    { }
}
