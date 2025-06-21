namespace ShoperApplication.Interfaces.ICartRepository;

public interface ICartRepository
{
    Task UpdateTotalAmountAsync(int cartId, decimal totalPrice);
    

}