using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using MultiShop.IdentityServer.Dtos;
using MultiShop.IdentityServer.Models;
using MultiShop.IdentityServer.Services.Authentication;
using MultiShop.IdentityServer.Services.Authentication.Models;

using System.Linq;
using System.Threading.Tasks;

namespace MultiShop.IdentityServer.Controllers
{
	[AllowAnonymous]
    [Route("[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

		public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
		{
			_userManager = userManager;
			_signInManager = signInManager;
		}

		[HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterDto request)
        {
            var user = new User()
            {
                UserName = request.UserName,
                Name = request.Name,
                Surname = request.Surname,
                Email = request.Email,
            };

            var registerResult = await _userManager.CreateAsync(user, request.Password);
            if (registerResult.Succeeded)
                return Ok(request);
            else
                return BadRequest(registerResult.Errors);
        }

		[HttpPost("login")]
		public async Task<IActionResult> Login(UserLoginDto request)
		{

            var signInResult = await _signInManager.PasswordSignInAsync
                (
                request.UserName, 
                request.Password, 
                isPersistent: false, 
                lockoutOnFailure: false
                );

            if (signInResult.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(request.UserName);
                var role = (await _userManager.GetRolesAsync(user)).FirstOrDefault();

                var checkUserResultViewModel = new CheckUserResultViewModel
                {
                    Id = user.Id,
                    Role = role,
                    UserName = request.UserName
                };

                var token = JwtTokenGenerator.GenerateToken(checkUserResultViewModel);
				return Ok(token);
			}
            else
                return BadRequest();
		}
	}
}
