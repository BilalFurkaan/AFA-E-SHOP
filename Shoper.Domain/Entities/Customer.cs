namespace Shoper.Domain.Entities;

public class Customer
{
    public int CustomerId { get; set; }
    public string IdentityId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    
    // Navigation Properties
    public ICollection<Order> Orders { get; set; }
    public ICollection<Cart> Carts { get; set; }
}