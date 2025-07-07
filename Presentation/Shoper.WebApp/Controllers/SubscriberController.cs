using Microsoft.AspNetCore.Mvc;
using ShoperApplication.Dtos.SubscriberDtos;
using ShoperApplication.Usecasess.SubscriberServices;

namespace Shoper.WebApp.Controllers;

public class SubscriberController : Controller
{
   private readonly ISubscriberService _service;

   public SubscriberController(ISubscriberService service)
   {
      _service = service;
   }

   [HttpPost]
   public async Task<IActionResult> Create(CreateSubscriberDto subscriber)
   {
      subscriber.SubscriberDate= DateTime.UtcNow;
      await _service.CreateSubscriberAsync(subscriber);
      return RedirectToAction("Index", "Home");
   }
}