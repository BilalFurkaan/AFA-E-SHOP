using Microsoft.AspNetCore.Mvc;

namespace Shoper.WebApp.Controllers;

public class SubscriberController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}