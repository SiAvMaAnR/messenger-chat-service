using MessengerX.Domain.Exceptions.Common;
using MessengerX.Domain.Exceptions.StatusCode;

namespace MessengerX.Domain.Exceptions.ApiExceptions;

public class UnauthorizedException : BaseException
{
    public const string DefaultType = "Unauthorized";
    public const ApiStatusCode DefaultStatus = ApiStatusCode.Unauthorized;

    public UnauthorizedException(string systemMessage, string clientMessage)
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

    public UnauthorizedException(
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
