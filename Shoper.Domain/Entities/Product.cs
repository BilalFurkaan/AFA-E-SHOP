using System.ComponentModel.DataAnnotations;

namespace Shoper.Domain.Entities;

public class Product
{
    [Key]
    public int Productİd { get; set; }
    public string ProductName { get; set; }
    public string Desription { get; set; }// YAZIMI YANLIŞ DÜZELTİLECEK
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public string ImageUrl { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }  
    
}