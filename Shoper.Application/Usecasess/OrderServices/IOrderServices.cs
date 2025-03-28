using ShoperApplication.Dtos.OrderDtos;

namespace ShoperApplication.Usecasess.OrderServices;

public interface IOrderServices
{
    Task<List<ResultOrderDto>> GetAllOrderAsync();
    Task<GetByIdOrderDto>GetByIdOrderAsync(int id);
    Task CreateOrderAsync(CreateOrderDto model);
    Task UpdateOrderAsync(UpdateOrderDto model);
    Task DeleteOrderAsync(int id);   
}