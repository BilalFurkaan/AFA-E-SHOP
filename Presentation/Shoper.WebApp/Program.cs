using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Shoper.Domain.Entities;
using Shoper.Persistence.Context;
using Shoper.Persistence.Context.Identity;
using Shoper.Persistence.Repositories;
using Shoper.Persistence.Repositories.CartItemsRepository;
using Shoper.Persistence.Repositories.CartRepository;
using Shoper.Persistence.Repositories.OrderRepository;
using Shoper.Persistence.Repositories.ProductsRepository;
using ShoperApplication.Interfaces;
using ShoperApplication.Interfaces.ICartItemRepository;
using ShoperApplication.Interfaces.ICartRepository;
using ShoperApplication.Interfaces.IOrderRepository;
using ShoperApplication.Interfaces.IProductsRepository;
using ShoperApplication.Usecasess.AccountServices;
using ShoperApplication.Usecasess.CartItemServices;
using ShoperApplication.Usecasess.CartServices;
using ShoperApplication.Usecasess.CategoryServices;
using ShoperApplication.Usecasess.OrderServices;
using ShoperApplication.Usecasess.ProductServices;
using ShoperApplication.Usecasess.SubscriberServices;
using ShoperApplication.Usecasess.HelpServices;
using ShoperApplication.Usecasess.CustomerServices;
using ShoperApplication.Usecasess.ProfileServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddScoped(typeof(IRepository<>),typeof(Repository<>));
builder.Services.AddScoped<IUserIdentityRepository, UserIdentityRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductsRepository, ProductsRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<ICartRepository, CartsRepository>();
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<ICartItemService, CartItemService>();
builder.Services.AddScoped<ICartItemRepository, CartItemsRepository>();
builder.Services.AddScoped<IOrderServices, OrderServices>();
builder.Services.AddScoped<IAccountServices, AccountServices>();
builder.Services.AddScoped<ISubscriberService, SubscriberService>();
builder.Services.AddScoped<IHelpService, HelpService>();
builder.Services.AddScoped<ICustomerServices, CustomerServices>();
builder.Services.AddScoped<IProfileService, ProfileService>();

// AppIdentityDbContext - OnConfiguring metodunda connection string kullanıyor
builder.Services.AddDbContext<AppIdentityDbContext>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login";
    });
builder.Services.AddIdentity<AppIdentityUser, AppIdentityRole>()
    .AddEntityFrameworkStores<AppIdentityDbContext>()
    .AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(options =>
{

    //options.Password.RequireDigit = true;
    options.Password.RequiredLength = 6;  
    options.Password.RequireLowercase = true; 
    options.Password.RequireLowercase = true; 
    options.Password.RequireNonAlphanumeric = false; 

    options.Lockout.MaxFailedAccessAttempts = 5; 
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.AllowedForNewUsers = true; 

    options.User.RequireUniqueEmail = true; 

    options.SignIn.RequireConfirmedEmail = false; 
    options.SignIn.RequireConfirmedPhoneNumber = false;
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();