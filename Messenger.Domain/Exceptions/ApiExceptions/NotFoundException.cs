using MessengerX.Domain.Exceptions.Common;

namespace MessengerX.Domain.Exceptions.ApiExceptions;

public class NotFoundException : BaseException
{
    public const string DefaultType = "Not Found";
    public const int DefaultStatus = 404;

    public NotFoundException(string systemMessage, string clientMessage)
        : base(
            new ExceptionArgs()
            {
                Type = DefaultType,
                Status = DefaultStatus,
                SystemMessage = systemMessage,
                ClientMessage = clientMessage
            }
        ) { }

    public NotFoundException(string systemMessage)
        : base(
            new ExceptionArgs()
            {
                Type = DefaultType,
                Status = DefaultStatus,
                SystemMessage = systemMessage,
            }
        ) { }
}
