using Shoper.Domain.Entities;
using ShoperApplication.Dtos.CartDtos;
using ShoperApplication.Dtos.CartItemDtos;
using ShoperApplication.Interfaces;
using ShoperApplication.Interfaces.ICartRepository;

namespace ShoperApplication.Usecasess.CartServices;

public class CartService: ICartService
{
    private readonly IRepository<Cart> _repository;
    private readonly IRepository<CartItem> _itemRepository;
    private readonly IRepository<Customer> _customerRepository;
    private readonly IRepository<Product> _productRepository;
    private readonly ICartRepository _cartRepository;

    public CartService(IRepository<Cart> cartRepository, IRepository<CartItem> cartItemRepository, IRepository<Customer> customerRepository, IRepository<Product> productRepository, ICartRepository cartRepository1)
    {
        _repository = cartRepository;
        _itemRepository = cartItemRepository;
        _customerRepository = customerRepository;
        _productRepository = productRepository;
        _cartRepository = cartRepository1;
    }

    public async Task<List<ResultCartDto>> GetAllCartAsync()
    {
        var carts=await _repository.GetAllAsync();
        var cartItems=await _itemRepository.GetAllAsync();
        var product=await _productRepository.GetAllAsync();
        var result=new List<ResultCartDto>();
        foreach (var item in carts)
        {
            var customerdto=await _customerRepository.GetByFilterAsync(cus=>cus.CustomerId==item.CustomerId);
            var cartDto = new ResultCartDto
            {
                CartId = item.CartId,
                CreatedDate = item.CreatedDate,
                CustomerId = item.CustomerId,
                Customer = customerdto,
                TotalAmount = item.TotalAmount,
                CartItems = new List<ResultCartItemDto>()
            };
            foreach (var value in item.CartItems)
            {
                var productdto=await _productRepository.GetByFilterAsync(prd=>prd.Productİd==value.ProductId);
                var cartItemdto = new ResultCartItemDto
                {
                    CartId = value.CartId,
                    CartItemId = value.CartItemId,
                    ProductId = value.ProductId,
                    Product = productdto,
                    Quantity = value.Quantity,
                    TotalPrice = value.TotalPrice,
                };
                cartDto.CartItems.Add(cartItemdto);
            }
            result.Add(cartDto);
        }
        return result;
    }

    public async Task<GetByIdCartDto> GetByIdCartAsync(int id)
    {
        var cart = await _repository.GetByIdAsync(id);
        var cartItem = await _itemRepository.GetAllAsync();
        var customer = await _customerRepository.GetByIdAsync(id);
        var result = new GetByIdCartDto
        {
            CartId = cart.CartId,
            CartItems = new List<ResultCartItemDto>(),
            CreatedDate = cart.CreatedDate,
            CustomerId = cart.CustomerId,
            Customer = customer,
            TotalAmount = cart.TotalAmount,
        };
        foreach (var item in cart.CartItems)
        {
            var productdto=await _productRepository.GetByFilterAsync(prd=>prd.Productİd==item.ProductId);
            var cartItemdto = new ResultCartItemDto
            {
                CartId = item.CartId,
                CartItemId = item.CartItemId,
                ProductId = item.ProductId,
                Product = productdto,
                Quantity = item.Quantity,
                TotalPrice =item.TotalPrice,
            };
            result.CartItems.Add(cartItemdto);   
        }
        return result;
    }

    public async Task CreateCartAsync(CreateCartDto model)
    {
        var cart = new Cart
        {
           // TotalAmount = model.TotalAmount, aşşağıda otomatik olarak alıyorum
            CreatedDate = model.CreatedDate,
            CustomerId = model.CustomerId,

        };
        await _repository.CreateAsync(cart);
        decimal sum = 0;//var?
        foreach (var item in model.CartItems)
        {
            var cartitem = new CartItem
            {
                CartId = cart.CartId,
                ProductId = item.ProductId,
                Quantity = item.Quantity,
                TotalPrice = item.TotalPrice,//produca gidip fiyatı alıcak ve adetle çarpacak
            };
            sum=sum+(item.Quantity*item.TotalPrice);
            await _itemRepository.CreateAsync(cartitem);
        }
        cart.TotalAmount = sum;
        await _repository.UpdateAsync(cart);

    }

    public async Task UpdateCartAsync(UpdateCartDto model)
    { 

        var cart = await _repository.GetByIdAsync(model.CartId); 
        var cartItems=await _itemRepository.GetAllAsync();
        //  cart.CreatedDate = model.CreatedDate;
        //  cart.CustomerId = model.CustomerId;
        //  cart.TotalAmount = model.TotalAmount;
        decimal sum = 0;
        foreach (var item1 in model.CartItems)
        {
          foreach (var item in cart.CartItems)
          { 
              var cartItem = await _itemRepository.GetByIdAsync(item.CartItemId);
               if (item.CartItemId == item1.CartItemId)
              {
                  cartItem.Quantity=item1.Quantity;
                  cartItem.TotalPrice=item1.TotalPrice;
              }

              sum = sum + item.TotalPrice;
          }
          
        }
        cart.TotalAmount = sum;
        await _repository.UpdateAsync(cart);
    }

    public async Task DeleteCartAsync(int id)
    {
        var cart = await _repository.GetByIdAsync(id);
        var cartItems = await _itemRepository.GetAllAsync();
        foreach (var item in cartItems)
        {
            if (item.CartId == id)
            {
                var cartitem=await _itemRepository.GetByIdAsync(item.CartItemId);
                await _itemRepository.DeleteAsync(cartitem);
            }
        }
        await _repository.DeleteAsync(cart);
    }

    public async Task UpdateTotalAmount(int cartId, decimal totalAmount)
    {
        await _cartRepository.UpdateTotalAmountAsync(cartId, totalAmount);
    }
}
