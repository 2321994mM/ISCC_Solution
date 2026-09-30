using ISCC.Shared.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace ISCC.Api.Android.Controllers;

/// <summary>Placeholder. See <see cref="AuthController"/>. Migration is Phase 6.</summary>
[Route("api/[controller]")]
public class InspectionController : ApiControllerBase
{
    /// <summary>Not migrated yet.</summary>
    [HttpGet]
    public ActionResult<ApiResponse<object>> GetAll() => ApiNotImplemented();
}
