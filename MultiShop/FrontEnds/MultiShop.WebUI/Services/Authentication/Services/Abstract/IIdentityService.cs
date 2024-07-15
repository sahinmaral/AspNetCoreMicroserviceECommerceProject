using MultiShop.WebUI.Dtos.Auth;
using MultiShop.WebUI.Models;

namespace MultiShop.WebUI.Services.Authentication.Services.Abstract
{
    public interface IIdentityService
    {
        public string CurrentUserId { get; }
        public Task<bool> Login(UserLoginDto dto);
        public Task<bool> GetRefreshToken();
    }
}
