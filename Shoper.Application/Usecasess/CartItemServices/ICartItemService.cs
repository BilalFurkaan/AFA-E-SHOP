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
    Task UpdateQuantityAsync(int cartId, int productId, int quantity);
    Task<bool> CheckCartItems(int cartId, int productId);
    Task UpdateQuantityOnCart(UpdateCartItemDto dto);
   
}