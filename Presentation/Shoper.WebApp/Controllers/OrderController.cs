using Microsoft.AspNetCore.Mvc;
using ShoperApplication.Dtos.OrderDtos;
using ShoperApplication.Dtos.OrderItemDtos;
using ShoperApplication.Usecasess.CartServices;
using ShoperApplication.Usecasess.OrderServices;

namespace Shoper.WebApp.Controllers;

public class OrderController : Controller
{
    private readonly IOrderServices _orderServices;
    private readonly ICartService _cartService;

    public OrderController(IOrderServices orderServices, ICartService cartService)
    {
        _orderServices = orderServices;
        _cartService = cartService;
    }

    public IActionResult Index()
    {
        return View();
    }
    public async Task<IActionResult> Checkout(int cartId)
    {
        var value=await _cartService.GetByIdCartAsync(cartId);
        if (value == null)
        {
            return View();
        }
        return View(value);
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrder(CreateOrderDto dto,int cartId)
    {
        try
        { 
            var cart = await _cartService.GetByIdCartAsync(cartId);
            var result = cart.CartItems.Select
                (item => new CreateOrderItemDto { ProductId = item.ProductId, Quantity = item.Quantity, TotalPrice = item.TotalPrice, }).ToList();
            dto.CustomerId = 1;
            dto.OrderItems = result;
            dto.OrderStatus="Pending";
            await _orderServices.CreateOrderAsync(dto);
            return Json(new { success = true });
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return RedirectToAction("Error", "Home",ex.Message);
        }

    }
    public async Task< IActionResult> GetCity()
    {
        var cites = await _orderServices.GetAllCitiesAsync();
        return Json(new { success = true, data= cites });
    }

    public async Task<IActionResult> GetTown(int cityId)
    {
        var towns= await _orderServices.GetTownsAsync(cityId);
        return Json(new { success = true, data = towns });
    }
}