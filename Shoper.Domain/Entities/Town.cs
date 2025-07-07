namespace Shoper.Domain.Entities;

public class Town
{
    public int TownId { get; set; }
    public int CityId { get; set; }
    public string TownName { get; set; }
    
    // Navigation Properties
    public City City { get; set; }
    public ICollection<Order> Orders { get; set; }
}