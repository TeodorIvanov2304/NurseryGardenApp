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
					Name = "Trees",
					IsDeleted = false,
					ClassId = 1
				},
				new Category
				{
					Id = 2,
					Name = "Bushes",
					IsDeleted = false,
					ClassId = 2
				},
				new Category
				{
					Id = 3,
					Name = "Flowers",
					IsDeleted = false,
					ClassId = 4
				},
				new Category
				{
					Id = 4,
					Name = "Seedlings",
					IsDeleted = false,
					ClassId = 6
				},
				new Category
				{
					Id = 5,
					Name = "Garden",
					IsDeleted = false
				}
				,
				new Category
				{
					Id = 6,
					Name = "Evergreens",
					IsDeleted = false
				},
				new Category
				{
					Id = 7,
					Name = "Trees",
					IsDeleted = false,
					ClassId = 2
				},
				new Category
				{
					Id = 8,
					Name = "Flowers",
					IsDeleted = false,
					ClassId = 5
				}
			};

			return categories;
		}
			
			
	}
}
