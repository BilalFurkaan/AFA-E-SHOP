using Microsoft.AspNetCore.Mvc;

namespace Shoper.WebApp.Controllers;

public class AddressContollers : Controller
{
    public IActionResult Index()
    {
        return View();
    }
    public ActionResult GetCities()
    {
        return Json(new { success = true });


    }
}