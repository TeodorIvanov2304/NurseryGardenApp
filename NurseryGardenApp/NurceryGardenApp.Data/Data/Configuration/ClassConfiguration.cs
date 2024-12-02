using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NurseryGardenApp.Data.Models;

namespace NurseryGardenApp.Data.Data.Configuration
{
	public class ClassConfiguration : IEntityTypeConfiguration<Class>
	{
		public void Configure(EntityTypeBuilder<Class> builder)
		{
			builder.HasData(this.SeedClasses());
		}

		private IEnumerable<Class> SeedClasses()
		{	
			IEnumerable<Class> classes = new List<Class>()
			{
				new Class()
			{
				//Широколистни
				Id = 1,
				Name = "Deciduous"
			},

			new Class()
			{	
				//Иглолистни
				Id = 2,
				Name = "Coniferous"
			},

			new Class()
			{   
				Id = 3,
				Name = "Fruity"
			},

			new Class()
			{	
				Id = 4,
				Name = "Garden Flowers"
			},

			new Class()
			{
				Id = 5,
				Name = "Indoor Flowers"
			},

			new Class()
			{
				Id = 6,
				Name = "Seeds"
			}

			};

			return classes;
		}
	}
}
