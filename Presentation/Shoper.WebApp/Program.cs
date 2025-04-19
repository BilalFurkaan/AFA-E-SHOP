using Shoper.Domain.Entities;
using Shoper.Persistence.Context;
using Shoper.Persistence.Repositories;
using Shoper.Persistence.Repositories.CartRepository;
using Shoper.Persistence.Repositories.ProductsRepository;
using ShoperApplication.Interfaces;
using ShoperApplication.Interfaces.ICartRepository;
using ShoperApplication.Interfaces.IProductsRepository;
using ShoperApplication.Usecasess.CartItemServices;
using ShoperApplication.Usecasess.CartServices;
using ShoperApplication.Usecasess.CategoryServices;
using ShoperApplication.Usecasess.ProductServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddScoped(typeof(IRepository<>),typeof(Repository<>));
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICartRepository, CartsRepository>();
builder.Services.AddScoped(typeof(IProductsRepository), typeof(ProductsRepository));
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<ICartItemService, CartItemService>();



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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();