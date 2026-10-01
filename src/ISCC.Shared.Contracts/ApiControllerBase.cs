using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ISCC.Shared.Contracts;

/// <summary>
/// Base class for API controllers. Returns <see cref="ApiResponse{T}"/> for every outcome,
/// so no endpoint can accidentally return a bare value or an HTML error page.
/// </summary>
/// <remarks>
/// <para>
/// For a <b>UI portal</b> controller, prefer <c>ISCC.Shared.Web</c>'s <c>BaseController</c>,
/// which renders views. This type is for endpoints that return JSON.
/// </para>
/// <para>
/// The HTTP status is still meaningful and is set correctly here: 200/201/204 on success,
/// 400/401/403/404/409/422/500 on failure. The envelope rides alongside, never instead.
/// </para>
/// </remarks>
[ApiController]
[Produces("application/json")]
public abstract class ApiControllerBase : ControllerBase
{
    /// <summary>200 with an envelope.</summary>
    protected ActionResult<ApiResponse<T>> ApiOk<T>(T data) =>
        Ok(ApiResponse<T>.Ok(data));

    /// <summary>201 with an envelope and a Location header.</summary>
    protected ActionResult<ApiResponse<T>> ApiCreated<T>(string routeName, object routeValues, T data)
    {
        var envelope = ApiResponse<T>.Ok(data);
        envelope.TraceId = HttpContext.TraceIdentifier;
        return CreatedAtRoute(routeName, routeValues, envelope);
    }

    /// <summary>204 with a success envelope. The body is dropped by the HTTP spec.</summary>
    protected ActionResult<ApiResponse<object>> ApiNoContent() =>
        NoContent();

    /// <summary>400 with a validation error and per-field detail.</summary>
    protected ActionResult<ApiResponse<object>> ApiValidationError(
        IDictionary<string, string[]> details,
        string? message = null) =>
        BadRequest(Fail<object>(ErrorCodes.ValidationFailed, message ?? "One or more validation errors occurred.", details));

    /// <summary>400 with a domain rule violation.</summary>
    protected ActionResult<ApiResponse<object>> ApiBadRequest(string message) =>
        BadRequest(Fail<object>(ErrorCodes.DomainRuleViolation, message));

    /// <summary>401 unauthenticated.</summary>
    protected ActionResult<ApiResponse<object>> ApiUnauthenticated(string message = "Authentication is required.") =>
        Unauthorized(Fail<object>(ErrorCodes.Unauthenticated, message));

    /// <summary>403 forbidden.</summary>
    protected ActionResult<ApiResponse<object>> ApiForbidden(string message = "You do not have permission to perform this action.") =>
        StatusCode(StatusCodes.Status403Forbidden, Fail<object>(ErrorCodes.Forbidden, message));

    /// <summary>404 not found.</summary>
    protected ActionResult<ApiResponse<object>> ApiNotFound(string message = "The requested resource was not found.") =>
        NotFound(Fail<object>(ErrorCodes.NotFound, message));

    /// <summary>409 conflict.</summary>
    protected ActionResult<ApiResponse<object>> ApiConflict(string message) =>
        Conflict(Fail<object>(ErrorCodes.Conflict, message));

    /// <summary>422 semantically invalid, but well-formed.</summary>
    protected ActionResult<ApiResponse<object>> ApiUnprocessable(string message) =>
        UnprocessableEntity(Fail<object>(ErrorCodes.DomainRuleViolation, message));

    /// <summary>
    /// 501, for an endpoint that exists as a route but has not been migrated yet.
    /// </summary>
    /// <remarks>
    /// The migration stubs return 501 rather than a plausible-looking empty result, so a
    /// client can tell "not built yet" from "built, and there is nothing to show". Doing
    /// that in the envelope rather than as a bare object keeps the wire shape identical to
    /// every other response: a client that parses the envelope can parse this too.
    /// </remarks>
    /// <param name="message">Defaults to a message naming the migration phase.</param>
    protected ActionResult<ApiResponse<object>> ApiNotImplemented(
        string message = "Not yet migrated. See docs/MIGRATION-PLAN.md Phase 6.") =>
        StatusCode(StatusCodes.Status501NotImplemented, Fail<object>(ErrorCodes.NotImplemented, message));

    /// <summary>
    /// 404 with an envelope whose <c>data</c> is typed to match the success path.
    /// </summary>
    /// <remarks>
    /// Needed by any endpoint that returns data on success, because the untyped overload
    /// produces an <c>ApiResponse&lt;object&gt;</c> and the compiler will not unify the two
    /// branches into one return type. The failure carries no data, so nothing changes on
    /// the wire — it only lets a method declare a single return type.
    /// </remarks>
    /// <typeparam name="T">The type the success path returns.</typeparam>
    /// <param name="message">The failure message.</param>
    protected ActionResult<ApiResponse<T>> ApiNotFound<T>(string message) =>
        NotFound(Fail<T>(ErrorCodes.NotFound, message));

    /// <summary>
    /// Builds a failure envelope stamped with the current trace id.
    /// </summary>
    private ApiResponse<T> Fail<T>(string code, string message, IDictionary<string, string[]>? details = null)
    {
        var error = details is null
            ? ApiError.Create(code, message)
            : new ApiError { Code = code, Message = message, Details = details };

        error.TraceId = HttpContext.TraceIdentifier;

        return new ApiResponse<T> { Success = false, Error = error, TraceId = HttpContext.TraceIdentifier };
    }
}
