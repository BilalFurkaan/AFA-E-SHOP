using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Shoper.Domain.Entities;
using Shoper.Persistence.Context;
using ShoperApplication.Dtos.ProductDtos;
using ShoperApplication.Interfaces.IProductsRepository;

namespace Shoper.Persistence.Repositories.ProductsRepository;

public class ProductsRepository:IProductsRepository
{
    private readonly AppDbContext _context;

    public ProductsRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task<List<Product>> GetProductByCategory(int categoryId)
    {
        return await _context.Products.Where(x => x.CategoryId == categoryId).ToListAsync();
    }

    public async Task<List<Product>> GetProductByPriceFilter(decimal minprice, decimal maxprice)
    {
        return await _context.Products.Where(x => x.Price >= minprice && x.Price <= maxprice).ToListAsync();
    }

    public async Task<List<Product>> GetProductBySearch(string productName)
    {
        return await _context.Products.Where(x => x.ProductName.Contains(productName) || x.Desription.Contains(productName)).ToListAsync();
    }
}

