using System.ComponentModel.DataAnnotations;

namespace Shoper.Domain.Entities;

public class Product
{
    [Key]
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public string ImageUrl { get; set; }
    public int CategoryId { get; set; }
    
    // Navigation Properties
    public Category Category { get; set; }
    public ICollection<OrderItem> OrderItems { get; set; }
    public ICollection<CartItem> CartItems { get; set; }
}