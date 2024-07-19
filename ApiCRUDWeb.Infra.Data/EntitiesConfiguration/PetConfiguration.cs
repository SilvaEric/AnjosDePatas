using ApiCRUDWeb.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiCRUDWeb.Infra.Data.EntitiesConfiguration
{
	public class PetConfiguration : IEntityTypeConfiguration<Pet>
	{
		public void Configure(EntityTypeBuilder<Pet> builder)
		{
			builder.HasKey(x => x.PetId);
			builder.Property(x => x.UserId).IsRequired();
			builder.Property(x => x.PetName).HasMaxLength(100).IsRequired();
			builder.Property(x => x.DateOfBirh).IsRequired();
			builder.Property(x => x.Breed).HasMaxLength(50).IsRequired();

			builder.HasOne(x => x.Tutor).WithMany(x => x.Pets)
				.HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.NoAction);

			builder.HasOne(x => x.Details).WithOne(x => x.Pet)
				.HasForeignKey<PetDetails>(x => x.PetId).OnDelete(DeleteBehavior.Cascade);
		}
	}
}
