using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NurseryGardenApp.Data.Models;

namespace NurseryGardenApp.Data.Data.Configuration
{
	public class OrderConfiguration : IEntityTypeConfiguration<Order>
	{
		public void Configure(EntityTypeBuilder<Order> builder)
		{
			builder.Property(p => p.Price)
				   .HasColumnType("decimal")
				   .HasPrecision(18, 2);
		}
	}
}
