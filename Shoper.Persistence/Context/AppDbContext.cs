using Microsoft.EntityFrameworkCore;
using Shoper.Domain.Entities;

namespace Shoper.Persistence.Context;

public class AppDbContext:DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("YourConnectionStringHere");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Customer - Order relationship
        modelBuilder.Entity<Customer>()
            .HasMany(c => c.Orders)
            .WithOne(o => o.Customer)
            .HasForeignKey(o => o.CustomerId)
            .OnDelete(DeleteBehavior.Cascade);

        // Customer - Cart relationship
        modelBuilder.Entity<Customer>()
            .HasMany(c => c.Carts)
            .WithOne(c => c.Customer)
            .HasForeignKey(c => c.CustomerId)
            .OnDelete(DeleteBehavior.Cascade);

        // Order - OrderItem relationship
        modelBuilder.Entity<Order>()
            .HasMany(o => o.OrderItems)
            .WithOne(oi => oi.Order)
            .HasForeignKey(oi => oi.OrderId)
            .OnDelete(DeleteBehavior.Cascade);

        // Product - OrderItem relationship
        modelBuilder.Entity<Product>()
            .HasMany(p => p.OrderItems)
            .WithOne(oi => oi.Product)
            .HasForeignKey(oi => oi.ProductId)
            .OnDelete(DeleteBehavior.Restrict);

        // Product - CartItem relationship
        modelBuilder.Entity<Product>()
            .HasMany(p => p.CartItems)
            .WithOne(ci => ci.Product)
            .HasForeignKey(ci => ci.ProductId)
            .OnDelete(DeleteBehavior.Restrict);

        // Category - Product relationship
        modelBuilder.Entity<Category>()
            .HasMany(c => c.Products)
            .WithOne(p => p.Category)
            .HasForeignKey(p => p.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);

        // City - Town relationship
        modelBuilder.Entity<City>()
            .HasMany(c => c.Towns)
            .WithOne(t => t.City)
            .HasForeignKey(t => t.CityId)
            .OnDelete(DeleteBehavior.Cascade);

        // Order - City/Town relationship
        modelBuilder.Entity<Order>()
            .HasOne(o => o.ShippingCity)
            .WithMany(c => c.Orders)
            .HasForeignKey(o => o.ShippingCityId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Order>()
            .HasOne(o => o.ShippingTown)
            .WithMany(t => t.Orders)
            .HasForeignKey(o => o.ShippingTownId)
            .OnDelete(DeleteBehavior.Restrict);
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
    public DbSet<Subscriber> Subscribers { get; set; }
    public DbSet<Help> Helps { get; set; }
    
    
    
 
}
