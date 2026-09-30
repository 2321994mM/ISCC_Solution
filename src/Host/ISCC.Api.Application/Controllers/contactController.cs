using ISCC.Shared.Localization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace ISCC.Api.Application.Controllers;

public class contactController : BaseController
{
    public contactController(IStringLocalizer<SharedResource> localizer) : base(localizer) { }

    [AllowAnonymous]
    [Route("/contact/Index")]
    public IActionResult Index() => View();
}