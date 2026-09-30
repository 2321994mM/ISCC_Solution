namespace ISCC.Shared.Contracts;

/// <summary>
/// Machine-readable error codes returned in <see cref="ApiResponse{T}.Error.Code"/>.
/// </summary>
/// <remarks>
/// These are part of the wire contract. Clients may branch on them, so treat a rename as
/// a breaking change. HTTP status codes are the coarse signal; these are the fine one.
/// </remarks>
public static class ErrorCodes
{
    /// <summary>No specific code; the message carries the detail.</summary>
    public const string None = "NONE";

    /// <summary>Request body or query failed model validation.</summary>
    public const string ValidationFailed = "VALIDATION_FAILED";

    /// <summary>A business rule in the domain layer rejected the operation.</summary>
    public const string DomainRuleViolation = "DOMAIN_RULE_VIOLATION";

    /// <summary>The caller is not authenticated.</summary>
    public const string Unauthenticated = "UNAUTHENTICATED";

    /// <summary>The caller is authenticated but lacks the required role.</summary>
    public const string Forbidden = "FORBIDDEN";

    /// <summary>The requested resource does not exist.</summary>
    public const string NotFound = "NOT_FOUND";

    /// <summary>
    /// The route exists but has not been migrated yet.
    /// </summary>
    /// <remarks>
    /// Distinct from <see cref="InternalError"/>: this is a known gap in the build, not a
    /// fault. A client can retry later; a 500 is worth an alert.
    /// </remarks>
    public const string NotImplemented = "NOT_IMPLEMENTED";

    /// <summary>An unhandled fault. The detail is logged, never returned to the caller.</summary>
    public const string InternalError = "INTERNAL_ERROR";

    /// <summary>The caller exceeded a rate or quota limit.</summary>
    public const string TooManyRequests = "TOO_MANY_REQUESTS";

    /// <summary>The action conflicts with the current state of the resource.</summary>
    public const string Conflict = "CONFLICT";

    /// <summary>
    /// The status code a client sees, expressed as one of the codes above.
    /// </summary>
    /// <remarks>
    /// <para>
    /// The inverse of the exception-to-status mapping. Needed for failures that never
    /// become exceptions at all: an unmatched route, a rejected CORS preflight, a 401
    /// from the authentication middleware. Those short-circuit before any handler runs,
    /// and without this a client gets a bare status code with an empty body while every
    /// other error comes back in the envelope.
    /// </para>
    /// <para>
    /// Lives here, in the contracts, rather than in the web layer, so a mobile client can
    /// map a status code to a code without a dependency on the server's exception
    /// handling.
    /// </para>
    /// </remarks>
    /// <param name="statusCode">An HTTP status code.</param>
    /// <returns>The matching <see cref="ErrorCodes"/> constant.</returns>
    public static string ForStatus(int statusCode) => statusCode switch
    {
        400 => ValidationFailed,
        401 => Unauthenticated,
        403 => Forbidden,
        404 => NotFound,
        409 => Conflict,
        422 => DomainRuleViolation,
        429 => TooManyRequests,
        501 => NotImplemented,
        504 => InternalError,
        _ => statusCode >= 500 ? InternalError : None
    };

    /// <summary>
    /// The default message for a status code, for callers that need something to show.
    /// </summary>
    /// <param name="statusCode">An HTTP status code.</param>
    /// <returns>A short, non-leaking message.</returns>
    public static string MessageForStatus(int statusCode) => statusCode switch
    {
        400 => "The request is not valid.",
        401 => "Authentication is required.",
        403 => "You do not have access to this resource.",
        404 => "The requested resource was not found.",
        405 => "That HTTP method is not supported for this resource.",
        409 => "The request conflicts with the current state.",
        415 => "The request media type is not supported.",
        422 => "The request was understood but cannot be processed.",
        429 => "Too many requests.",
        501 => "This endpoint has not been implemented yet.",
        504 => "The operation timed out.",
        _ => statusCode >= 500 ? "An unexpected error occurred." : "The request could not be completed."
    };
}
