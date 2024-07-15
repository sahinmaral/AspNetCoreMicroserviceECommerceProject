using Microsoft.AspNetCore.Mvc;

using MultiShop.WebUI.Models;
using MultiShop.WebUI.Services.Authentication.Services.Abstract;

namespace MultiShop.WebUI.ViewComponents
{
    public class LayoutTopbarUserInfoViewComponent: ViewComponent
    {
        private readonly IUserService _userService;

        public LayoutTopbarUserInfoViewComponent(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            try
            {
                var currentUserInfo = await _userService.GetUserInfo();
                return View(currentUserInfo);
            }
            catch (Exception)
            {
                return View(new UserDetailViewModel());
            }
        }
    }
}
