using ShoperApplication.Dtos.OrderDtos;
using ShoperApplication.Dtos.ProfileDtos;

namespace ShoperApplication.Usecasess.ProfileServices;

public interface IProfileService
{
    Task<GetByIdProfileDto> GetByProfileIdAsync(int id);
    Task UpdateProfileAsync(UpdateProfileDto dto);
    
}