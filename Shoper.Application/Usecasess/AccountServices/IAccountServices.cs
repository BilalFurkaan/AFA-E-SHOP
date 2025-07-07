using ShoperApplication.Dtos.AccountDtos;

namespace ShoperApplication.Usecasess.AccountServices;

public interface IAccountServices
{
    Task<string> Login(LoginDto dto);
    Task<string> Register(RegisterDto dto);
    Task<string> ChangePassword(ChangePasswordDto dto, string userId);
    Task LogoutAsync();
}