using MessengerX.Domain.Exceptions.Common;

namespace MessengerX.Domain.Exceptions.ApiExceptions;

public class ForbiddenException : BaseException
{
    public ForbiddenException(string systemMessage, string clientMessage)
        : base(
            new ExceptionArgs()
            {
                Type = "Forbidden",
                Status = 403,
                SystemMessage = systemMessage,
                ClientMessage = clientMessage
            }
        ) { }

    public ForbiddenException(string systemMessage)
        : base(
            new ExceptionArgs()
            {
                Type = "Forbidden",
                Status = 403,
                SystemMessage = systemMessage,
            }
        ) { }
}
