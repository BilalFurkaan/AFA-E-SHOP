using Microsoft.AspNetCore.Mvc;
using ShoperApplication.Dtos.CartItemDtos;
using ShoperApplication.Usecasess.CartItemServices;
using ShoperApplication.Usecasess.CartServices;
using ShoperApplication.Usecasess.ProductServices;

namespace Shoper.WebApp.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService _cartService;
        private readonly ICartItemService _cartItemService;

        public CartController(ICartService cartService, ICartItemService cartItemService)
        {
            _cartService = cartService;
            _cartItemService = cartItemService;
        }

        public async Task<ActionResult> Index(int id = 1)
        {
            var value = await _cartService.GetByIdCartAsync(id);
            return View(value);
        }

        [HttpPost]
        public async Task<JsonResult> AddToCartItem([FromBody] CreateCartItemDto model)
        {
            try
            {
                model.CartId = 1;
                var cart = await _cartService.GetByIdCartAsync(model.CartId);
                var check = await _cartItemService.CheckCartItems(model.CartId, model.ProductId);
                
                if (check)
                {
                    await _cartItemService.UpdateQuantityAsync(model.CartId, model.ProductId, model.Quantity);
                }
                else
                {
                    await _cartItemService.CreateCartItemAsync(model);
                }
                
                // Güncellenmiş sepeti al ve toplamını hesapla
                var updatedCart = await _cartService.GetByIdCartAsync(model.CartId);
                decimal newTotalAmount = updatedCart.CartItems.Sum(item => item.TotalPrice);
                
                // Sepet toplamını güncelle
                await _cartService.UpdateTotalAmount(model.CartId, newTotalAmount);
                
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new{error=ex});
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
                
                // Sepet öğesini sil
                await _cartItemService.DeleteCartItemAsync(id);
                
                // Güncellenmiş sepeti al ve toplamını hesapla
                var updatedCart = await _cartService.GetByIdCartAsync(cartId);
                decimal newTotalAmount = updatedCart.CartItems.Sum(item => item.TotalPrice);
                
                // Sepet toplamını güncelle
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
                // CartItemId kullanarak sadece o sepet öğesini güncelle
                await _cartItemService.UpdateQuantityOnCart(dto);
                
                // Güncellenmiş sepeti al ve toplamını hesapla
                var updatedCart = await _cartService.GetByIdCartAsync(dto.CartId);
                decimal newTotalAmount = updatedCart.CartItems.Sum(item => item.TotalPrice);
                
                // Sepet toplamını güncelle
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
