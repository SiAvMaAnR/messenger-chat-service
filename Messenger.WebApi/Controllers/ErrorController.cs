using MessengerX.Domain.Exceptions.ApiExceptions;
using MessengerX.Domain.Exceptions.Common;
using MessengerX.Domain.Exceptions.StatusCode;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace MessengerX.WebApi.Controllers;

[ApiController]
[ApiExplorerSettings(IgnoreApi = true)]
public class ErrorController : ControllerBase
{
    private IActionResult HandleError(bool isDevelopment)
    {
        IExceptionHandlerFeature? exceptionHandlerFeature =
            HttpContext.Features.Get<IExceptionHandlerFeature>()!;

        var exception = exceptionHandlerFeature.Error;

        var clientMessage = (exception as BaseException)?.ClientMessage;

        object errorInfo = isDevelopment
            ? new
            {
                clientMessage,
                exception.Message,
                exception.Source,
                exception.StackTrace,
                exception.InnerException,
                exception.Data,
                exception.HelpLink,
                exception.HResult,
            }
            : new { clientMessage };

        var statusCode = exception switch
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
    public IActionResult HandleErrorProduction() => HandleError(false);

    [Route("Development")]
    public IActionResult HandleErrorDevelopment() => HandleError(true);
}
