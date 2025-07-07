namespace Shoper.Domain.Entities;

public class City
{
    public int CityId { get; set; }
    public string CityName { get; set; }
    

    public ICollection<Town> Towns { get; set; }
    public ICollection<Order> Orders { get; set; }
}