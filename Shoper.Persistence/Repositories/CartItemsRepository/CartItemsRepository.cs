using Microsoft.EntityFrameworkCore;
using Shoper.Persistence.Context;
using ShoperApplication.Dtos.CartItemDtos;
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
        var cartItem = await _context.CartItems
            .Include(x => x.Product)
            .Where(x => x.CartId == cartId && x.ProductId == productId)
            .SingleOrDefaultAsync();
            
        if (cartItem != null)
        {
            var unitPrice = cartItem.Product.Price;
            
            var newQuantity = cartItem.Quantity + quantity;
            
            if (newQuantity <= 0)
            {
                _context.CartItems.Remove(cartItem);
            }
            else
            {
                cartItem.Quantity = newQuantity;
                cartItem.TotalPrice = unitPrice * newQuantity;
            }
            
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

    public async Task UpdateQuantityOnCartAsync(UpdateCartItemDto dto)
    {
        var cartItem = await _context.CartItems
            .Include(x => x.Product)
            .Where(x => x.CartItemId == dto.CartItemId)
            .SingleOrDefaultAsync();
            
        if (cartItem != null)
        {
            var unitPrice = cartItem.Product.Price;
            
            if (dto.Quantity <= 0)
            {
                _context.CartItems.Remove(cartItem);
            }
            else
            {
                cartItem.Quantity = dto.Quantity;
                cartItem.TotalPrice = unitPrice * dto.Quantity;
            }
            
            await _context.SaveChangesAsync();
        }
    }
}