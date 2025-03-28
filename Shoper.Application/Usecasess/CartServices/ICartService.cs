using ShoperApplication.Dtos.CartDtos;

namespace ShoperApplication.Usecasess.CartServices;

public interface ICartService
{
    Task<List<ResultCartDto>> GetAllCartAsync();
    Task<GetByIdCartDto>GetByIdCartAsync(int id);
    Task CreateCartAsync(CreateCartDto model);
    Task UpdateCartAsync(UpdateCartDto model);
    Task DeleteCartAsync(int id); 
}