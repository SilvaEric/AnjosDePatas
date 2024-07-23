using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ApiCRUDWeb.Aplication.Configuration;
using ApiCRUDWeb.Aplication.Interfaces;
using ApiCRUDWeb.Domain.Entities;
using Microsoft.IdentityModel.Tokens;

namespace ApiCRUDWeb.Aplication.Services
{
	internal class TokenService : ITokenService
	{
		public string GenerateToken(User user)
		{
			var handler = new JwtSecurityTokenHandler();
			var key = Encoding.ASCII.GetBytes(Settings.PrivateKey);
			var credentials = new SigningCredentials(
			new SymmetricSecurityKey(key),
			SecurityAlgorithms.HmacSha256Signature);

			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(new[]
				{
					new Claim(ClaimTypes.Name, user.UserId.ToString()),
					new Claim(ClaimTypes.Role, user.Role)
				}),
				Expires = DateTime.UtcNow.AddHours(4),
				SigningCredentials = credentials,
			};
			var token = handler.CreateToken(tokenDescriptor);
			return handler.WriteToken(token);
		}
	}
}
