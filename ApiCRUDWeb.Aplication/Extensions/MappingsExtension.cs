using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiCRUDWeb.Aplication.Interfaces;
using ApiCRUDWeb.Aplication.Mappings;
using Microsoft.Extensions.DependencyInjection;

namespace ApiCRUDWeb.Aplication.Extensions
{
	public static class MappingsExtension
	{
		public static IServiceCollection AddAplicationMappings(this IServiceCollection services)
		{
			services.AddScoped<IUserMapper, UserMapper>();
			services.AddScoped<IPetMapper, PetMapper>();
			services.AddScoped<IPetDetailsMapper, PetDetailsMapper>();
			services.AddScoped<IAdressMapper, AdressMapper>();

			return services;
		}	
	}
}
