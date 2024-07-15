using Microsoft.AspNetCore.Mvc;

using MultiShop.WebUI.Dtos.Auth;
using MultiShop.WebUI.Services.Authentication.Services.Abstract;
using MultiShop.WebUI.Services.ExternalApiServices.Identity;

namespace MultiShop.WebUI.Controllers
{
    public class AuthController : Controller
    {
		private readonly IIdentityService _identityService;
        private readonly IIdentityApi _identityApi;
		public AuthController(IIdentityApi identityApi, IIdentityService identityService)
		{
			_identityApi = identityApi;
            _identityService = identityService;
		}

		[HttpGet]
        public IActionResult Register()
        {
            return View();
        }

		[HttpPost]
		public async Task<IActionResult> Register(UserRegisterDto dto)
		{
			try
			{
				if (dto.Password != dto.ConfirmPassword)
				{
					ModelState.AddModelError("ConfirmPassword", "Şifre tekrarı ve şifre aynı olmalıdır");
					return View(dto);
				}

				await _identityApi.Register(dto);
				return RedirectToAction(nameof(Login));
			}
			catch (Exception ex)
			{
				ModelState.AddModelError(string.Empty, $"Kayıt olurken hata oluştu: {ex.Message}");
				return View(dto);
			}
		}

		[HttpGet]
        public IActionResult Login()
        {
            return View();
		}
	
		[HttpPost]
		public async Task<IActionResult> Login(UserLoginDto dto)
		{
			await _identityService.Login(dto);
			return RedirectToAction("Index","User");
		}
	}
}
