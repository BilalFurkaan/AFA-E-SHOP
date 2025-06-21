using System.Reflection.Metadata.Ecma335;
using System.Security.AccessControl;

namespace Shoper.Domain.Entities;

public class CartItem
{
    public int CartItemId { get; set; }
    public int CartId { get; set; }
    public int ProductId { get; set; }
    public Product Product { get; set; }
    public int Quantity { get; set; }
    public decimal TotalPrice { get; set; }
    
    
    
}