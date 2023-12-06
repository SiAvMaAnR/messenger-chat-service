using MessengerX.Domain.Exceptions.ApiExceptions;
using MessengerX.Domain.Exceptions.Common;
using MessengerX.Domain.Exceptions.StatusCode;
using MessengerX.WebApi.Common;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace MessengerX.WebApi.Controllers;

[ApiController]
[ApiExplorerSettings(IgnoreApi = true)]
public class ErrorController : ControllerBase
{
    private IActionResult HandleError(string envName)
    {
        IExceptionHandlerFeature? exceptionHandlerFeature = HttpContext
            .Features
            .Get<IExceptionHandlerFeature>()!;

        Exception exception = exceptionHandlerFeature.Error;

        string? clientMessage = (exception as BaseException)?.ClientMessage;

        object errorInfo = envName switch
        {
            AppEnvironment.Development
                => new
                {
                    clientMessage,
                    exception.Message,
                    exception.Source,
                    exception.StackTrace,
                    exception.InnerException,
                    exception.Data,
                    exception.HelpLink,
                    exception.HResult,
                },
            _ => new { clientMessage }
        };

        int statusCode = exception switch
        {
            BadRequestException => (int)ApiStatusCode.BadRequest,
            UnauthorizedException => (int)ApiStatusCode.Unauthorized,
            NotFoundException => (int)ApiStatusCode.NotFound,
            ForbiddenException => (int)ApiStatusCode.Forbidden,
            InternalServerException => (int)ApiStatusCode.InternalServer,
            _ => (int)ApiStatusCode.InternalServer
        };

        return StatusCode(statusCode, errorInfo);
    }

    [Route("Production")]
    public IActionResult HandleErrorProduction() => HandleError(AppEnvironment.Production);

    [Route("Development")]
    public IActionResult HandleErrorDevelopment() => HandleError(AppEnvironment.Development);
}
