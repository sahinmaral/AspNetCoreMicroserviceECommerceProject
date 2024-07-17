using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using MultiShop.IdentityServer.Models;

using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

using static IdentityServer4.IdentityServerConstants;

namespace MultiShop.IdentityServer.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<User> _userManager;

        public UsersController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        [Authorize(LocalApi.PolicyName)]
        [HttpGet("getuser")]
        public async Task<IActionResult> GetUserInfoAsync()
        {
            var userClaim = User.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Sub);
            var user = await _userManager.FindByIdAsync(userClaim.Value);
            return Ok(new
            {
                Id = user.Id,
                Name = user.Name,
                Surname = user.Surname,
                UserName = user.UserName,
                Email = user.Email
            });
        }

        [Authorize(LocalApi.PolicyName)]
        [HttpGet("getusers")]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userManager.Users.ToListAsync();
            var mappedUsers = users.Select((user) => new
            {
                Id = user.Id,
                Name = user.Name,
                Surname = user.Surname,
                UserName = user.UserName,
                Email = user.Email
            });
            return Ok(mappedUsers);
        }

        [HttpGet("detail/{userId}")]
        public async Task<IActionResult> GetById(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            return Ok(new
            {
                Id = user.Id,
                Name = user.Name,
                Surname = user.Surname,
                UserName = user.UserName,
                Email = user.Email
            });
        }

        [HttpGet("count")]
        public async Task<IActionResult> CountOfUser()
        {
            var count = await _userManager.Users.CountAsync();
            return Ok(count);
        }
    }
}
