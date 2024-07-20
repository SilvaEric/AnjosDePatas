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
	internal class UserConfiguration : IEntityTypeConfiguration<User>
	{
		public void Configure(EntityTypeBuilder<User> builder)
		{
			builder.HasKey(x => x.UserId);
			builder.Property(x => x.UserName).HasMaxLength(200).IsRequired();
			builder.Property(x => x.PasswordHash).IsRequired();
            builder.Property(x => x.PasswordSalt).IsRequired();
            builder.Property(x => x.UserDateOfBirth).IsRequired();
			builder.Property(x => x.PhoneNumber).HasMaxLength(50).IsRequired();
			builder.Property(x => x.Role).HasMaxLength(10).IsRequired();
			builder.Property(x => x.InsertionDate).IsRequired();

			builder.HasOne(x => x.Adress).WithOne(x => x.User)
				.HasForeignKey<Adress>(x => x.UserId).OnDelete(DeleteBehavior.Cascade);

		}
	}
}
