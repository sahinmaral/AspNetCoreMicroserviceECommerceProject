using Microsoft.AspNetCore.Mvc;

using MultiShop.WebUI.Services.Authentication.Services.Abstract;

namespace MultiShop.WebUI.ViewComponents
{
    public class UserLayoutNavbarViewComponent : ViewComponent
    {
        private readonly IUserService _userService;

        public UserLayoutNavbarViewComponent(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var currentUserInfo = await _userService.GetUserInfo();
            return View(currentUserInfo);
        }
    }
}
