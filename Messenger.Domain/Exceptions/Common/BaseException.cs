namespace CSN.Domain.Exceptions.Common;

public abstract class BaseException : Exception, IException
{
    public const string DefaultClientMessage = "Unknown error";
    public int Status { get; }
    public string ClientMessage { get; }
    public string Type { get; }

    public BaseException(ExceptionArgs exceptionArgs)
        : base(exceptionArgs.SystemMessage)
    {
        this.Type = exceptionArgs.Type;
        this.Status = exceptionArgs.Status;
        this.ClientMessage = exceptionArgs.ClientMessage ?? DefaultClientMessage;
    }
}
