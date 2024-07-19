using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiCRUDWeb.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiCRUDWeb.Infra.Data.EntitiesConfiguration
{
	public class AdressConfiguration : IEntityTypeConfiguration<Adress>
	{
		public void Configure(EntityTypeBuilder<Adress> builder)
		{
			builder.HasKey(x => x.AdressId);
			builder.Property(x => x.Country).HasMaxLength(80).IsRequired();
			builder.Property(x => x.State).HasMaxLength(80).IsRequired();
			builder.Property(x => x.City).HasMaxLength(80).IsRequired();
			builder.Property(x => x.Neighborhood).HasMaxLength(80).IsRequired();
			builder.Property(x => x.PublicPlace).HasMaxLength(100).IsRequired();
			builder.Property(x => x.Complement).HasMaxLength(50).IsRequired();
		}
	}
}
