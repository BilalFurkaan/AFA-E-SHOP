using Microsoft.AspNetCore.Mvc;
using ShoperApplication.Dtos.CartItemDtos;
using ShoperApplication.Usecasess.CartItemServices;
using ShoperApplication.Usecasess.CartServices;
using ShoperApplication.Usecasess.CustomerServices;
using ShoperApplication.Usecasess.ProductServices;

namespace Shoper.WebApp.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService _cartService;
        private readonly ICartItemService _cartItemService;
        private readonly ICustomerServices _customerServices;
        

        public CartController(ICartService cartService, ICartItemService cartItemService, ICustomerServices customerServices)
        {
            _cartService = cartService;
            _cartItemService = cartItemService;
            _customerServices = customerServices;
        }

        public async Task<IActionResult> Index()
        {
            var identityId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(identityId))
            {
                return RedirectToAction("Login", "Account");
            }
            
            var customer = await _customerServices.GetByIdentityIdAsync(identityId);
            if (customer == null)
            {
                return RedirectToAction("Index", "Home");
            }
            int customerId = customer.CustomerId;
            var allCarts = await _cartService.GetAllCartAsync();
            var cart = allCarts.FirstOrDefault(x => x.CustomerId == customerId);
            if (cart == null)
            {
                await _cartService.CreateCartAsync(new ShoperApplication.Dtos.CartDtos.CreateCartDto
                {
                    CustomerId = customerId,
                    CreatedDate = DateTime.UtcNow,
                    CartItems = new List<ShoperApplication.Dtos.CartItemDtos.CreateCartItemDto>()
                });
                allCarts = await _cartService.GetAllCartAsync();
                cart = allCarts.FirstOrDefault(x => x.CustomerId == customerId);
            }
            return View(cart);
        }

        [HttpPost]
        public async Task<JsonResult> AddToCartItem([FromBody] CreateCartItemDto model)
        {
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
            int customerId = customer.CustomerId;
            var allCarts = await _cartService.GetAllCartAsync();
            var cart = allCarts.FirstOrDefault(x => x.CustomerId == customerId);
            if (cart == null)
            {
                await _cartService.CreateCartAsync(new ShoperApplication.Dtos.CartDtos.CreateCartDto
                {
                    CustomerId = customerId,
                    CreatedDate = DateTime.UtcNow,
                    CartItems = new List<ShoperApplication.Dtos.CartItemDtos.CreateCartItemDto>()
                });
                allCarts = await _cartService.GetAllCartAsync();
                cart = allCarts.FirstOrDefault(x => x.CustomerId == customerId);
            }
            model.CartId = cart.CartId;
            
            try
            {
                if (model == null)
                {
                    return Json(new { success = false, error = "Invalid request data" });
                }

                var check = await _cartItemService.CheckCartItems(model.CartId, model.ProductId);
                
                if (check)
                {
                    try
                    {
                        await _cartItemService.UpdateQuantityAsync(model.CartId, model.ProductId, model.Quantity);
                    }
                    catch (Exception updateEx)
                    {
                        Console.WriteLine($"Error updating quantity: {updateEx.Message}");
                        return Json(new { success = false, error = "Failed to update product quantity in cart" });
                    }
                }
                else
                {
                    try
                    {
                        await _cartItemService.CreateCartItemAsync(model);
                    }
                    catch (Exception createEx)
                    {
                        Console.WriteLine($"Error creating cart item: {createEx.Message}");
                        return Json(new { success = false, error = "Failed to add product to cart" });
                    }
                }
                
                var updatedCart = await _cartService.GetByIdCartAsync(model.CartId);
                decimal newTotalAmount = updatedCart?.CartItems?.Sum(item => item.TotalPrice) ?? 0;
                
                await _cartService.UpdateTotalAmount(model.CartId, newTotalAmount);
                
                return Json(new { success = true, message = check ? "Product quantity updated in cart" : "Product added to cart successfully" });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in AddToCartItem: {ex.Message}");
                Console.WriteLine($"Stack trace: {ex.StackTrace}");
                return Json(new { success = false, error = "An error occurred while processing your request. Please try again." });
            }
        }

        [HttpGet]
        public async Task<JsonResult> deleteCartItem(int id)
        {
            try
            {
                if (id == 0)
                {
                    return Json(new{error="Product not found"});
                }
                
                var cartItem = await _cartItemService.GetByIdCartItemAsync(id);
                if (cartItem == null)
                {
                    return Json(new { error = "Product not found" });
                }
                
                var cartId = cartItem.CartId;
                
                await _cartItemService.DeleteCartItemAsync(id);
                
                var updatedCart = await _cartService.GetByIdCartAsync(cartId);
                decimal newTotalAmount = updatedCart?.CartItems?.Sum(item => item.TotalPrice) ?? 0;
                
                await _cartService.UpdateTotalAmount(cartId, newTotalAmount);
                
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new{error=ex});
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdateQuantityOnCart(UpdateCartItemDto dto)
        {
            try
            {
                await _cartItemService.UpdateQuantityOnCart(dto);
                var updatedCart = await _cartService.GetByIdCartAsync(dto.CartId);
                decimal newTotalAmount = updatedCart?.CartItems?.Sum(item => item.TotalPrice) ?? 0;
                await _cartService.UpdateTotalAmount(dto.CartId, newTotalAmount);
                
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new{error=ex});
            }
        }

    }
}
