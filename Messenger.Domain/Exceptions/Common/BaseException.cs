using MessengerX.Domain.Exceptions.StatusCode;

namespace MessengerX.Domain.Exceptions.Common;

public abstract class BaseException : Exception, IException
{
    public const string DefaultClientMessage = "Something went wrong";
    public ApiStatusCode Status { get; }
    public string ClientMessage { get; }
    public string Type { get; }

    public BaseException(ExceptionArgs exceptionArgs)
        : base(exceptionArgs.SystemMessage)
    {
        Type = exceptionArgs.Type;
        Status = exceptionArgs.Status;
        ClientMessage = exceptionArgs.ClientMessageSettings switch
        {
            ClientMessageSettings.Custom => exceptionArgs.ClientMessage!,
            ClientMessageSettings.Default => DefaultClientMessage,
            ClientMessageSettings.Same => exceptionArgs.SystemMessage,
            _ => ""
        };
    }
}
