using MessengerX.Domain.Exceptions.Common;

namespace MessengerX.Domain.Exceptions.ApiExceptions;

public class BadRequestException : BaseException
{
    public const string DefaultType = "Bad Request";
    public const int DefaultStatus = 400;

    public BadRequestException(string systemMessage, string clientMessage)
        : base(
            new ExceptionArgs()
            {
                Type = DefaultType,
                Status = DefaultStatus,
                SystemMessage = systemMessage,
                ClientMessage = clientMessage
            }
        ) { }

    public BadRequestException(string systemMessage)
        : base(
            new ExceptionArgs()
            {
                Type = DefaultType,
                Status = DefaultStatus,
                SystemMessage = systemMessage,
            }
        ) { }
}
