using ISCC.Shared.Localization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;

namespace ISCC.Web.Employers.Controllers;

public class LoginController : BaseController
{
    private readonly ILogger<LoginController> _logger;

    public LoginController(
        ILogger<LoginController> logger,
        IStringLocalizer<SharedResource> localizer)
        : base(localizer)
    {
        _logger = logger;
    }

    [AllowAnonymous]
    [Route("/Login/Index")]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult GoDataEntryMenu(string userName, string password)
    {
        try
        {
            if (userName == "admin" && password == "admin@123")
            {
                HttpContext.Session.Clear();
                HttpContext.Session.SetString("UserSession", "Authenticated");
                HttpContext.Session.SetString("UserRole", "Administrator");
                HttpContext.Session.SetString("LoginUserName", "admin");
                return View();
            }
            else if (userName == "Fess" && password == "Fess@123888")
            {
                HttpContext.Session.Clear();
                HttpContext.Session.SetString("UserSession", "Fess");
                HttpContext.Session.SetString("UserRole", "PaymentOnly");
                return RedirectToAction("Index", "CheckGeneralPayment");
            }
            else
            {
                _logger.LogWarning("Invalid credentials for {UserName} at {Time}", userName, DateTime.Now.ToLongTimeString());

                LogErrorToDb(
                    pageName: nameof(LoginController),
                    functionName: nameof(GoDataEntryMenu),
                    errorMessage: "Invalid username or password");

                return RedirectToAction(nameof(Index));
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Login failed for {UserName} at {Time}", userName, DateTime.Now.ToLongTimeString());

            LogErrorToDb(
                pageName: nameof(LoginController),
                functionName: nameof(GoDataEntryMenu),
                errorMessage: ex.Message);

            return RedirectToAction(nameof(Index));
        }
    }
}
