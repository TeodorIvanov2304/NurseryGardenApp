using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NurseryGardenApp.Data.Models;

namespace NurseryGardenApp.Data.Data.Configuration
{
	public class ProductConfiguration : IEntityTypeConfiguration<Product>
	{
		public void Configure(EntityTypeBuilder<Product> builder)
		{

			builder.Property(p => p.Price)
				   .HasColumnType("decimal")
				   .HasPrecision(18, 2);

			builder.HasData(this.SeedProducts());

		}

		private IEnumerable<Product> SeedProducts()
		{
			IEnumerable<Product> products = new List<Product>()
			{
				new Product
				{
					Id = Guid.NewGuid(),
					Name = "Dracaena marginata",
					Description = "Dracaena marginata, also known as the Madagascar Dragon Tree, is a popular and striking plant that's native to Madagascar, Mauritius, and other islands in the Indian Ocean. This plant belongs to the Asparagaceae family and features long, thin, and pointed leaves that are often edged in red or pink.",
					Price = 20.00m,
					ImageUrl = "https://www.thespruce.com/thmb/xIs5C_juOFJ7ETNCO5wZJesYgLQ=/750x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/grow-dracaena-marginata-indoors-1902749-2-983c52a2805144d899408949969a5728.jpg",
					Quantity = 10,
					CategoryId = 8,
				},
				new Product
				{
					Id = Guid.NewGuid(),
					Name = "Hoya",
					Description = "Native to Southeast Asia, the Hoya Kerrii Variegata is a succulent-like vine that grows slowly but can eventually produce long tendrils with clusters of star-shaped, fragrant flowers under optimal conditions.",
					Price = 5.00m,
					ImageUrl = "https://www.happysunrize.com/cdn/shop/products/image_2626eda1-facb-413e-91b4-1ea441e7e028_1024x1024@2x.heic?v=1662041725",
					Quantity = 20,
					CategoryId = 8
				},
				new Product
				{
					Id = Guid.NewGuid(),
					Name = "Periwinkle",
					Description = "Periwinkle (Vinca minor) is an excellent evergreen groundcover with dark green foliage. Oblong to ovate leaves are opposite, simple, ½ to 2 inches long, glossy, with a short petiole. They exude a milky juice when broken. Flowers are purple, blue or white depending on the cultivar.",
					Price = 2.00m,
					ImageUrl = "https://s3.amazonaws.com/eit-planttoolbox-prod/media/images/Catharanthus_roseus__oHpudZ0x1u7F.jpeg",
					Quantity = 1000,
					CategoryId = 3
				},
				new Product
				{
					Id = Guid.NewGuid(),
					Name = "English oak",
					Description = "A large, deciduous tree growing up to 20–40m tall. Also known as common oak, this species grows and matures to form a broad and spreading crown with sturdy branches beneath. Look out for: its distinctive round-lobed leaves with short leaf stalks (petioles). Identified in winter by: rounded buds in clusters.",
					Price = 25.00m,
					ImageUrl = "https://s3.amazonaws.com/eit-planttoolbox-prod/media/images/Quercus_robur_form_P_UnT1nhYxVeT2.jpe",
					Quantity = 5,
					CategoryId = 1
				},
				new Product
				{
					Id = Guid.NewGuid(),
					Name = "Oriental Plane",
					Description = "Platanus orientalis, commonly called oriental plane tree or oriental sycamore, is a deciduous, usually single-trunk tree with distinctive, flaky, brown-gray-cream bark, large maple-like leaves and spherical fruiting balls that persist into winter.",
					Price = 25.00m,
					ImageUrl  = "https://uzbbg.uz/storage/Picturel1.png",
					Quantity = 10,
					CategoryId = 1,
					DiscountId = 1
				},
				new Product
				{
					Id = Guid.NewGuid(),
					Name = "Arborvitae",
					Description = "Thuja occidentalis, also known as northern white-cedar, eastern white-cedar, or arborvitae, is an evergreen coniferous tree, in the cypress family Cupressaceae, which is native to eastern Canada and much of the north-central and northeastern United States. It is widely cultivated as an ornamental plant.",
					Price = 5.00m,
					ImageUrl = "https://s3.amazonaws.com/eit-planttoolbox-prod/media/images/Thuja_occidentalis_L_0aoh6YZf2tc7.jpg",
					Quantity = 100,
					CategoryId = 2,
					DiscountId = 1
				}
			};

			return products;
		}
	}
}
