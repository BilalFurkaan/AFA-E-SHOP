using Microsoft.EntityFrameworkCore;
using Shoper.Persistence.Context;
using ShoperApplication.Interfaces.ICartRepository;

namespace Shoper.Persistence.Repositories.CartRepository;

public class CartsRepository: ICartRepository
{
    private readonly AppDbContext _context;

    public CartsRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task UpdateTotalAmountAsync(int cartId, decimal totalPrice)
    {
        var value= await _context.Carts.Where(x=> x.CartId == cartId).FirstOrDefaultAsync();
        if (value != null)
        {
            value.TotalAmount = totalPrice;
        }
        await _context.SaveChangesAsync();
        
    }
}