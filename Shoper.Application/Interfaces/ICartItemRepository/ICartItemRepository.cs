using ShoperApplication.Dtos.CartItemDtos;

namespace ShoperApplication.Interfaces.ICartItemRepository;

public interface ICartItemRepository
{
    Task UpdateQuantityAsync(int cartId,int productId, int quantity);
    Task<bool>CheckCartItemAsync(int cartId, int productId);
    Task UpdateQuantityOnCartAsync(UpdateCartItemDto dto);
}