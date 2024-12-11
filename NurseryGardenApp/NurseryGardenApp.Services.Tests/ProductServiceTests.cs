using MockQueryable;
using Moq;
using NurseryGardenApp.Data.Data.Models;
using NurseryGardenApp.Data.Data.Repositories.Interfaces;
using NurseryGardenApp.Data.Models;
using NurseryGardenApp.Services.Data;

namespace NurseryGardenApp.Services.Tests
{
	[TestFixture]
	public class ProductTests
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



		[SetUp]
		public void Setup()
		{
			this._productRepository = new Mock<IRepository<Product, Guid>>();
			this._categoriesRepository = new Mock<IRepository<Category, int>>();
			this._discountRepository = new Mock<IRepository<Discount, int>>();

		}

		[Test]
		public async Task GetAllProductsAsync_ShouldReturnCorrectData()
		{

			var productsMock = this.productData.AsQueryable().BuildMock();
			_productRepository.Setup(r => r.GetAllAttached()).Returns(productsMock);

			var categoriesMock = this.categoriesData.AsQueryable().BuildMock();
			_categoriesRepository.Setup(r => r.GetAllAttached()).Returns(categoriesMock);

			var discountsMock = this.discountsData.AsQueryable().BuildMock();
			_discountRepository.Setup(r => r.GetAllAsync()).ReturnsAsync(this.discountsData);

			var productService = new ProductService(_productRepository.Object, _categoriesRepository.Object, _discountRepository.Object);

			var result = await productService.GetAllProductsAsync();

			Assert.That(result, Is.Not.Null);
			Assert.That(result.Products.Count(), Is.EqualTo(this.productData.Count()));
			Assert.That(result.Categories.Count(), Is.EqualTo(this.categoriesData.Count()));
			Assert.That(result.Discounts.Count(), Is.EqualTo(this.discountsData.Count()));
		}

		[Test]
		public async Task GetProductDetailsByIdAsync_ShouldReturnCorrectData_WhenProductExists()
		{

			var productId = Guid.NewGuid();
			var mockProduct = new Product
			{
				Id = productId,
				Name = "Caladium",
				Description = "A beautiful ornamental plant",
				Price = 19.99m,
				ImageUrl = "https://example.com/image.jpg",
				IsDeleted = false,
				Category = new Category { Name = "Plants" },
				Discount = new Discount { Name = "10% Off" }
			};


			_productRepository.Setup(r => r.GetAllAttached())
				.Returns(new[] { mockProduct }.AsQueryable().BuildMock());

			var productService = new ProductService(
				_productRepository.Object,
				_categoriesRepository.Object,
				_discountRepository.Object
			);

			var result = await productService.GetProductDetailsByIdAsync(productId);

			Assert.That(result, Is.Not.Null);
			Assert.That(result?.ProductName, Is.EqualTo("Caladium"));
			Assert.That(result?.Description, Is.EqualTo("A beautiful ornamental plant"));
			Assert.That(result?.Price, Is.EqualTo(19.99m));
			Assert.That(result?.ImageURL, Is.EqualTo("https://example.com/image.jpg"));
			Assert.That(result?.CategoryName, Is.EqualTo("Plants"));
			Assert.That(result?.DiscountName, Is.EqualTo("10% Off"));
		}

		[Test]
		public async Task GetProductDetailsByIdAsync_ShouldReturnNull_WhenProductDoesNotExist()
		{
			var nonExistentProductId = Guid.NewGuid();

			_productRepository.Setup(r => r.GetAllAttached())
				.Returns(Enumerable.Empty<Product>().AsQueryable().BuildMock());

			var productService = new ProductService(
				_productRepository.Object,
				_categoriesRepository.Object,
				_discountRepository.Object
			);

			var result = await productService.GetProductDetailsByIdAsync(nonExistentProductId);

			Assert.That(result, Is.Null);
		}

		[Test]
		public async Task GetProductForEditByIdAsync_ShouldReturnCorrectData_WhenProductExists()
		{
			var productId = Guid.NewGuid();
			var mockProduct = new Product
			{
				Id = productId,
				Name = "Caladium",
				Description = "A beautiful ornamental plant",
				Price = 19.99m,
				Quantity = 10,
				ImageUrl = "https://example.com/image.jpg",
				IsDeleted = false,
				CategoryId = 1,
				DiscountId = 1
			};

			var mockCategory = new Category { Id = 1, Name = "Plants", IsDeleted = false };
			var mockDiscount = new Discount { Id = 1, Name = "10% Off" };

			_productRepository.Setup(r => r.GetAllAttached())
				.Returns(new[] { mockProduct }.AsQueryable().BuildMock());

			_categoriesRepository.Setup(r => r.GetAllAttached())
				.Returns(new[] { mockCategory }.AsQueryable().BuildMock());

			_discountRepository.Setup(r => r.GetAllAsync())
				.ReturnsAsync(new[] { mockDiscount });

			var productService = new ProductService(
				_productRepository.Object,
				_categoriesRepository.Object,
				_discountRepository.Object
			);

			var result = await productService.GetProductForEditByIdAsync(productId);

			Assert.That(result, Is.Not.Null);
			Assert.That(result?.Name, Is.EqualTo("Caladium"));
			Assert.That(result?.Description, Is.EqualTo("A beautiful ornamental plant"));
			Assert.That(result?.Price, Is.EqualTo(19.99m));
			Assert.That(result?.Quantity, Is.EqualTo(10));
			Assert.That(result?.Categories.Count(), Is.EqualTo(1));  
			Assert.That(result?.Discounts.Count(), Is.EqualTo(1));  
		}

		[Test]
		public async Task GetProductForEditByIdAsync_ShouldReturnNull_WhenProductDoesNotExist()
		{

			var nonExistentProductId = Guid.NewGuid();

			_productRepository.Setup(r => r.GetAllAttached())
				.Returns(Enumerable.Empty<Product>().AsQueryable().BuildMock());

			var productService = new ProductService(
				_productRepository.Object,
				_categoriesRepository.Object,
				_discountRepository.Object
			);


			var result = await productService.GetProductForEditByIdAsync(nonExistentProductId);


			Assert.That(result, Is.Null);
		}

		[Test]
		public async Task GetProductForEditByIdAsync_ShouldReturnNull_WhenProductIsDeleted()
		{

			var productId = Guid.NewGuid();
			var mockProduct = new Product
			{
				Id = productId,
				Name = "Caladium",
				Description = "A beautiful ornamental plant",
				Price = 19.99m,
				Quantity = 10,
				ImageUrl = "https://example.com/image.jpg",
				IsDeleted = true, 
				CategoryId = 1,
				DiscountId = 1
			};

			_productRepository.Setup(r => r.GetAllAttached())
				.Returns(new[] { mockProduct }.AsQueryable().BuildMock());

			var productService = new ProductService(
				_productRepository.Object,
				_categoriesRepository.Object,
				_discountRepository.Object
			);

			var result = await productService.GetProductForEditByIdAsync(productId);

			Assert.That(result, Is.Null);
		}

		[Test]
		public async Task GetProductToDeleteByIdAsync_ShouldReturnCorrectData_WhenProductExists()
		{

			var productId = Guid.NewGuid();
			var mockProduct = new Product
			{
				Id = productId,
				Name = "Caladium",
				Description = "A beautiful ornamental plant",
				Price = 19.99m,
				ImageUrl = "https://example.com/image.jpg",
				IsDeleted = false,
				Discount = new Discount { Name = "10% Off" }
			};

			_productRepository.Setup(r => r.GetAllAttached())
				.Returns(new[] { mockProduct }.AsQueryable().BuildMock());

			var productService = new ProductService(
				_productRepository.Object,
				_categoriesRepository.Object,
				_discountRepository.Object
			);

			var result = await productService.GetProductToDeleteByIdAsync(productId);

			Assert.That(result, Is.Not.Null);
			Assert.That(result?.Id, Is.EqualTo(productId.ToString()));
			Assert.That(result?.Name, Is.EqualTo("Caladium"));
			Assert.That(result?.Description, Is.EqualTo("A beautiful ornamental plant"));
			Assert.That(result?.Price, Is.EqualTo(19.99m));
			Assert.That(result?.DiscountName, Is.EqualTo("10% Off"));
		}


		[Test]
		public async Task GetProductToDeleteByIdAsync_ShouldReturnNull_WhenProductDoesNotExist()
		{
			var nonExistentProductId = Guid.NewGuid();

			_productRepository.Setup(r => r.GetAllAttached())
				.Returns(Enumerable.Empty<Product>().AsQueryable().BuildMock());

			var productService = new ProductService(
				_productRepository.Object,
				_categoriesRepository.Object,
				_discountRepository.Object
			);

			var result = await productService.GetProductToDeleteByIdAsync(nonExistentProductId);

			Assert.That(result, Is.Null);
		}

		[Test]
		public async Task GetProductToDeleteByIdAsync_ShouldReturnNull_WhenProductIsDeleted()
		{

			var productId = Guid.NewGuid();
			var mockProduct = new Product
			{
				Id = productId,
				Name = "Caladium",
				Description = "A beautiful ornamental plant",
				Price = 19.99m,
				ImageUrl = "https://example.com/image.jpg",
				IsDeleted = true,  
				Discount = new Discount { Name = "10% Off" }
			};

			_productRepository.Setup(r => r.GetAllAttached())
				.Returns(new[] { mockProduct }.AsQueryable().BuildMock());

			var productService = new ProductService(
				_productRepository.Object,
				_categoriesRepository.Object,
				_discountRepository.Object
			);


			var result = await productService.GetProductToDeleteByIdAsync(productId);

			Assert.That(result, Is.Null);
		}
	}
}