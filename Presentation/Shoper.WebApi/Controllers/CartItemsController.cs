using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shoper.Domain.Entities;
using ShoperApplication.Dtos.CartItemDtos;
using ShoperApplication.Usecasess.CartItemServices;
using ShoperApplication.Usecasess.ProductServices;

namespace Shoper.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartItemsController : ControllerBase
    {
        private readonly ICartItemService _service;

        public CartItemsController(ICartItemService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCartItems()
        {
            var values = await _service.GetAllCartItemAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCartItem(int id)
        {
            var values = await _service.GetByIdCartItemAsync(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCartItem(CreateCartItemDto dto)
        {
            await _service.CreateCartItemAsync(dto);
            return Ok("Created Cart Item Successfully");
        }
        
        [HttpPut]
        public async Task<IActionResult> UpdateCartItem(UpdateCartItemDto dto)
        {
            await _service.UpdateCartItemAsync(dto);
            return Ok("Updated Cart Item Successfully");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCartItem(int id)
        {
            await _service.DeleteCartItemAsync(id);
            return Ok("Deleted Cart Item Successfully");
        }
        
        
    }
}
