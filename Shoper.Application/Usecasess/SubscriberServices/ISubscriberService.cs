using Shoper.Domain.Entities;
using ShoperApplication.Dtos.SubscriberDtos;

namespace ShoperApplication.Usecasess.SubscriberServices;

public interface ISubscriberService
{
    Task<List<ResultSubscriberDto>> GetAllAsyncSubscribers();
    Task<GetByIdSubscriberDto> GetByIdSubscriberAsync(int id);
    Task CreateSubscriberAsync(CreateSubscriberDto dto);
    Task UpdateSubscriberAsync(UpdateSubscriberDto dto);
    Task DeleteSubscriberAsync(int id);
}