using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Shoper.Persistence.Context.Identity;

public class AppIdentityDbContext:IdentityDbContext<AppIdentityUser, AppIdentityRole, string>
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // TODO: Replace with your actual connection string
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Shoper;Username=your_username;Password=your_password");
    }
} 