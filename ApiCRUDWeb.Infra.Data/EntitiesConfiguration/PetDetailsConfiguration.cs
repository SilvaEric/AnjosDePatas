
using ApiCRUDWeb.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiCRUDWeb.Infra.Data.EntitiesConfiguration
{
	public class PetDetailsConfiguration : IEntityTypeConfiguration<PetDetails>
	{
		public void Configure(EntityTypeBuilder<PetDetails> builder)
		{
			builder.HasKey(x => x.Id);
			builder.Property(x => x.PetId).IsRequired();
			builder.Property(x => x.PredominantColor).HasMaxLength(30).IsRequired();
			builder.Property(x => x.NonPredominantColor).HasMaxLength(100).IsRequired();
			builder.Property(x => x.Heigth).IsRequired();
			builder.Property(x => x.Fur).HasMaxLength(20).IsRequired();
			builder.Property(x => x.EyesColor).HasMaxLength(20).IsRequired();
			builder.Property(x => x.TongueColor).HasMaxLength(20).IsRequired();
		}
	}
}
