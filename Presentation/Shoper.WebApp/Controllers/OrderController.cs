using Microsoft.AspNetCore.Mvc;
using ShoperApplication.Dtos.OrderDtos;
using ShoperApplication.Dtos.OrderItemDtos;
using ShoperApplication.Usecasess.CartServices;
using ShoperApplication.Usecasess.OrderServices;
using ShoperApplication.Usecasess.CustomerServices;

namespace Shoper.WebApp.Controllers;

public class OrderController : Controller
{
    private readonly IOrderServices _orderServices;
    private readonly ICartService _cartService;
    private readonly ICustomerServices _customerServices;

    public OrderController(IOrderServices orderServices, ICartService cartService, ICustomerServices customerServices)
    {
        _orderServices = orderServices;
        _cartService = cartService;
        _customerServices = customerServices;
    }

    public IActionResult Index()
    {
        return View();
    }
    public async Task<IActionResult> Checkout(int cartId)
    {
        var cart = await _cartService.GetByIdCartAsync(cartId);
        if (cart == null)
        {
            return View();
        }

        var identityId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
        if (string.IsNullOrEmpty(identityId))
        {
            return RedirectToAction("Login", "Account");
        }
        
        var customer = await _customerServices.GetByIdentityIdAsync(identityId);

        var model = new CheckoutViewModel
        {
            CartId = cartId,
            FirstName = customer?.FirstName ?? "",
            LastName = customer?.LastName ?? "",
            PhoneNumber = customer?.PhoneNumber ?? "",
            Email = customer?.Email ?? "",
            Cart = cart
        };

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrder(CreateOrderDto dto, int cartId)
    {
        try
        { 
            var cart = await _cartService.GetByIdCartAsync(cartId);
            var result = cart.CartItems.Select
                (item => new CreateOrderItemDto { ProductId = item.ProductId, Quantity = item.Quantity, TotalPrice = item.TotalPrice, }).ToList();
            var identityId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(identityId))
            {
                return Json(new { success = false, error = "User not authenticated" });
            }
            
            var customer = await _customerServices.GetByIdentityIdAsync(identityId);
            if (customer == null)
            {
                return Json(new { success = false, error = "Customer not found" });
            }
            dto.CustomerId = customer.CustomerId;
            dto.OrderItems = result;
            dto.OrderStatus = "Pending";
            await _orderServices.CreateOrderAsync(dto);
            
            // Cart'ı temizle
            await _cartService.DeleteCartAsync(cartId);
            
            return Json(new { success = true });
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return Json(new { success = false, error = ex.Message });
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