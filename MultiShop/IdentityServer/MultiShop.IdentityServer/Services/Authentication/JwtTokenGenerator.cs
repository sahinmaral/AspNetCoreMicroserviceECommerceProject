using Microsoft.IdentityModel.Tokens;

using MultiShop.IdentityServer.Services.Authentication.Models;

using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MultiShop.IdentityServer.Services.Authentication
{
	public class JwtTokenGenerator
	{
		public static TokenResponseViewModel GenerateToken(CheckUserResultViewModel model)
		{
			var claims = new List<Claim>();
			if (!string.IsNullOrWhiteSpace(model.Role))
				claims.Add(new Claim(ClaimTypes.Role, model.Role));

			claims.Add(new Claim(ClaimTypes.NameIdentifier, model.Id));

			if (!string.IsNullOrWhiteSpace(model.UserName))
				claims.Add(new Claim("Username", model.UserName));

			claims.Add(new Claim(ClaimTypes.NameIdentifier, model.Id));

			var symmetricKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenDefaults.Key));
			var signingCredentials = new SigningCredentials(symmetricKey, SecurityAlgorithms.HmacSha512);
			var expiredAt = DateTime.Now.AddHours(JwtTokenDefaults.Expire);
			JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
				issuer: JwtTokenDefaults.ValidIssuer,
				audience: JwtTokenDefaults.ValidAudience,
				claims: claims,
				notBefore: DateTime.UtcNow,
				expires:expiredAt,
				signingCredentials: signingCredentials
				);

			JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
			return new TokenResponseViewModel
			{
				Token = jwtSecurityTokenHandler.WriteToken(jwtSecurityToken),
				ExpiredAt = expiredAt
			};
		}
	}
}
