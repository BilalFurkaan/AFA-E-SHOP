namespace ShoperApplication.Interfaces.ICartItemRepository;

public interface ICartItemRepository
{
    Task UpdateQuantityAsync(int cartItemId, int quantity);
}