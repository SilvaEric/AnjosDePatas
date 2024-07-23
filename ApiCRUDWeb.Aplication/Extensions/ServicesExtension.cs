using ApiCRUDWeb.Aplication.Configuration;
using System.Text;
using ApiCRUDWeb.Aplication.Interfaces;
using ApiCRUDWeb.Aplication.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace ApiCRUDWeb.Aplication.Extensions
{
	public static class ServicesExtension
	{
		public static IServiceCollection AddAplicationServices(this IServiceCollection services)
		{
			services.AddScoped<IPetService, PetService>();
			services.AddScoped<IPetDetailsService, PetDetailsService>();
			services.AddScoped<IUserService, UserService>();
			services.AddScoped<IAdressService, AdressService>();
			services.AddTransient<ITokenService, TokenService>();

			var key = Encoding.ASCII.GetBytes(Settings.PrivateKey);
			services.AddAuthentication(x =>
			{
				x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			}).AddJwtBearer(x =>
			{
				x.RequireHttpsMetadata = false;
				x.SaveToken = true;
				x.TokenValidationParameters = new TokenValidationParameters
				{
					ValidateIssuerSigningKey = true,
					IssuerSigningKey = new SymmetricSecurityKey(key),
					ValidateIssuer = false,
					ValidateAudience = false
				};
			});
			services.AddAuthorization();

			return services;
		}
	}
}
