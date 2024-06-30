using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using MultiShop.IdentityServer.Dtos;
using MultiShop.IdentityServer.Models;

using System.Threading.Tasks;

using static IdentityServer4.IdentityServerConstants;

namespace MultiShop.IdentityServer.Controllers
{
    [Authorize(LocalApi.PolicyName)]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> _userManager;

        public AccountController(UserManager<User> userManager)
        {
            _userManager = userManager;
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
                return BadRequest();
        }
    }
}
