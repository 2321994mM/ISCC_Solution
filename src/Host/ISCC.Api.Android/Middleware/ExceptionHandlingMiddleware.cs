using ISCC.Domain.Exceptions;
using System.Net;
using System.Text.Json;

namespace ISCC.Api.Android.Middleware;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (ValidationException ex)
        {
            _logger.LogWarning(ex, "Validation error");
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            context.Response.ContentType = "application/json";
            var result = JsonSerializer.Serialize(new { Message = ex.Message, Errors = ex.Errors });
            await context.Response.WriteAsync(result);
        }
        catch (DomainException ex)
        {
            _logger.LogWarning(ex, "Domain error");
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            context.Response.ContentType = "application/json";
            var result = JsonSerializer.Serialize(new { Message = ex.Message });
            await context.Response.WriteAsync(result);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unhandled exception");
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";
            var result = JsonSerializer.Serialize(new { Message = "An unexpected error occurred" });
            await context.Response.WriteAsync(result);
        }
    }
}
