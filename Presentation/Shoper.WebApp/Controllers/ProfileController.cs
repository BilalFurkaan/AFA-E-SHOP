using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShoperApplication.Dtos.ProfileDtos;
using ShoperApplication.Dtos.OrderDtos;
using ShoperApplication.Dtos.AccountDtos;
using ShoperApplication.Usecasess.ProfileServices;
using ShoperApplication.Usecasess.OrderServices;
using ShoperApplication.Usecasess.CustomerServices;
using ShoperApplication.Usecasess.AccountServices;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Security.Claims;

namespace Shoper.WebApp.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly IProfileService _profileService;
        private readonly IOrderServices _orderService;
        private readonly ICustomerServices _customerService;
        private readonly IAccountServices _accountServices;

        public ProfileController(IProfileService profileService, IOrderServices orderService, ICustomerServices customerService, IAccountServices accountServices)
        {
            _profileService = profileService;
            _orderService = orderService;
            _customerService = customerService;
            _accountServices = accountServices;
        }

        public async Task<IActionResult> Index()
        {
            // Giriş yapan kullanıcının IdentityId'sini al
            var identityId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            
            if (string.IsNullOrEmpty(identityId))
            {
                return RedirectToAction("Login", "Account");
            }

            // IdentityId ile Customer'ı bul
            var customer = await _customerService.GetByIdentityIdAsync(identityId);
            
            if (customer == null)
            {
                return RedirectToAction("Login", "Account");
            }

            int customerId = customer.CustomerId;

            var profile = await _profileService.GetByProfileIdAsync(customerId);
            var orders = await _orderService.GetOrdersByCustomerIdAsync(customerId);

            ViewBag.Orders = orders;
            return View(profile);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProfile(GetByIdProfileDto model)
        {
            // Güncelleme için UpdateProfileDto'ya mapleyin
            var updateDto = new UpdateProfileDto
            {
                CustomerId = model.CustomerId,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber
            };

            await _profileService.UpdateProfileAsync(updateDto);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordDto model)
        {
            if (!ModelState.IsValid)
            {
                TempData["PasswordChangeResult"] = "Invalid input data.";
                return RedirectToAction(nameof(Index));
            }

            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
            {
                TempData["PasswordChangeResult"] = "User not found.";
                return RedirectToAction(nameof(Index));
            }

            var result = await _accountServices.ChangePassword(model, userId);
            TempData["PasswordChangeResult"] = result;

            return RedirectToAction(nameof(Index));
        }
    }
}