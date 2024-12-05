using Microsoft.AspNetCore.Mvc.Rendering;
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
		private readonly IRepository<Product, Guid> _productRepository;
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

		public async Task<bool> DeleteProductAsync(Guid id)
		{
			try
			{
				var product = await this._productRepository.GetByIdAsync(id);

				if (product == null || product.IsDeleted)
				{
					return false;
				}

				product.IsDeleted = true;
				await this._productRepository.SaveChangesAsync();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public async Task<bool> EditProductAsync(EditProductViewModel viewModel)
		{
			Product? productToEdit = await this._productRepository
										  .GetAllAttached()
										  .Where(d => d.IsDeleted == false)
										  .FirstOrDefaultAsync(p => p.Id.ToString() == viewModel.Id);

			if (productToEdit == null)
			{
				return false;
			}

			productToEdit.Name = viewModel.Name;
			productToEdit.Description = viewModel.Description;
			productToEdit.Price = viewModel.Price;
			productToEdit.ImageUrl = viewModel.ImageUrl;
			productToEdit.Quantity = viewModel.Quantity;
			productToEdit.CategoryId = viewModel.CategoryId;
			productToEdit.DiscountId = viewModel.DiscountId;

			await this._productRepository.SaveChangesAsync();

			return true;

		}

		public async Task<IEnumerable<AllProductsIndexViewModel>> GetAllProductsAsync()
		{
			var allProducts = await this._productRepository
				.GetAllAttached()
				.Where(p => p.IsDeleted == false)
				.Select(p => new AllProductsIndexViewModel
				{
					Id = p.Id.ToString(),
					ProductName = p.Name,
					Price = p.Price,
					ImageURL = p.ImageUrl,
					CategoryName = p.Category.Name,
					DiscountName = p.Discount != null ? p.Discount.Name : string.Empty
				})
				.AsNoTracking()
				.ToListAsync();

			return allProducts;
		}

		public Task<ProductDetailsViewModel?> GetProductDetailsByIdAsync(Guid id)
		{
			var modelDetailed = this._productRepository
									.GetAllAttached()
									.Where(m => m.IsDeleted == false)
									.Where(m => m.Id == id)
									.AsNoTracking()
									.Select(m => new ProductDetailsViewModel
									{
										Id = m.Id.ToString(),
										Description = m.Description,
										ProductName = m.Name,
										ImageURL = m.ImageUrl,
										Price = m.Price,
										CategoryName = m.Category.Name,
										DiscountName = m.Discount != null ? m.Discount.Name : string.Empty
									})
									.FirstOrDefaultAsync();

			return modelDetailed;

		}

		public async Task<EditProductViewModel?> GetProductForEditByIdAsync(Guid id)
		{

			Product? product = await this._productRepository
										 .GetAllAttached()
										 .FirstOrDefaultAsync(p => p.Id == id);

			if (product == null)
			{
				return null;
			}

			IEnumerable<Category> categories = await this._categoriesRepository.GetAllAsync();
			IEnumerable<Discount> discounts = await this._discountRepository.GetAllAsync();

			EditProductViewModel modelForEdit = new EditProductViewModel
			{
				Id = product.Id.ToString(),
				Name = product.Name,
				Description = product.Description,
				Price = product.Price,
				ImageUrl = product.ImageUrl,
				Quantity = product.Quantity,
				Categories = categories.Select(c => new SelectListItem
				{
					Value = c.Id.ToString(),
					Text = c.Name,
					Selected = c.Id == product.CategoryId
				}),
				Discounts = discounts.Select(d => new SelectListItem
				{
					Value = d.Id.ToString(),
					Text = d.Name,
					Selected = d.Id == product.DiscountId
				})
			};

			return modelForEdit;
		}

		public async Task<DeleteProductViewModel?> GetProductToDeleteByIdAsync(Guid id)
		{
			DeleteProductViewModel? modelToDelete = await this._productRepository.GetAllAttached()
				  .Where(p => p.IsDeleted == false)
				  .Select(p => new DeleteProductViewModel
				  {
					  Id = p.Id.ToString(),
					  Name = p.Name,
					  Description = p.Description,
					  Price = p.Price,
					  ImageUrl = p.ImageUrl,
					  DiscountName = p.Discount != null ? p.Discount.Name : "No discount"
				  })
				  .FirstOrDefaultAsync(p => p.Id == id.ToString());

			return modelToDelete;
		}
	}
}
