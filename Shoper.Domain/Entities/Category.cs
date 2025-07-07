using System.Reflection.Metadata.Ecma335;

namespace Shoper.Domain.Entities;

public class Category
{
    public int CategoryId { get; set; }
    public string CategoryName { get; set; }
    
    // Navigation Properties
    public ICollection<Product> Products { get; set; }
} 