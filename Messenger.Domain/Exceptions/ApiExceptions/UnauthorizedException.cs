using MessengerX.Domain.Exceptions.Common;

namespace MessengerX.Domain.Exceptions.ApiExceptions;

public class UnauthorizedException : BaseException
{
    public UnauthorizedException(string systemMessage, string clientMessage)
        : base(
            new ExceptionArgs()
            {
                Type = "Unauthorized",
                Status = 401,
                SystemMessage = systemMessage,
                ClientMessage = clientMessage
            }
        ) { }

    public UnauthorizedException(string systemMessage)
        : base(
            new ExceptionArgs()
            {
                Type = "Unauthorized",
                Status = 401,
                SystemMessage = systemMessage
            }
        ) { }
}
