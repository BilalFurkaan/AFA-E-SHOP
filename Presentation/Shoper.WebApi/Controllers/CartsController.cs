using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shoper.Domain.Entities;
using ShoperApplication.Dtos.CartDtos;
using ShoperApplication.Usecasess.CartServices;
using ShoperApplication.Usecasess.ProductServices;

namespace Shoper.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        private readonly ICartService _service;

        public CartsController(ICartService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCart()
        {
           var values= await _service.GetAllCartAsync();
           return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCart(int id)
        {
            var values = await _service.GetByIdCartAsync(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCart(CreateCartDto dto)
        {
            await _service.CreateCartAsync(dto);
            return Ok("Created Cart Successfully");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCart(UpdateCartDto dto)
        {
            await _service.UpdateCartAsync(dto);
            return Ok("Updated Cart Successfully");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCart(int id)
        {
            await _service.DeleteCartAsync(id);
            return Ok("Deleted Cart Successfully");
        }
        
    }
}
