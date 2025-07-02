using ShoperApplication.Dtos.AccountDtos;
using ShoperApplication.Interfaces;

namespace ShoperApplication.Usecasess.AccountServices;

public class AccountServices: IAccountServices
{
    private readonly IUserIdentityRepository _userIdentityRepository;

    public AccountServices(IUserIdentityRepository userIdentityRepository)
    {
        _userIdentityRepository = userIdentityRepository;
    }

    public async Task<string> Login(LoginDto dto)
    {
        var result=await _userIdentityRepository.LoginAsync(dto);
        return result;
    }

    public async Task<string> Register(RegisterDto dto)
    {
        var result = await _userIdentityRepository.RegisterAsync(dto);
        return result;
    }

    public async Task<string> ChangePassword()
    {
        throw new NotImplementedException();
    }

    public async Task LogoutAsync()
    {
        await _userIdentityRepository.LogoutAsync();
    }
}