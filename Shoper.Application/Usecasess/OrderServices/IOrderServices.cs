using ShoperApplication.Dtos.CityDtos;
using ShoperApplication.Dtos.OrderDtos;
using ShoperApplication.Dtos.TownDtos;

namespace ShoperApplication.Usecasess.OrderServices;

public interface IOrderServices
{
    Task<List<ResultOrderDto>> GetAllOrderAsync();
    Task<GetByIdOrderDto>GetByIdOrderAsync(int id);
    Task CreateOrderAsync(CreateOrderDto model);
    Task UpdateOrderAsync(UpdateOrderDto model);
    Task DeleteOrderAsync(int id);  
    Task <List<ResultCityDto>> GetAllCitiesAsync();
    Task<List<GetByIdTownDto>> GetTownsAsync(int cityId);
    Task <List<ResultOrderDto>> GetOrdersByCustomerIdAsync(int customerId);
}