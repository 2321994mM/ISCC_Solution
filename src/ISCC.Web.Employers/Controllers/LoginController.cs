using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ISCC.Web.Employers.Controllers;

public class LoginController : BaseController
{
    private readonly ILogger<LoginController> _logger;

    public LoginController(ILogger<LoginController> logger, Microsoft.Extensions.Localization.IStringLocalizer<BaseController> localizer)
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
                _logger.LogInformation("userName && password غير صحيح", DateTime.Now.ToLongTimeString());

                LogErrorToDb(
                    pageName: "LoginController",
                    functionName: "GoDataEntryMenu",
                    errorMessage: "بيانات الدخول خاطئة");

                return RedirectToAction("Index");
            }
        }
        catch (Exception ex)
        {
            _logger.LogInformation(ex.Message, "About page visited at {DT}", DateTime.Now.ToLongTimeString());

            LogErrorToDb(
                pageName: "LoginController",
                functionName: "GoDataEntryMenu",
                errorMessage: ex.Message);

            return RedirectToAction("Index");
        }
    }
}