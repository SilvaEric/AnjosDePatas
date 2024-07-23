using ApiCRUDWeb.Domain.Interfaces;
using ApiCRUDWeb.Infra.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace ApiCRUDWeb.Infra.Data.Extensions
{
	public static class InfraDataExtension
	{
		public static IServiceCollection AddInfrastructureData(this IServiceCollection services)
		{
			services.AddScoped<IPetDetailsRepository, PetDetailsRepository>();
			services.AddScoped<IPetRepository, PetRepository>();
			services.AddScoped<IUserRepository, UserRepository>();
			services.AddScoped<IAdressRepository, AdressRepository>();

			return services;
		}
	}
}
