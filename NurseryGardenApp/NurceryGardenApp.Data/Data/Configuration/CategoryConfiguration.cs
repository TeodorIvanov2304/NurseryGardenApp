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

		//Възможна грешка? Трябва ли да се сложи ClassId, и въобще така ли трябва да е връзката?
		private  IEnumerable<Category> SeedCategories()
		{
			IEnumerable<Category> categories = new List<Category>
			{
				new Category
				{
					Id = 1,
					Name = "Trees",
					ClassId = 1
				},
				new Category
				{
					Id = 2,
					Name = "Bushes",
					ClassId = 2
				},
				new Category
				{
					Id = 3,
					Name = "Flowers",
					ClassId = 4
				},
				new Category
				{
					Id = 4,
					Name = "Seedlings",
					ClassId = 6
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
				},
				new Category
				{
					Id = 7,
					Name = "Trees",
					ClassId = 2
				},
				new Category
				{
					Id = 8,
					Name = "Flowers",
					ClassId = 5
				}
			};

			return categories;
		}
			
			
	}
}
