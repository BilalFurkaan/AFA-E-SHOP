using Shoper.Domain.Entities;

namespace ShoperApplication.Dtos.ProductDtos;

public class UpdateProductDto
{
    public int Productİd { get; set; }
    public string ProductName { get; set; }
    public string Desription { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public string ImageUrl { get; set; }
    public int CategoryId { get; set; }
  //  public Category Category { get; set; }  
}