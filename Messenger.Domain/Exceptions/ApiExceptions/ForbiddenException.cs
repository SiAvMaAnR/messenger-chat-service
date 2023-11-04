using MessengerX.Domain.Exceptions.Common;

namespace MessengerX.Domain.Exceptions.ApiExceptions;

public class ForbiddenException : BaseException
{
    public const string DefaultType = "Forbidden";
    public const int DefaultStatus = 403;

    public ForbiddenException(string systemMessage, string clientMessage)
        : base(
            new ExceptionArgs()
            {
                Type = DefaultType,
                Status = DefaultStatus,
                SystemMessage = systemMessage,
                ClientMessage = clientMessage
            }
        ) { }

    public ForbiddenException(string systemMessage)
        : base(
            new ExceptionArgs()
            {
                Type = DefaultType,
                Status = DefaultStatus,
                SystemMessage = systemMessage,
            }
        ) { }
}
