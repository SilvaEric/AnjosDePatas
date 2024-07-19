using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace ApiCRUDWeb.Infra.Ioc
{
	public static class DependencyInjectionSwagger
	{
		public static IServiceCollection AddInfrastructureSwagger(this IServiceCollection services)
		{
			services.AddSwaggerGen(c =>
			{
				c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
				{
					Name = "Authorization",
					Type = SecuritySchemeType.ApiKey,
					BearerFormat = "JWT",
					In = ParameterLocation.Header,
					Description = "Token de authenticação para acesso a endpoints protegidos. JSON Web Token (JWT)"
				});

				c.AddSecurityRequirement(new OpenApiSecurityRequirement()
				{
					{ 
						new OpenApiSecurityScheme()
						{
							Reference = new OpenApiReference()
							{
								Type = ReferenceType.SecurityScheme,
								Id = "Bearer"
							}
						},
						new string [] {}
					}
				});
			});
			return services;
		}
	}
}
