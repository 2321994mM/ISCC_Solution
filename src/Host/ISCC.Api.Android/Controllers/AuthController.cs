using ISCC.Shared.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace ISCC.Api.Android.Controllers;

/// <summary>
/// Placeholder. The legacy Android API has not been migrated yet (Phase 6, blocked on
/// the old project folder). Deliberately returns 501 rather than pretending to work.
/// </summary>
[Route("api/[controller]")]
public class AuthController : ApiControllerBase
{
    /// <summary>Not migrated yet.</summary>
    [HttpPost("login")]
    public ActionResult<ApiResponse<object>> Login() => ApiNotImplemented();
}
