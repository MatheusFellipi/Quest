using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Quest.Entities;

namespace Quest.Services
{
	public class TokenServices
	{
		public static string GenerateToken(User user)
		{
			var tokenHandle = new JwtSecurityTokenHandler();
			var key = Encoding.ASCII.GetBytes(Settings.Secret);
			var tokenDescription = new SecurityTokenDescriptor
			{
				 Subject = new ClaimsIdentity(new Claim[] { 
					new Claim(ClaimTypes.Email,user.Email.ToString()),
					new Claim(ClaimTypes.Role,user.Role.ToString())
				 }),
				 Expires = DateTime.UtcNow.AddHours(2),
				 SigningCredentials =
				 new SigningCredentials(new SymmetricSecurityKey(key),SecurityAlgorithms.HmacSha256Signature)
			};
			var token = tokenHandle.CreateToken(tokenDescription);

			return tokenHandle.WriteToken(token);
		}
	}
}
