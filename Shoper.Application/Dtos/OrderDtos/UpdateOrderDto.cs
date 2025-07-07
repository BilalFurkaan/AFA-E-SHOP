using Shoper.Domain.Entities;
using ShoperApplication.Dtos.OrderItemDtos;

namespace ShoperApplication.Dtos.OrderDtos;

public class UpdateOrderDto
{
    public int OrderId { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal TotalAmount { get; set; }
    public string OrderStatus { get; set; }

    public int ShippingCityId { get; set; }
    public int ShippingTownId { get; set; }
    public string ShippingAdress { get; set; }
    public int CustomerId { get; set; }
    public List<ResultOrderItemDto> OrderItems { get; set; }
}