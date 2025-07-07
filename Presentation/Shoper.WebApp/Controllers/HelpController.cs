using Microsoft.AspNetCore.Mvc;
using ShoperApplication.Dtos.HelpDtos;
using ShoperApplication.Usecasess.HelpServices;

namespace Shoper.WebApp.Controllers;

public class HelpController : Controller
{
    private readonly IHelpService _helpService;

    public HelpController(IHelpService helpService)
    {
        _helpService = helpService;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateHelpDto dto)
    {
        try
        {
            dto.Status = false; 
            await _helpService.CreateHelpAsync(dto);
            TempData["Success"] = "Your ticket has been sent successfully. We will get back to you as soon as possible.";
            return RedirectToAction("Index");
        }
        catch
        {
            TempData["Error"] = "An error occurred. Please try again.";
            return RedirectToAction("Index");
        }
    }
}