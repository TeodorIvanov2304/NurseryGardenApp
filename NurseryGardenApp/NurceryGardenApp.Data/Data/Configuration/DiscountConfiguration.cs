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

			builder.HasData(this.SeedDiscounts());
		}

		private IEnumerable<Discount> SeedDiscounts()
		{
			IEnumerable<Discount> discounts = new List<Discount>()
			{
				new Discount()
				{
					Id = 1,
					Name = "25 percent discount",
					DiscountValue = 25.00m,
					StartDate = DateTime.Today,
					EndDate = DateTime.Today.AddYears(1)
				},
				new Discount()
				{
					Id = 2,
					Name = "10 percent discount",
					DiscountValue = 10.00m,
					StartDate = DateTime.Today,
					EndDate = DateTime.Today.AddYears(1)
				}
			};

			return discounts;
		}
	}
}
