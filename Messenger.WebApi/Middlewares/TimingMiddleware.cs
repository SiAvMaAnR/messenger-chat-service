using System.Diagnostics;

namespace MessengerX.WebApi.Middlewares;

public class TimingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<TimingMiddleware> _logger;

    public TimingMiddleware(RequestDelegate next, ILogger<TimingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var stopwatch = Stopwatch.StartNew();

        await _next(context);

        stopwatch.Stop();
        var elapsed = stopwatch.Elapsed;
        var controllerName = context.Request.RouteValues["controller"] ?? "??";
        var actionName = context.Request.RouteValues["action"] ?? "??";
        _logger.LogInformation($"[TimingMiddleware] {controllerName}.{actionName} {elapsed} ms");
    }
}
