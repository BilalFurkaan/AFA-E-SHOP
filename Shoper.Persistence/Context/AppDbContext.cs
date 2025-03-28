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
    
    
    // relationships

   /* protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Category>().
            HasMany(c=>c.Products).
            WithOne(p=>p.Category).
            HasForeignKey(p=>p.CategoryId);
        
        modelBuilder.Entity<Product>().
            HasOne(p => p.Category).
            WithMany(c => c.Products).
            HasForeignKey(p => p.CategoryId);
        
        modelBuilder.Entity<Customer>().
            HasMany(c => c.Orders).
            WithOne(o=>o.Customer).
            HasForeignKey(o=>o.CustomerId);
        
        modelBuilder.Entity<Order>().
            HasOne(o=>o.Customer).
            WithMany(c=>c.Orders).
            HasForeignKey(o=>o.CustomerId);
        
        modelBuilder.Entity<Order>().
            HasMany(o=>o.OrderItems)
            .WithOne(oi=>oi.Order).
            HasForeignKey(oi=>oi.OrderId);
        
        modelBuilder.Entity<OrderItem>().
            HasOne(oi=>oi.Order).
            WithMany(o=>o.OrderItems).
            HasForeignKey(oi=>oi.OrderId);
        
        
    }*/
}
