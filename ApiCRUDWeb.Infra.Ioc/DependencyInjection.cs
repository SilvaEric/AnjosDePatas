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
				//options.UseNpgsql(Environment.GetEnvironmentVariable("PostgresSql"),
				options.UseNpgsql("Server=dpg-cqau1mmehbks73df8a30-a.oregon-postgres.render.com;Port=5432;Database=postgreesqlteste;Userid=postgreesqlteste_user;Password=HeWlIHgHB3oDRWHHxbDi8H4BcFs0VDcJ; SSL Mode = Require ;",
				b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName))
			);

			services.AddInfrastructureData();

			services.AddAplicationMappings();
			services.AddAplicationServices();


			return services;
		}
	}
}
