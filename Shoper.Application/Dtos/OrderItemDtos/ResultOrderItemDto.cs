using Shoper.Domain.Entities;

namespace ShoperApplication.Dtos.OrderItemDtos;

public class ResultOrderItemDto
{
    public int OrderItemId { get; set; }
    public int OrderId { get; set; }
   // public Order Order { get; set; }
    public int ProductId { get; set; }
    public Product Product { get; set; }
    public int Quantity { get; set; }
    public decimal TotalPrice { get; set; }
}