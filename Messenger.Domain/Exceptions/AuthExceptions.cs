using Messenger.Domain.Exceptions.Common;

namespace Messenger.Domain.Exceptions;

public class FailedToCreatePasswordException : BusinessException
{
    public FailedToCreatePasswordException()
        : base(
            new ExceptionArgs()
            {
                ApiStatusCode = ApiStatusCode.InternalServer,
                BusinessStatusCode = BusinessStatusCode.AuthE001,
                SystemMessage = $"Failed to create password",
                ClientMessage = $"Failed to create password"
            }
        )
    { }
}

public class FailedToVerifyPasswordException : BusinessException
{
    public FailedToVerifyPasswordException()
        : base(
            new ExceptionArgs()
            {
                ApiStatusCode = ApiStatusCode.Forbidden,
                BusinessStatusCode = BusinessStatusCode.AuthE002,
                SystemMessage = $"Failed to verify password",
                ClientMessage = $"Failed to verify password"
            }
        )
    { }
}

public class InvalidConfirmationException : BusinessException
{
    public InvalidConfirmationException()
        : base(
            new ExceptionArgs()
            {
                ApiStatusCode = ApiStatusCode.Forbidden,
                BusinessStatusCode = BusinessStatusCode.AuthE003,
                SystemMessage = $"Invalid confirmation link",
                ClientMessage = $"Invalid confirmation link"
            }
        )
    { }
}

public class InvalidCredentialsException : BusinessException
{
    public InvalidCredentialsException(string reason)
        : base(
            new ExceptionArgs()
            {
                ApiStatusCode = ApiStatusCode.Unauthorized,
                BusinessStatusCode = BusinessStatusCode.AuthE004,
                SystemMessage = $"Invalid credentials: {reason}",
                ClientMessage = reason
            }
        )
    { }
}
