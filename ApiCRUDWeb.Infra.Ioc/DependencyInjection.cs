﻿using ApiCRUDWeb.Infra.Data.Repositories;
using ApiCRUDWeb.Domain.Interfaces;
using ApiCRUDWeb.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ApiCRUDWeb.Aplication.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using ApiCRUDWeb.Domain.Configuration;
using System.Text;
using ApiCRUDWeb.Domain.Entities;
using ApiCRUDWeb.Aplication.Services;
using ApiCRUDWeb.Aplication.Mappings;

namespace ApiCRUDWeb.Infra.Ioc
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddInfrastructure(this IServiceCollection services)
		{
			services.AddDbContext<AppDbContext>(options =>
			options.UseNpgsql("Host=dpg-cqau1mmehbks73df8a30-a.oregon-postgres.render.com;Port=5432;Database=postgreesqlteste;Username=postgreesqlteste_user;Password=HeWlIHgHB3oDRWHHxbDi8H4BcFs0VDcJ;SSL Mode=Require",
				b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName))
			);
			//options.UseNpgsql(Environment.GetEnvironmentVariable("PostgresSql")););

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

			services.AddScoped<IPetDetailsRepository, PetDetailsRepository>();
			services.AddScoped<IPetRepository, PetRepository>();
			services.AddScoped<IUserRepository, UserRepository>();

			services.AddScoped<IUserMapper, UserMapper>();
			services.AddScoped<IPetMapper, PetMapper>();
			services.AddScoped<IPetDetailsMapper, PetDetailsMapper>();


			services.AddScoped<IPetService, PetService>();
			services.AddScoped<IPetDetailsService, PetDetailsService>();
			services.AddScoped<IUserService, UserService>();
			services.AddTransient<ITokenService, TokenService>();


			return services;
		}
	}
}
