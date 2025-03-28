using Shoper.Domain.Entities;

namespace ShoperApplication.Dtos.CartItemDtos;

public class ResultCartItemDto
{
    public int CartItemId { get; set; }
    public int CartId { get; set; }
    public int ProductId { get; set; }
    public Product Product { get; set; }
    public int Quantity { get; set; }
    public decimal TotalPrice { get; set; }
}