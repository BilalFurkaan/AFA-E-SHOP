using Shoper.Domain.Entities;
using Shoper.Persistence.Context;
using Shoper.Persistence.Repositories;
using Shoper.Persistence.Repositories.CartItemsRepository;
using Shoper.Persistence.Repositories.CartRepository;
using Shoper.Persistence.Repositories.ProductsRepository;
using ShoperApplication.Interfaces;
using ShoperApplication.Interfaces.ICartItemRepository;
using ShoperApplication.Interfaces.ICartRepository;
using ShoperApplication.Interfaces.IProductsRepository;
using ShoperApplication.Usecasess.CartItemServices;
using ShoperApplication.Usecasess.CartServices;
using ShoperApplication.Usecasess.CategoryServices;
using ShoperApplication.Usecasess.CustomerServices;
using ShoperApplication.Usecasess.OrderItemServices;
using ShoperApplication.Usecasess.OrderServices;
using ShoperApplication.Usecasess.ProductServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddControllers();
builder.Services.AddScoped(typeof(IRepository<>),typeof(Repository<>));
builder.Services.AddScoped<ICategoryServices, CategoryServices>();
builder.Services.AddScoped<ICustomerServices,  CustomerServices>();
builder.Services.AddScoped<IOrderServices,  OrderServices>();
builder.Services.AddScoped<IOrderItemService,  OrderItemService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<ICartItemService, CartItemService>();
builder.Services.AddScoped<IProductsRepository, ProductsRepository>();
builder.Services.AddScoped<ICartRepository, CartsRepository>();
builder.Services.AddScoped<ICartItemRepository, CartItemsRepository>();




// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
