using Shoper.Domain.Entities;
using ShoperApplication.Dtos.ProductDtos;
using ShoperApplication.Interfaces;
using ShoperApplication.Interfaces.IProductsRepository;
using ShoperApplication.Usecasess.OrderServices;

namespace ShoperApplication.Usecasess.ProductServices;

public class ProductService:IProductService
{ 
   private readonly IRepository<Product> _repository;
   private readonly IProductsRepository _productsRepository;

   public ProductService(IRepository<Product> repository, IProductsRepository productsRepository)
   {
       _repository = repository;
       _productsRepository = productsRepository;
   }

   public async Task<List<ResultProductDto>> GetAllProductAsync()
    {
        var values=await _repository.GetAllAsync();
        return values.Select(x => new ResultProductDto
        {
            Productİd = x.Productİd,
            ProductName = x.ProductName,
            Desription = x.Desription,
            Price = x.Price,
            Stock = x.Stock,
            ImageUrl = x.ImageUrl,
            CategoryId = x.CategoryId,
            
        }).ToList();
    }

    public async Task<GetByIdProductDto> GetByIdProductAsync(int id)
    {
        var values=await _repository.GetByIdAsync(id);
        return new GetByIdProductDto
        {
            Productİd = values.Productİd,
            ProductName = values.ProductName,
            Desription = values.Desription,
            Price = values.Price,
            Stock = values.Stock,
            ImageUrl = values.ImageUrl,
            CategoryId = values.CategoryId,

        };
    }

    public async Task CreateProductAsync(CreateProductDto model)
    {
        await _repository.CreateAsync((new Product
        {
            ProductName = model.ProductName,
            Desription = model.Desription,
            Price = model.Price,
            Stock = model.Stock,
            ImageUrl = model.ImageUrl,
            CategoryId = model.CategoryId,
        }));
    }

    public async Task UpdateProductAsync(UpdateProductDto model)
    {
        var values = await _repository.GetByIdAsync(model.Productİd);
        values.ProductName = model.ProductName;
        values.Desription = model.Desription;
        values.Price = model.Price;
        values.Stock = model.Stock;
        values.ImageUrl = model.ImageUrl;
        values.CategoryId = model.CategoryId;
        await _repository.UpdateAsync(values);
        
    }

    public async Task DeleteProductAsync(int id)
    {
        var values = await _repository.GetByIdAsync(id);
        await _repository.DeleteAsync(values);
    }

    public async Task<List<ResultProductDto>> GetProductTake(int piece)
    {
        var values=await _repository.GetTakeAsync(piece);
        return values.Select(x => new ResultProductDto
        {
            Productİd = x.Productİd,
            ProductName = x.ProductName,
            Desription = x.Desription,
            Price = x.Price,
            Stock = x.Stock,
            ImageUrl = x.ImageUrl,
            CategoryId = x.CategoryId,
            
        }).ToList();
    }

    public async Task<List<ResultProductDto>> GetProductByCategory(int categoryId)
    {
        var values=await _productsRepository.GetProductByCategory(categoryId);
        return values.Select(x => new ResultProductDto
        {
            Productİd = x.Productİd,
            ProductName = x.ProductName,
            Desription = x.Desription,
            Price = x.Price,
            Stock = x.Stock,
            ImageUrl = x.ImageUrl,
            CategoryId = x.CategoryId,
            
        }).ToList();

    }

    public async Task<List<ResultProductDto>> GetProductByPrice(decimal minprice, decimal maxprice)
    {
        var values=await _productsRepository.GetProductByPriceFilter(minprice,maxprice);
        return values.Select(x => new ResultProductDto
        {
            Productİd = x.Productİd,
            ProductName = x.ProductName,
            Desription = x.Desription,
            Price = x.Price,
            Stock = x.Stock,
            ImageUrl = x.ImageUrl,
            CategoryId = x.CategoryId,
            
        }).ToList();
    }

    public async Task<List<ResultProductDto>> GetProductBySearch(string productName)
    {
        var values=await _productsRepository.GetProductBySearch(productName);
        return values.Select(x => new ResultProductDto
        {
            Productİd = x.Productİd,
            ProductName = x.ProductName,
            Desription = x.Desription,
            Price = x.Price,
            Stock = x.Stock,
            ImageUrl = x.ImageUrl,
            CategoryId = x.CategoryId,
            
        }).ToList();
    }
}