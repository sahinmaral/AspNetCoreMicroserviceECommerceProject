using MultiShop.Basket.Services.Abstract;

using System.Security.Claims;

namespace MultiShop.Basket.Services.Concrete
{
    public class LoginService : ILoginService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LoginService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string CurrentUserId => _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
    }
}
