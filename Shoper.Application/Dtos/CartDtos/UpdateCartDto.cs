using Shoper.Domain.Entities;
using ShoperApplication.Dtos.CartItemDtos;

namespace ShoperApplication.Dtos.CartDtos;

public class UpdateCartDto
{
    public int CartId { get; set; }
   // public decimal TotalAmount { get; set; }
   // public DateTime CreatedDate { get; set; }
   // public int CustomerId { get; set; }
   // public Customer? Customer { get; set; }
    public ICollection<UpdateCartItemDto> CartItems { get; set; }
}