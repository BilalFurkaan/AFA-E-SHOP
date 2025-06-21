using Shoper.Domain.Entities;
using ShoperApplication.Dtos.CartItemDtos;
using ShoperApplication.Interfaces;
using ShoperApplication.Interfaces.ICartItemRepository;
using ShoperApplication.Usecasess.OrderItemServices;

namespace ShoperApplication.Usecasess.CartItemServices;

public class CartItemService: ICartItemService
{
    private readonly IRepository<CartItem> _repository;
    private readonly ICartItemRepository _cartItemRepository;
    

    public CartItemService(IRepository<CartItem> repository, ICartItemRepository cartItemRepository)
    {
        _repository = repository;
        _cartItemRepository = cartItemRepository;
    }

    public async Task<List<ResultCartItemDto>> GetAllCartItemAsync()
    {
        var cartItems= await _repository.GetAllAsync();
        return cartItems.Select(x => new ResultCartItemDto
        {
          CartId  = x.CartId,
          ProductId = x.ProductId,
          Quantity = x.Quantity,
          TotalPrice = x.TotalPrice,
        }).ToList();
    }

    public async Task<GetByIdCartItemDto> GetByIdCartItemAsync(int id)
    {
        var cartItem = await _repository.GetByIdAsync(id);
        return new GetByIdCartItemDto
        {
            CartId = cartItem.CartId,
            ProductId = cartItem.ProductId,
            Quantity = cartItem.Quantity,
            TotalPrice = cartItem.TotalPrice,
        };
    }

    public async Task CreateCartItemAsync(CreateCartItemDto model)
    {
        var cartItem = new CartItem()
        {
            CartId = model.CartId,
            ProductId = model.ProductId,
            Quantity = model.Quantity,
            TotalPrice = model.TotalPrice * model.Quantity
        };
            await _repository.CreateAsync(cartItem);
    }

    public async Task UpdateCartItemAsync(UpdateCartItemDto model)
    {
        var cartItem = await _repository.GetByIdAsync(model.CartItemId);
        cartItem.Quantity = model.Quantity;
        cartItem.TotalPrice = model.TotalPrice;
        cartItem.ProductId = model.ProductId;
        //cartItem.CartId = model.CartId;
        await _repository.UpdateAsync(cartItem);
    }

    public async Task DeleteCartItemAsync(int id)
    {
      var cartItem = await _repository.GetByIdAsync(id);
      
      await _repository.DeleteAsync(cartItem);
    }

    public async Task<List<ResultCartItemDto>> GetByCartIdCartItemsAsync(int cartId)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateQuantityAsync(int cartId, int productId, int quantity)
    {
        var cart = await _repository.GetByIdAsync(cartId);
        var tempprice= cart.TotalPrice / cart.Quantity; // 100 / 1 = 100
        cart.Quantity += quantity; // 1 + 1 = 2
        cart.TotalPrice =tempprice * cart.Quantity; // 100 * 2 = 200
        await _repository.UpdateAsync(cart);
    }

    public async Task<bool> CheckCartItems(int cartId, int productId)
    {
        var value= await _cartItemRepository.CheckCartItemAsync(cartId, productId);
        return value;
    }

    public async Task UpdateQuantityOnCart(UpdateCartItemDto dto)
    {
        await _cartItemRepository.UpdateQuantityOnCartAsync(dto);
    }
}