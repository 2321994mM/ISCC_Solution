using Microsoft.AspNetCore.Mvc;

namespace ISCC.Api.Android.Controllers;

/// <summary>Placeholder. See <see cref="AuthController"/>. Migration is Phase 6.</summary>
[ApiController]
[Route("api/[controller]")]
public class PaymentController : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll() => StatusCode(StatusCodes.Status501NotImplemented,
        new { Message = "Not yet migrated. See docs/MIGRATION-PLAN.md Phase 6." });
}