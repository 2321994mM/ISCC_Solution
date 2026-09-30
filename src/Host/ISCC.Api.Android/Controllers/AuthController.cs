using Microsoft.AspNetCore.Mvc;

namespace ISCC.Api.Android.Controllers;

/// <summary>
/// Placeholder. The legacy Android API has not been migrated yet (Phase 6, blocked on
/// the old project folder). Deliberately returns 501 rather than pretending to work.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    [HttpPost("login")]
    public IActionResult Login() => StatusCode(StatusCodes.Status501NotImplemented,
        new { Message = "Not yet migrated. See docs/MIGRATION-PLAN.md Phase 6." });
}