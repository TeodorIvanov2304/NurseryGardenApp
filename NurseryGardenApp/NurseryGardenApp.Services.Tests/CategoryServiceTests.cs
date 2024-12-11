using Moq;
using NUnit.Framework;
using NurseryGardenApp.Data.Data.Models;
using NurseryGardenApp.Data.Data.Repositories.Interfaces;
using NurseryGardenApp.Data.Models;
using NurseryGardenApp.Services.Data;
using NurseryGardenApp.ViewModels.Category;

namespace NurseryGardenApp.Services.Tests
{
	[TestFixture]
	public class CategoryTests
	{
		private IEnumerable<Product> productData = new List<Product>
		{
			new Product()
			{
				Id = Guid.Parse("5C980CFC-F7A3-4CBF-B0EC-0A4CFB8EC2E6"),
				Name = "Caladium",
				Description =
					"Caladium is a genus of flowering plants in the family Araceae. They are often known by the common name elephant ear, heart of Jesus, and angel wings. There are over 1000 named cultivars of Caladium bicolor from the original South American plant.",
				Price = 19.99m,
				ImageUrl =
					"https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT0QPwVok7a2LrGmV8OCaru14knQcfXlemOBFJcqX-yfqqtYbICGer8UJqyOY7R6Xb7XJF9U8w2WHDYOvBzIDtUZQ",
				Quantity = 10,
				IsDeleted = false,
				DiscountId = 1
			},
			new Product
			{
				Id = Guid.Parse("07A0819A-6FE9-4454-8322-794F80B17753"),
				Name = "Dracaena marginata",
				Description =
					"Dracaena marginata, also known as the Madagascar Dragon Tree, is a popular and striking plant that's native to Madagascar, Mauritius, and other islands in the Indian Ocean. This plant belongs to the Asparagaceae family and features long, thin, and pointed leaves that are often edged in red or pink.",
				Price = 20.00m,
				ImageUrl =
					"https://www.thespruce.com/thmb/xIs5C_juOFJ7ETNCO5wZJesYgLQ=/750x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/grow-dracaena-marginata-indoors-1902749-2-983c52a2805144d899408949969a5728.jpg",
				Quantity = 10,
				CategoryId = 8,
			},
		}.AsQueryable();

		IEnumerable<Discount> discountsData = new List<Discount>()
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
		}.AsQueryable();

		IEnumerable<Category> categoriesData = new List<Category>
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
		}.AsQueryable();

		private Mock<IRepository<Product, Guid>> _productRepository;
		private Mock<IRepository<Category, int>> _categoriesRepository;
		private Mock<IRepository<Discount, int>> _discountRepository;
		private Mock<IRepository<Class, int>> _classRespotory;



		[SetUp]
		public void Setup()
		{
			this._productRepository = new Mock<IRepository<Product, Guid>>();
			this._categoriesRepository = new Mock<IRepository<Category, int>>();
			this._discountRepository = new Mock<IRepository<Discount, int>>();

		}

		
	}
}