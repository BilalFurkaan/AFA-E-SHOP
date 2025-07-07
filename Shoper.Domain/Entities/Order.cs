namespace Shoper.Domain.Entities;

public class Order
{
    public int OrderId { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal TotalAmount { get; set; }
    public string OrderStatus { get; set; }

    public int ShippingCityId { get; set; }
    public int ShippingTownId { get; set; }
    public string ShippingAdress { get; set; }
    
    // Foreign Key
    public int CustomerId { get; set; }
    
    // Navigation Properties
    public Customer Customer { get; set; }
    public City ShippingCity { get; set; }
    public Town ShippingTown { get; set; }
    public ICollection<OrderItem> OrderItems { get; set; }
}