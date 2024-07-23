using ApiCRUDWeb.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ApiCRUDWeb.Aplication.Extensions;
using ApiCRUDWeb.Infra.Data.Extensions;

namespace ApiCRUDWeb.Infra.Ioc
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddInfrastructure(this IServiceCollection services)
		{
			services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(Environment.GetEnvironmentVariable("PostgresSql"),
                b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName))
			);

			services.AddInfrastructureData();

			services.AddAplicationMappings();
			services.AddAplicationServices();


			return services;
		}
	}
}
