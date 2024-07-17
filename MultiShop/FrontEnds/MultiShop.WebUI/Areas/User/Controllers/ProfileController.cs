using Microsoft.AspNetCore.Mvc;

using MultiShop.WebUI.Services.Authentication.Services.Abstract;

namespace MultiShop.WebUI.Areas.User.Controllers
{
    [Area("User")]
    public class ProfileController : Controller
    {
        private readonly IUserService _userService;

        public ProfileController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("/user/my-profile")]
        public async Task<IActionResult> Index()
        {
            var currentUserInfo = await _userService.GetUserInfo();
            return View(currentUserInfo);
        }
    }
}
