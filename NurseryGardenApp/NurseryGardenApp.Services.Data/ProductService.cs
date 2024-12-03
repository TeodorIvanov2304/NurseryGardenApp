using Microsoft.EntityFrameworkCore;
using NurseryGardenApp.Data.Data.Models;
using NurseryGardenApp.Data.Data.Repositories.Interfaces;
using NurseryGardenApp.Data.Models;
using NurseryGardenApp.Services.Data.Interfaces;
using NurseryGardenApp.ViewModels.Product;

namespace NurseryGardenApp.Services.Data
{
	public class ProductService : IProductService
	{	
		private readonly IRepository<Product,Guid> _productRepository;
		private readonly IRepository<Category, int> _categoriesRepository;
		private readonly IRepository<Discount, int> _discountRepository;

		public ProductService(IRepository<Product, Guid> productRepository, IRepository<Category, int> categoriesRepository, IRepository<Discount, int> discountRepository)
        {
            this._productRepository = productRepository;
			this._categoriesRepository = categoriesRepository;
			this._discountRepository = discountRepository;
        }
        public async Task<bool> AddProductAsync(ProductCreateViewModel viewModel)
		{
			Category? categoryExists = await _categoriesRepository.GetByIdAsync(viewModel.CategoryId);

			if (categoryExists == null)
			{
				return false; 
			}

			if (viewModel.DiscountId.HasValue)
			{
				var discount = await _discountRepository.GetByIdAsync(viewModel.DiscountId.Value);
				if (discount == null)
				{
					return false;
				}
			}

			var product = new Product
			{
				Name = viewModel.Name,
				Description = viewModel.Description,
				Price = viewModel.Price,
				ImageUrl = viewModel.ImageUrl,
				Quantity = viewModel.Quantity,
				CategoryId = viewModel.CategoryId,
				DiscountId = viewModel.DiscountId,
				IsDeleted = false 
			};


			await _productRepository.AddAsync(product);
			await _productRepository.SaveChangesAsync();

			return true;
		}

		public async Task<IEnumerable<AllProductsIndexViewModel>> GetAllProductsAsync()
		{
			var allProducts = await this._productRepository
				.GetAllAttached()
				.Where(p => p.IsDeleted == false)
				.Select(p => new AllProductsIndexViewModel
				{
					ProductName = p.Name,
					Description = p.Description,
					Price = p.Price,
					ImageURL = p.ImageUrl,
					CategoryName = p.Category.Name,
					DiscountName = p.Discount.Name ?? string.Empty
				})
				.ToListAsync();

			return allProducts;
		}
	}
}
