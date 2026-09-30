namespace ISCC.Shared.Contracts;

/// <summary>
/// The single response envelope every API endpoint in this solution returns.
/// </summary>
/// <remarks>
/// <para>
/// The rule this type exists to enforce: an endpoint returns <b>200-with-envelope</b> for
/// success and a <b>4xx/5xx-with-envelope</b> for failure, and never a bare value, never
/// <c>null</c>, and never an HTML error page.
/// </para>
/// <para>
/// <c>data</c> is omitted from the JSON entirely when null, so success responses do not
/// carry <c>"data": null</c> noise. Use <see cref="ApiResponse.NoContent"/> for endpoints
/// that genuinely return nothing.
/// </para>
/// </remarks>
/// <typeparam name="T">The payload type.</typeparam>
public class ApiResponse<T>
{
    /// <summary>Whether the operation succeeded. Drives client branching.</summary>
    public bool Success { get; set; }

    /// <summary>The payload. Omitted from JSON when null.</summary>
    [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull)]
    public T? Data { get; set; }

    /// <summary>The failure detail. Omitted from JSON when null.</summary>
    [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull)]
    public ApiError? Error { get; set; }

    /// <summary>Correlation id for this request, matching the server logs.</summary>
    public string? TraceId { get; set; }

    /// <summary>Builds a success envelope.</summary>
    public static ApiResponse<T> Ok(T data) => new() { Success = true, Data = data };

    /// <summary>Builds a success envelope with no payload.</summary>
    public static ApiResponse<T> NoContent() => new() { Success = true };

    /// <summary>Builds a failure envelope.</summary>
    public static ApiResponse<T> Fail(string code, string message) =>
        new() { Success = false, Error = ApiError.Create(code, message) };

    /// <summary>Builds a failure envelope with per-field validation detail.</summary>
    public static ApiResponse<T> Fail(string code, string message, IDictionary<string, string[]> details) =>
        new() { Success = false, Error = new ApiError { Code = code, Message = message, Details = details } };
}
