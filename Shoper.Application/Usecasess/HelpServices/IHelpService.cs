using ShoperApplication.Dtos.HelpDtos;

namespace ShoperApplication.Usecasess.HelpServices;

public interface IHelpService
{
    Task<List<ResultHelpDto>>GetAllAsyncHelps();
    Task<GetByIdHelpDto> GetByIdHelpAsync(int id);
    Task CreateHelpAsync(CreateHelpDto dto);
    Task UpdateHelpAsync(UpdateHelpDto dto);
    Task DeleteHelpAsync(int id);
    
}