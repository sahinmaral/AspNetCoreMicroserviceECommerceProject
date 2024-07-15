using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.Authentication.Services.Abstract;

namespace MultiShop.WebUI.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            var currentUserInfo = await _userService.GetUserInfo();
            return View(currentUserInfo);
        }
    }
}
