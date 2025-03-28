using ShoperApplication.Dtos.CategoryDtos;
using ShoperApplication.Dtos.CustomerDtos;

namespace ShoperApplication.Usecasess.CustomerServices;

public interface ICustomerServices
{
    Task<List<ResultCustomerDto>> GetAllCustomerAsync();
    Task<GetByIdCustomerDto>  GetByIdCustomerAsync(int id);
    Task CreateCustomerAsync(CreateCustomerDto createCustomerDto);
    Task UpdateCustomerAsync(UpdateCustomerDto updateCustomerDto);
    Task DeleteCustomerAsync(int id);   
}