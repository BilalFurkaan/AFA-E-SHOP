using Shoper.Domain.Entities;
using ShoperApplication.Dtos.SubscriberDtos;
using ShoperApplication.Interfaces;

namespace ShoperApplication.Usecasess.SubscriberServices;

public class SubscriberService: ISubscriberService
{
    private readonly IRepository<Subscriber> _repository;

    public SubscriberService(IRepository<Subscriber> repository)
    {
        _repository = repository;
    }

    public async Task<List<ResultSubscriberDto>> GetAllAsyncSubscribers()
    {
        var values = await _repository.GetAllAsync();
        return values.Select(x => new ResultSubscriberDto
        {
            Id = x.Id,
            Name = x.Name,
            Email = x.Email,
            SubscriberDate = x.SubscriberDate
        }).ToList();
    }

    public async Task<GetByIdSubscriberDto> GetByIdSubscriberAsync(int id)
    {
        var value = await _repository.GetByIdAsync(id);
        var newsubscriber = new GetByIdSubscriberDto
        {
            Id = value.Id,
            Name = value.Name,
            Email = value.Email,
            SubscriberDate = value.SubscriberDate
        };
        return newsubscriber;

        
    }

    public async Task CreateSubscriberAsync(CreateSubscriberDto dto)
    {
        var subscriber = new Subscriber()
        {
            Name = dto.Name,
            Email = dto.Email,
            SubscriberDate = DateTime.UtcNow 
        };
        await _repository.CreateAsync(subscriber);
        
    }

    public async Task UpdateSubscriberAsync(UpdateSubscriberDto dto)
    {
        var subscriber=await _repository.GetByIdAsync(dto.Id);
        subscriber.Name = dto.Name;
        subscriber.Email = dto.Email;
        subscriber.SubscriberDate = DateTime.UtcNow;
        await _repository.UpdateAsync(subscriber);
    }

    public async Task DeleteSubscriberAsync(int id)
    {
        var subscriber = await _repository.GetByIdAsync(id);
        await _repository.DeleteAsync(subscriber);
    }
}