using Microsoft.AspNetCore.Mvc;

using MultiShop.WebUI.Dtos.Cargo;
using MultiShop.WebUI.Services.Authentication.Services.Abstract;
using MultiShop.WebUI.Services.ExternalApiServices.Cargo.Abstract;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly ICargoCustomerService _cargoCustomerService;

        public UserController(IUserService userService, ICargoCustomerService cargoCustomerService)
        {
            _userService = userService;
            _cargoCustomerService = cargoCustomerService;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _userService.GetAll();
            return View(users);
        }

        [HttpGet("/admin/user/address/{userId}")]
        public async Task<IActionResult> GetAddressDetailByUserId(string userId)
        {
            var cargoCustomer = await _cargoCustomerService.GetByUserIdAsync(userId);
            var userDetail = await _userService.GetById(userId);
            return View(new ResultCargoCustomerWithUserDetailDto
            {
                CargoCustomer = cargoCustomer,
                UserDetail = userDetail
            });
        }
    }
}
