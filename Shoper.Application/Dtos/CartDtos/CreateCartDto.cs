using Shoper.Domain.Entities;
using ShoperApplication.Dtos.CartItemDtos;

namespace ShoperApplication.Dtos.CartDtos;

public class CreateCartDto
{

   // public decimal TotalAmount { get; set; }
    public DateTime CreatedDate { get; set; }
    public int CustomerId { get; set; }
    // public Customer? Customer { get; set; }
    public ICollection<CreateCartItemDto>? CartItems { get; set; }
}