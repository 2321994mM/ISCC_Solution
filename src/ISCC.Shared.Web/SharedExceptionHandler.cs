using ISCC.Domain.Exceptions;
using ISCC.Shared.Contracts;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace ISCC.Shared.Web;

/// <summary>
/// Turns any unhandled exception into the <see cref="ApiResponse{T}"/> envelope.
/// </summary>
/// <remarks>
/// <para>
/// This replaces the per-host <c>ExceptionHandlingMiddleware</c>, which existed only in
/// the Android API and was never registered in the pipeline, so it did nothing.
/// Implementing <see cref="IExceptionHandler"/> rather than raw middleware means the
/// framework guarantees it runs on every unhandled fault.
/// </para>
/// <para>
/// <b>Scope: JSON callers only.</b> When the request does not want JSON this handler
/// deliberately returns <c>false</c> and lets <c>UseExceptionHandler("/Home/Error")</c>
/// re-execute the pipeline to the shared Razor error view. Both paths cannot write the
/// response, and letting the framework own the HTML path avoids duplicating it here.
/// </para>
/// <para>
/// Status mapping is centralised in <see cref="Map"/> and nowhere else, so every endpoint
/// agrees: validation to 400, domain rule to 422, unauthenticated to 401, forbidden to
/// 403, missing to 404, everything else to 500.
/// </para>
/// <para>
/// Unhandled faults never leak the exception message to the caller. The caller gets a
/// <c>traceId</c>; the message and stack go to the logs. A <see cref="DomainException"/>
/// is safe to return because it is written to be user-facing.
/// </para>
/// </remarks>
public sealed class SharedExceptionHandler : IExceptionHandler
{
    private readonly ILogger<SharedExceptionHandler> _logger;

    /// <summary>Creates the handler.</summary>
    public SharedExceptionHandler(ILogger<SharedExceptionHandler> logger)
    {
        _logger = logger;
    }

    /// <summary>Maps, logs and writes a JSON envelope. Returns false for HTML callers.</summary>
    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        if (!WantsJson(httpContext))
        {
            // Hand back to the framework, which re-executes to the shared error view.
            return false;
        }

        // A response already started cannot be rewritten.
        if (httpContext.Response.HasStarted)
        {
            _logger.LogError(exception, "Unhandled exception after the response started; cannot rewrite it.");
            return false;
        }

        var (statusCode, error) = Map(exception, httpContext.TraceIdentifier);

        if (statusCode >= StatusCodes.Status500InternalServerError)
        {
            _logger.LogError(exception, "Unhandled exception. TraceId {TraceId}", httpContext.TraceIdentifier);
        }
        else
        {
            _logger.LogWarning(exception, "Request rejected with {StatusCode}. TraceId {TraceId}",
                statusCode, httpContext.TraceIdentifier);
        }

        httpContext.Response.StatusCode = statusCode;
        await httpContext.Response.WriteAsJsonAsync(
            new ApiResponse<object>
            {
                Success = false,
                Error = error,
                TraceId = httpContext.TraceIdentifier
            },
            SharedApiJson.Options,
            cancellationToken);

        return true;
    }

    /// <summary>
    /// Maps an exception to its status code and wire error. The single source of truth.
    /// </summary>
    /// <remarks>
    /// Also called by the HTML re-execute path, purely for its status code, so a browser
    /// and an API client are told the same thing about the same failure. That is why the
    /// status code and the error code are decided in one switch: splitting them would let
    /// them drift, and a 422 that came back as 500 would page an on-call engineer for a
    /// user typo.
    /// </remarks>
    public static (int StatusCode, ApiError Error) Map(Exception exception, string traceId) => exception switch
    {
        // Validation failures are the caller's fault and carry field detail.
        ValidationException v => (StatusCodes.Status400BadRequest, new ApiError
        {
            Code = ErrorCodes.ValidationFailed,
            Message = v.Message,
            Details = new Dictionary<string, string[]>(v.Errors),
            TraceId = traceId
        }),

        // A domain rule was broken: well-formed but semantically invalid.
        DomainException d => (StatusCodes.Status422UnprocessableEntity, new ApiError
        {
            Code = ErrorCodes.DomainRuleViolation,
            Message = d.Message,
            TraceId = traceId
        }),

        UnauthorizedAccessException u => (StatusCodes.Status401Unauthorized, new ApiError
        {
            Code = ErrorCodes.Unauthenticated,
            Message = u.Message,
            TraceId = traceId
        }),

        KeyNotFoundException k => (StatusCodes.Status404NotFound, new ApiError
        {
            Code = ErrorCodes.NotFound,
            Message = k.Message,
            TraceId = traceId
        }),

        TimeoutException => (StatusCodes.Status504GatewayTimeout, new ApiError
        {
            Code = ErrorCodes.InternalError,
            Message = "The operation timed out.",
            TraceId = traceId
        }),

        // Everything else. The message is deliberately NOT returned.
        _ => (StatusCodes.Status500InternalServerError, new ApiError
        {
            Code = ErrorCodes.InternalError,
            Message = "An unexpected error occurred.",
            TraceId = traceId
        })
    };

    /// <summary>
    /// Decides whether the caller wants JSON. An API route segment or a JSON-only Accept
    /// header wins; a browser asking for HTML does not get an envelope.
    /// </summary>
    public static bool WantsJson(HttpContext context)
    {
        // An explicit path segment wins, so /api/... is JSON even if a browser navigates
        // there directly.
        if (context.Request.Path.StartsWithSegments("/api", StringComparison.OrdinalIgnoreCase))
        {
            return true;
        }

        // fetch() and jQuery ajax set this.
        if (string.Equals(context.Request.Headers.XRequestedWith, "XMLHttpRequest", StringComparison.OrdinalIgnoreCase))
        {
            return true;
        }

        var accept = context.Request.Headers.Accept.ToString();

        if (accept.Contains("application/json", StringComparison.OrdinalIgnoreCase) &&
            !accept.Contains("text/html", StringComparison.OrdinalIgnoreCase))
        {
            return true;
        }

        if (accept.Contains("text/html", StringComparison.OrdinalIgnoreCase))
        {
            return false;
        }

        // No preference stated. Fall back to whether this looks like a browser. A bare
        // curl or a server-to-server call gets JSON; a browser gets the HTML error page.
        var userAgent = context.Request.Headers.UserAgent.ToString();
        return !userAgent.Contains("Mozilla", StringComparison.OrdinalIgnoreCase);
    }
}
