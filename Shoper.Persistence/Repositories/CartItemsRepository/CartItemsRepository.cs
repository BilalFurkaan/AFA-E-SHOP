using Microsoft.EntityFrameworkCore;
using Shoper.Persistence.Context;
using ShoperApplication.Interfaces.ICartItemRepository;
using ShoperApplication.Usecasess.CartItemServices;

namespace Shoper.Persistence.Repositories.CartItemsRepository;

public class CartItemsRepository:ICartItemRepository
{
    private readonly AppDbContext _context;

    public CartItemsRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task UpdateQuantityAsync(int cartId, int productId, int quantity)
    {
        var cart = await _context.CartItems.Where(x => x.CartId == cartId && x.ProductId == productId)
            .SingleOrDefaultAsync();
        if (cart != null)
        {
            var tempprice= cart.TotalPrice / cart.Quantity;
            cart.Quantity += quantity;
            cart.TotalPrice =tempprice * cart.Quantity;
            await _context.SaveChangesAsync();
        }
        
    }

    public async Task<bool> CheckCartItemAsync(int cartId, int productId)
    {
        var items= await _context.CartItems
            .Where(x => x.CartId == cartId && x.ProductId == productId)
            .SingleOrDefaultAsync();
        if (items == null)
        {
            return false;
        }
        else
        {
            return true;    
        }
    }
}