using Microsoft.EntityFrameworkCore;
using Shoper.Domain.Entities;

namespace Shoper.Persistence.Context;

public class AppDbContext:DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Shoper;Username=postgres;Password=10Furkan16.");
    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<Cart> Carts { get; set; }
    public DbSet<CartItem>CartItems{ get; set; }
    public DbSet<City>Citys{ get; set; }
    public DbSet<Town>Towns{ get; set; }
    
    
    
 
}
