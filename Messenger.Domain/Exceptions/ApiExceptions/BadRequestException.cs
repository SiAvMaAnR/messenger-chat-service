using MessengerX.Domain.Exceptions.Common;

namespace MessengerX.Domain.Exceptions.ApiExceptions;

public class BadRequestException : BaseException
{
    public BadRequestException(string systemMessage, string clientMessage)
        : base(
            new ExceptionArgs()
            {
                Type = "Bad Request",
                Status = 400,
                SystemMessage = systemMessage,
                ClientMessage = clientMessage
            }
        ) { }

    public BadRequestException(string systemMessage)
        : base(
            new ExceptionArgs()
            {
                Type = "Bad Request",
                Status = 400,
                SystemMessage = systemMessage,
            }
        ) { }
}
