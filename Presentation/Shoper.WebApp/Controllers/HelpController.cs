using Microsoft.AspNetCore.Mvc;

namespace Shoper.WebApp.Controllers;

public class HelpController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}