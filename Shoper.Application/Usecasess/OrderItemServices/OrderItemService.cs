using Shoper.Domain.Entities;
using ShoperApplication.Dtos.OrderItemDtos;
using ShoperApplication.Interfaces;
using ShoperApplication.Usecasess.OrderServices;

namespace ShoperApplication.Usecasess.OrderItemServices;

public class OrderItemService: IOrderItemService
{
    private readonly IRepository<OrderItem> _repository;

    public OrderItemService(IRepository<OrderItem> repository)
    {
        _repository = repository;
    }

    public async Task<List<ResultOrderItemDto>> GetAllOrderItemAsync()
    {
       var values=await _repository.GetAllAsync();
       return values.Select(x => new ResultOrderItemDto
       {
           OrderId = x.OrderId,
           ProductId = x.ProductId,
           Quantity = x.Quantity,
           TotalPrice = x.TotalPrice,
           OrderItemId = x.OrderItemId,
       }).ToList();
    }

    public async Task<GetByIdOrderItemDto> GetByIdOrderItemAsync(int id)
    {
        var values=await _repository.GetByIdAsync(id);
        return new GetByIdOrderItemDto
        {
            OrderId = values.OrderId,
            ProductId = values.ProductId,
            Quantity = values.Quantity,
            TotalPrice = values.TotalPrice,
            OrderItemId = values.OrderItemId,

        };
    }

    public async Task CreateOrderItemAsync(CreateOrderItemDto model)
    {
        await _repository.CreateAsync(new OrderItem
        {
            //OrderId = model.OrderId,
            ProductId = model.ProductId,
            Quantity = model.Quantity,
            TotalPrice = model.TotalPrice,
        });
    }

    public async Task UpdateOrderItemAsync(UpdateOrderItemDto model)
    {
       var values= await _repository.GetByIdAsync(model.OrderItemId);
      // values.OrderId = model.OrderId;
       values.Quantity = model.Quantity;
       values.TotalPrice = model.TotalPrice;
       values.ProductId = model.ProductId;
       
    }

    public async Task DeleteOrderItemAsync(int id)
    {
        var values =await _repository.GetByIdAsync(id);
        await _repository.DeleteAsync(values);
    }
}