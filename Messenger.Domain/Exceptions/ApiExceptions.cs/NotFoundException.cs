using CSN.Domain.Exceptions.Common;

namespace CSN.Domain.Exceptions.ApiExceptions;

public class NotFoundException : BaseException
{
    public NotFoundException(string systemMessage, string clientMessage)
        : base(
            new ExceptionArgs()
            {
                Type = "Not Found",
                Status = 404,
                SystemMessage = systemMessage,
                ClientMessage = clientMessage
            }
        ) { }

    public NotFoundException(string systemMessage)
        : base(
            new ExceptionArgs()
            {
                Type = "Not Found",
                Status = 404,
                SystemMessage = systemMessage,
            }
        ) { }
}
