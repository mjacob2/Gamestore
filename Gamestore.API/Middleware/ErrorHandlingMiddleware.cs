using System.Net;
using Gamestore.DataAccess.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Gamestore.API.Middleware;

public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger _logger;

    public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception exception)
        {
            _logger.LogError(exception.Message);
            await HandleExceptionAsync(context, exception);
        }
    }

    private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var statusCode = GetHttpStatusCode(exception);

        var detailMessage = exception.InnerException != null ? exception.InnerException.Message : exception.Message;
        var problemDetails = new ProblemDetails
        {
            Type = exception.GetType().Name,
            Title = statusCode.ToString(),
            Status = (int)statusCode,
            Detail = detailMessage,
            Instance = $"urn:{context.TraceIdentifier}",
        };

        var result = JsonConvert.SerializeObject(problemDetails);

        context.Response.ContentType = "application/problem+json";
        context.Response.StatusCode = (int)statusCode;

        await context.Response.WriteAsync(result);
    }

    private static HttpStatusCode GetHttpStatusCode(Exception ex)
    {
        return ex switch
        {
            NotFoundException => HttpStatusCode.NotFound,
            ConflictException => HttpStatusCode.Conflict,
            UniquePropertyException => HttpStatusCode.BadRequest,
            OrderAlreadyPaidException => HttpStatusCode.BadRequest,
            NoUnitsInStockException => HttpStatusCode.BadRequest,
            PaymentRejectedException => HttpStatusCode.PaymentRequired,
            UnauthorizedException => HttpStatusCode.Unauthorized,
            BadRequestException => HttpStatusCode.BadRequest,
            _ => HttpStatusCode.InternalServerError,
        };
    }
}
