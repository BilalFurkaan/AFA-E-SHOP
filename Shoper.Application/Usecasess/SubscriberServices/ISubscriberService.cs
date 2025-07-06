using Shoper.Domain.Entities;
using ShoperApplication.Dtos.SubscriberDtos;

namespace ShoperApplication.Usecasess.SubscriberServices;

public interface ISubscriberServices
{
    Task<List<ResultSubscriberDto>> GetAllSubscribers();
    Task<GetByIdSubscriberDto> GetByIdSubscriberAsync(int id);
    Task CreateSubscriberAsync(CreateSubscriberDto model);
    Task UpdateSubscriberAsync(UpdateSubscriberDto model);
    Task DeleteSubscriberAsync(int id);
}