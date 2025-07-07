using Microsoft.AspNetCore.Identity;
using Shoper.Persistence.Context.Identity;
using ShoperApplication.Dtos.AccountDtos;
using ShoperApplication.Interfaces;
using ShoperApplication.Usecasess.CustomerServices;

namespace Shoper.Persistence.Repositories;

public class UserIdentityRepository: IUserIdentityRepository
{
    private readonly UserManager<AppIdentityUser> _userManager;
    private readonly SignInManager<AppIdentityUser> _signInManager;
    private readonly ICustomerServices _customerServices;

    public UserIdentityRepository(UserManager<AppIdentityUser> userManager, SignInManager<AppIdentityUser> signInManager, ICustomerServices customerServices)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _customerServices = customerServices;
    }

    public async Task<string> LoginAsync(LoginDto dto)
    {
        var user=await _userManager.FindByEmailAsync(dto.Email);
        if (user == null)
        {
            throw new Exception("User not found");
        }
        var result = await _signInManager.PasswordSignInAsync(dto.Email, dto.Password, true, false);
        if (result.Succeeded)
        {
            return "Login successful";
        }
        if (result.IsLockedOut)
        {
            throw new Exception("User is locked out");
        }
        if (result.IsNotAllowed)
        {
            throw new Exception("User is not allowed to login");
        }
        if (result.RequiresTwoFactor)
        {
            throw new Exception("Two factor authentication is required");
        }
        throw new Exception("Login failed");
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
        var result= await _userManager.CreateAsync(user, dto.Password);
        if (result.Succeeded)
        {
            await _customerServices.CreateCustomerAsync(new ShoperApplication.Dtos.CustomerDtos.CreateCustomerDto
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                IdentityId = user.Id
            });
            return "User registered successfully";
        }
        else
        {
            return result.Errors.ToString();
        }
    }

    public async Task<string> ChangePasswordAsync(ChangePasswordDto dto, string userId)
    {
        if (dto.NewPassword != dto.ConfirmPassword)
        {
            return "New password and confirmation do not match.";
        }
        var user = await _userManager.FindByIdAsync(userId);
        if (user == null)
        {
            return "User not found.";
        }
        var result = await _userManager.ChangePasswordAsync(user, dto.OldPassword, dto.NewPassword);
        if (result.Succeeded)
        {
            return "Password changed successfully.";
        }
        return string.Join("; ", result.Errors.Select(e => e.Description));
    }

    public async Task LogoutAsync()
    {
        await _signInManager.SignOutAsync();
    }
}