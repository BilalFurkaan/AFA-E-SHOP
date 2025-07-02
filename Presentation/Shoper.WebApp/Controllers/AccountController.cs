using Microsoft.AspNetCore.Mvc;
using ShoperApplication.Dtos.AccountDtos;
using ShoperApplication.Usecasess.AccountServices;

namespace Shoper.WebApp.Controllers;

public class AccountController : Controller
{
    private readonly IAccountServices _accountServices;

    public AccountController(IAccountServices accountServices)
    {
        _accountServices = accountServices;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginDto dto)
    {
        var value= await _accountServices.Login(dto);
        return RedirectToAction("Index", "Home");
    }
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterDto dto)
    {
        var result = await _accountServices.Register(dto);
        if (result == "User registered successfully")
            return RedirectToAction("Login", "Account");
        ViewBag.Error = result;
        return View();
    }

    public async Task<IActionResult> Logout()
    {
        await _accountServices.LogoutAsync();
        return RedirectToAction("Index", "Home");
    }
}