using MultiShop.WebUI.Dtos.Auth;
using Refit;

namespace MultiShop.WebUI.Services.ExternalApiServices.Identity
{
    public interface IIdentityApi
    {
        [Post("/account/login")]
        Task<TokenResponseModel> Login(UserLoginDto dto);
        [Post("/account/register")]
        Task Register(UserRegisterDto dto);
    }
}
