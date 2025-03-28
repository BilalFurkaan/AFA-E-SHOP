using Shoper.Domain.Entities;
using ShoperApplication.Dtos.OrderDtos;
using ShoperApplication.Dtos.OrderItemDtos;
using ShoperApplication.Interfaces;

namespace ShoperApplication.Usecasess.OrderServices;

public class OrderServices: IOrderServices
{
    private readonly IRepository<Order> _repository;
    private readonly IRepository<OrderItem> _orderItemRepository;
    private readonly IRepository<Customer> _customerRepository;
    private readonly IRepository<Product> _productRepository;

    public OrderServices(IRepository<Order> repository, IRepository<OrderItem> orderItemRepository, IRepository<Customer> customerRepository, IRepository<Product> productRepository)
    {
        _repository = repository;
        _orderItemRepository = orderItemRepository;
        _customerRepository = customerRepository;
        _productRepository = productRepository;
    }

    public async Task<List<ResultOrderDto>> GetAllOrderAsync()
    {
        var values = await _repository.GetAllAsync();
        var orderitem=await _orderItemRepository.GetAllAsync();
        var result = new List<ResultOrderDto>();
        foreach (var item in values)
        {
            var orderCustomer=await _customerRepository.GetByIdAsync(item.CustomerId);
            var oderdto=new ResultOrderDto
            {
                OrderId = item.OrderId,
                OrderDate = item.OrderDate,
                TotalAmount = item.TotalAmount,
                OrderStatus = item.OrderStatus,
                ShippingAdress = item.ShippingAdress,
                CustomerId = item.CustomerId,
                Customer= orderCustomer,
                OrderItems = new List<ResultOrderItemDto>()
            };
            foreach (var value in item.OrderItems)
            {
                var orderitemproduct=await _productRepository.GetByIdAsync(value.ProductId);
                var oderitemdto = new ResultOrderItemDto
                {
                    OrderId = value.OrderId,
                    ProductId = value.ProductId,
                    Quantity = value.Quantity,
                    TotalPrice = value.TotalPrice,
                    OrderItemId = value.OrderItemId,
                    Product = orderitemproduct,
                };
                oderdto.OrderItems.Add(oderitemdto);
            }
            result.Add(oderdto);
        }
        return result;
    }

    public async Task<GetByIdOrderDto> GetByIdOrderAsync(int id)
    {
        var values= await _repository.GetByIdAsync(id);
        var ordercustomer=await _customerRepository.GetByIdAsync(values.CustomerId);
        var result=new GetByIdOrderDto
        {
            OrderDate = values.OrderDate,
            TotalAmount = values.TotalAmount,
            OrderStatus = values.OrderStatus,
           // BillingAdress = values.BillingAdress,
            ShippingAdress = values.ShippingAdress,
           // PaymentMethod =  values.PaymentMethod,
            CustomerId = values.CustomerId,
            Customer = ordercustomer,
            OrderItems = new List<ResultOrderItemDto>()
        };
        foreach (var item in result.OrderItems)
        {
            var orderitemproduct=await _productRepository.GetByIdAsync(item.ProductId);
            var orderitemdto = new ResultOrderItemDto()
            { 
                OrderId = item.OrderId,
                ProductId = item.ProductId,
                Quantity = item.Quantity,
                TotalPrice = item.TotalPrice,
                OrderItemId = item.OrderItemId,
                Product = orderitemproduct,
            };
            result.OrderItems.Add(orderitemdto);

        }
        return result;

    }

    public async Task CreateOrderAsync(CreateOrderDto model)
    {
        decimal sum = 0;
        var order = new Order()
        {
            OrderDate = model.OrderDate,
            TotalAmount =sum, //model.TotalAmount, servis yazılıcak otomatik olarak hesaplanacak buradan elle girilmeyecek.
            OrderStatus = model.OrderStatus,
          //  BillingAdress = model.BillingAdress,
            ShippingAdress = model.ShippingAdress,
           // PaymentMethod = model.PaymentMethod,
            CustomerId = model.CustomerId
        };
        await _repository.CreateAsync(order);
        foreach (var item in model.OrderItems)
        {
            await _orderItemRepository.CreateAsync(new OrderItem
            {
                OrderId = order.OrderId,
                ProductId = item.ProductId,
                Quantity = item.Quantity,
                TotalPrice = item.TotalPrice,
            });
            sum=sum+item.TotalPrice;
        }
        order.TotalAmount = sum;
        await _repository.UpdateAsync(order);

    }

    public async Task UpdateOrderAsync(UpdateOrderDto model)
    {
        var values = await _repository.GetByIdAsync(model.OrderId);
        var oderitems=await _orderItemRepository.GetAllAsync();
        values.OrderStatus = model.OrderStatus;
        decimal sum = 0;
        foreach (var item in model.OrderItems)
        {
            foreach (var item1 in values.OrderItems)
            {
                var orderitemdto=await _orderItemRepository.GetByIdAsync(item1.OrderItemId);
                if (item.OrderItemId == item1.OrderItemId)
                {
                    orderitemdto.Quantity = item.Quantity;
                    orderitemdto.TotalPrice = item.TotalPrice;
                }
                sum=sum+item1.TotalPrice;
            }
        }

        values.TotalAmount = sum;

        await _repository.UpdateAsync(values);
    }

    public async Task DeleteOrderAsync(int id)
    {
       var values= await  _repository.GetByIdAsync(id);
       foreach (var item in values.OrderItems)
       {
           var oderItem= await _orderItemRepository.GetByIdAsync(item.OrderId);
           await _orderItemRepository.DeleteAsync(oderItem);
       }
       await _repository.DeleteAsync(values);
       
    }
    
}