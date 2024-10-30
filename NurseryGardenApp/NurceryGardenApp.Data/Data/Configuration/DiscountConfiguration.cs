using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NurseryGardenApp.Data.Data.Models;

namespace NurseryGardenApp.Data.Data.Configuration
{
	public class DiscountConfiguration : IEntityTypeConfiguration<Discount>
	{
		public void Configure(EntityTypeBuilder<Discount> builder)
		{
			builder.Property(p => p.DiscountValue)
				   .HasColumnType("decimal")
				   .HasPrecision(18, 2);
		}
	}
}
