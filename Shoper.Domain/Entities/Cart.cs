using System.Reflection.Metadata.Ecma335;

namespace Shoper.Domain.Entities;

public class Cart
{
    public int CartId { get; set; }
    public decimal TotalAmount { get; set; }
    public DateTime CreatedDate { get; set; }
    public int CustomerId { get; set; }
   // public Customer? Customer { get; set; }
    public ICollection<CartItem> CartItems { get; set; }
    
}