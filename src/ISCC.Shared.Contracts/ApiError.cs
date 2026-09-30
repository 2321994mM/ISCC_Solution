namespace ISCC.Shared.Contracts;

/// <summary>
/// The single error shape every API endpoint in this solution returns.
/// </summary>
/// <remarks>
/// Field names are camelCased on the wire by the JSON serializer configuration.
/// </remarks>
public class ApiError
{
    /// <summary>
    /// Machine-readable code from <see cref="ErrorCodes"/>. Clients branch on this,
    /// never on <see cref="Message"/>.
    /// </summary>
    public string Code { get; set; } = ErrorCodes.None;

    /// <summary>
    /// Human-readable description, safe to show a user. Localized at the edge when the
    /// request carries an <c>Accept-Language</c> the server supports.
    /// </summary>
    public string Message { get; set; } = string.Empty;

    /// <summary>
    /// Per-field validation messages, keyed by field name. Empty for non-validation errors.
    /// </summary>
    public IDictionary<string, string[]> Details { get; set; } = new Dictionary<string, string[]>();

    /// <summary>
    /// The <c>traceId</c> of the failed request. Matches the <c>traceId</c> in the logs,
    /// so a user can quote it and support can find the stack trace.
    /// </summary>
    public string? TraceId { get; set; }

    /// <summary>
    /// Creates an error with no field-level detail.
    /// </summary>
    public static ApiError Create(string code, string message) => new() { Code = code, Message = message };
}
