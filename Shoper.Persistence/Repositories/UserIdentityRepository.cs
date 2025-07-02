using Microsoft.AspNetCore.Identity;
using Shoper.Persistence.Context.Identity;
using ShoperApplication.Dtos.AccountDtos;
using ShoperApplication.Interfaces;

namespace Shoper.Persistence.Repositories;

public class UserIdentityRepository: IUserIdentityRepository
{
    private readonly UserManager<AppIdentityUser> _userManager;
    private readonly SignInManager<AppIdentityUser> _signInManager;

    public UserIdentityRepository(UserManager<AppIdentityUser> userManager, SignInManager<AppIdentityUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public async Task<string> LoginAsync(LoginDto dto)
    {
        var user=await _userManager.FindByEmailAsync(dto.Email);
        if (user == null)
        {
            return "User not found";
        }
        var result = await _signInManager.PasswordSignInAsync(dto.Email, dto.Password, true, false);
        if (result.Succeeded)
        {
            return "Login successful";
        }
        if (result.IsLockedOut)
        {
            return "User is locked out";
        }
        if (result.IsNotAllowed)
        {
            return "User is not allowed to login";
        }
        if (result.RequiresTwoFactor)
        {
            return "Two factor authentication is required";
        }
        return "Login failed";
    }

    public async Task<string> RegisterAsync(RegisterDto dto)
    {
        if (dto.Password!=dto.RePassword)
        {
            throw new Exception("Passwords do not match");
        }
        var user= new AppIdentityUser
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            PhoneNumber = dto.PhoneNumber,
            Email = dto.Email,
            UserName = dto.Email
            
        };
        var result= await _userManager.CreateAsync(user,dto.Password);
        if (result.Succeeded)
        {
            return "User registered successfully";
        }
        else
        {
            var errors = string.Join(", ", result.Errors.Select(e => e.Description));
            return errors;
        }
    }

    public async Task<string> ChangePasswordAsync()
    {
        throw new NotImplementedException();
    }

    public async Task LogoutAsync()
    {
        await _signInManager.SignOutAsync();
    }
}