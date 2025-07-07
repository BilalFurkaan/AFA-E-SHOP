using ShoperApplication.Dtos.AccountDtos;

namespace ShoperApplication.Interfaces;

public interface IUserIdentityRepository
{
    Task<string> LoginAsync(LoginDto dto);
    Task<string> RegisterAsync(RegisterDto dto);
    Task<string> ChangePasswordAsync(ChangePasswordDto dto, string userId);
    Task LogoutAsync();
}