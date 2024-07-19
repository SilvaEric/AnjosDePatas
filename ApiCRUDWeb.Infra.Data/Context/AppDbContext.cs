using ApiCRUDWeb.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiCRUDWeb.Infra.Data.Context
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions options) : base(options) { }
		public DbSet<Adress> Adress { get; set; }
		public DbSet<Pet> Pets { get; set; }
		public DbSet<PetDetails> PetsDetails { get; set; }
        public DbSet<User> Users { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
			builder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
		}
	}
}
