using Shoper.Domain.Entities;

namespace ShoperApplication.Dtos.CustomerDtos;

public class GetByIdCustomerDto
{
    public int CustomerId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    //public ICollection<Order> Orders { get; set; }
}