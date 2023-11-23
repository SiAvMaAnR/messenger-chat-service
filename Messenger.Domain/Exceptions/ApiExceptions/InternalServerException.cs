using MessengerX.Domain.Exceptions.Common;
using MessengerX.Domain.Exceptions.StatusCode;

namespace MessengerX.Domain.Exceptions.ApiExceptions;

public class InternalServerException : BaseException
{
    public const string DefaultType = "Internal Server Error";
    public const ApiStatusCode DefaultStatus = ApiStatusCode.InternalServer;

    public InternalServerException(string systemMessage, string clientMessage)
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

    public InternalServerException(
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
