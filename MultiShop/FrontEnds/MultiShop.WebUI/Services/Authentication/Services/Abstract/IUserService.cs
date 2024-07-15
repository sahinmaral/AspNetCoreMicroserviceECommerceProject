using MultiShop.WebUI.Models;

namespace MultiShop.WebUI.Services.Authentication.Services.Abstract
{
    public interface IUserService
    {
        Task<UserDetailViewModel?> GetUserInfo();
    }
}
