using ShoperApplication.Dtos.CartItemDtos;

namespace ShoperApplication.Usecasess.CartItemServices;

public interface ICartItemService
{
    Task<List<ResultCartItemDto>> GetAllCartItemAsync();
    Task<GetByIdCartItemDto>GetByIdCartItemAsync(int id);
    Task CreateCartItemAsync(CreateCartItemDto model);
    Task UpdateCartItemAsync(UpdateCartItemDto model);
    Task DeleteCartItemAsync(int id);  
    Task <List<ResultCartItemDto>>GetByCartIdCartItemsAsync(int cartId);
   
}