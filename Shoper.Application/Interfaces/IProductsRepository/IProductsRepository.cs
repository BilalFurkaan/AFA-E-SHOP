using Shoper.Domain.Entities;
using ShoperApplication.Dtos.ProductDtos;

namespace ShoperApplication.Interfaces.IProductsRepository;

public interface IProductsRepository
{
    Task<List<Product>> GetProductByCategory(int categoryId);
    Task<List<Product>> GetProductByPriceFilter(decimal minprice, decimal maxprice);
    Task<List<Product>> GetProductBySearch(string productName);
}