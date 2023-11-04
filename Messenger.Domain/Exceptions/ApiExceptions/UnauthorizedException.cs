using MessengerX.Domain.Exceptions.Common;

namespace MessengerX.Domain.Exceptions.ApiExceptions;

public class UnauthorizedException : BaseException
{
    public const string DefaultType = "Unauthorized";
    public const int DefaultStatus = 401;

    public UnauthorizedException(string systemMessage, string clientMessage)
        : base(
            new ExceptionArgs()
            {
                Type = DefaultType,
                Status = DefaultStatus,
                SystemMessage = systemMessage,
                ClientMessage = clientMessage
            }
        ) { }

    public UnauthorizedException(string systemMessage)
        : base(
            new ExceptionArgs()
            {
                Type = DefaultType,
                Status = DefaultStatus,
                SystemMessage = systemMessage
            }
        ) { }
}
