using Microsoft.AspNetCore.Identity;

namespace MultiShop.IdentityServer.Models
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
