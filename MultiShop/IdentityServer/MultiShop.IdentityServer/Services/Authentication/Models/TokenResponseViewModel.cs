using System;

namespace MultiShop.IdentityServer.Services.Authentication.Models
{
	public class TokenResponseViewModel
	{
        public string Token { get; set; }
        public DateTime ExpiredAt { get; set; }
    }
}
