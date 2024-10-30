using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NurseryGardenApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurseryGardenApp.Data.Data.Configuration
{
	public class ProductConfiguration : IEntityTypeConfiguration<Product>
	{
		public void Configure(EntityTypeBuilder<Product> builder)
		{
			//Price precision

			//builder.Entity<Product>()
		 //  .Property(p => p.Price)
		 //  .HasColumnType("decimal")
		 //  .HasPrecision(18, 2);

			builder.Property(p => p.Price)
				   .HasColumnType("decimal")
				   .HasPrecision(18, 2);
		}
	}
}
