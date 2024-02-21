namespace Gamestore.API.Middleware;

public class RequestLoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger _logger;

    public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext httpContext)
    {
        var startTime = DateTime.UtcNow;

        await _next.Invoke(httpContext);

        var duration = DateTime.UtcNow - startTime;

        var clientIpAddress = httpContext.Connection.RemoteIpAddress.ToString();

        _logger.LogInformation(
        "Request from IP: {ip} {method} {url} took {duration}ms",
        clientIpAddress,
        httpContext.Request.Method,
        httpContext.Request.Path,
        duration.TotalMilliseconds);
    }
}