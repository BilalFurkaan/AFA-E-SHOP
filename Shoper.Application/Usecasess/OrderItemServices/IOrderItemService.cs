using ShoperApplication.Dtos.OrderItemDtos;

namespace ShoperApplication.Usecasess.OrderItemServices;

public interface IOrderItemService
{
    Task<List<ResultOrderItemDto>> GetAllOrderItemAsync();
    Task<GetByIdOrderItemDto>GetByIdOrderItemAsync(int id);
    Task CreateOrderItemAsync(CreateOrderItemDto model);
    Task UpdateOrderItemAsync(UpdateOrderItemDto model);
    Task DeleteOrderItemAsync(int id);   
}