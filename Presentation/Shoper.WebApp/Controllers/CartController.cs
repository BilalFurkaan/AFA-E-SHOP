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
                var cart=await _cartService.GetByIdCartAsync(model.CartId);
                var check=await _cartItemService.CheckCartItems(model.CartId,model.ProductId);
                if (check)
                {
                    await _cartItemService.UpdateQuantityAsync(model.CartId,model.ProductId,model.Quantity);
                }
                else
                {
                    await _cartItemService.CreateCartItemAsync(model);
                }
                var sumprice=cart.TotalAmount + model.TotalPrice;
                await _cartService.UpdateTotalAmount(model.CartId, sumprice);
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new{error=ex});
            }
        }


    }
}
