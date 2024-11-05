using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NurseryGardenApp.Data.Models;

namespace NurseryGardenApp.Data.Data.Configuration
{
	public class CategoryConfiguration : IEntityTypeConfiguration<Category>
	{
		public void Configure(EntityTypeBuilder<Category> builder)
		{
			builder.HasData(this.SeedCategories());
		}

		private  IEnumerable<Category> SeedCategories()
		{
			IEnumerable<Category> categories = new List<Category>
			{
				new Category
				{
					Id = 1,
					Name = "Trees"
				},
				new Category
				{
					Id = 2,
					Name = "Bushes"
				},
				new Category
				{
					Id = 3,
					Name = "Flowers"
				},
				new Category
				{
					Id = 4,
					Name = "Seedlings"
				},
				new Category
				{
					Id = 5,
					Name = "Garden"
				}
				,
				new Category
				{
					Id = 6,
					Name = "Evergreens"
				}
			};

			return categories;
		}
			
			
	}
}
