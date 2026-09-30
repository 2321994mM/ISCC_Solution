using Microsoft.AspNetCore.Mvc;

namespace ISCC.Web.Client.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Error()
    {
        return View();
    }
}
