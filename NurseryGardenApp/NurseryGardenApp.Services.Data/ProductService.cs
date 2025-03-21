﻿using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NurseryGardenApp.Data.Data.Models;
using NurseryGardenApp.Data.Data.Repositories.Interfaces;
using NurseryGardenApp.Data.Models;
using NurseryGardenApp.Services.Data.Interfaces;
using NurseryGardenApp.ViewModels.Product;
using static NurseryGardenApp.Common.ErrorMessages;

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

			if (categoryExists == null || categoryExists.IsDeleted)
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

			if (await _productRepository.FindByNameAsync(viewModel.Name))
			{
				return false;
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
				Product? product = await this._productRepository
					.GetAllAttached()
					.Where(p => p.IsDeleted == false)
					.FirstOrDefaultAsync(p => p.Id == id);

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

		public async Task<ProductCreateViewModel> GetAddProductCreateAsync()
		{
			var modelToAdd = new ProductCreateViewModel
			{
				Categories = await _categoriesRepository
				.GetAllAttached()
				.Where(c => c.IsDeleted == false)
				.Select(c => new SelectListItem
				{
					Value = c.Id.ToString(),
					Text = c.Name
				}).ToListAsync(),
				Discounts = await _discountRepository
				.GetAllAttached().Select(d => new SelectListItem
				{
					Value = d.Id.ToString(),
					Text = d.Name
				}).ToListAsync()
			};


			return modelToAdd;
		}

		public async Task<AllProductsSearchFilterModel> GetAllProductsAsync(
	                 string? searchQuery = null,
	                 string? discount = null,
	                 string? category = null,
	                 int pageNumber = 1,
	                 int pageSize = 10)
		{
			var categories = await this._categoriesRepository
				.GetAllAttached()
				.Where(c => c.IsDeleted == false)
				.ToListAsync();

			var discounts = await this._discountRepository.GetAllAsync();

			var categoryList = categories.Select(c => new SelectListItem
			{
				Text = c.Name ?? ProductServiceUnknownCategoryValue,
				Value = c.Id.ToString(),
				Selected = c.Id.ToString() == category
			}).ToList();

			var discountList = discounts.Select(d => new SelectListItem
			{
				Text = d.Name ?? ProductServiceNoDiscountValue,
				Value = d.Id.ToString(),
				Selected = d.Id.ToString() == discount
			}).ToList();

			IQueryable<Product> products = this._productRepository.GetAllAttached();

			if (!string.IsNullOrWhiteSpace(searchQuery))
			{
				searchQuery = searchQuery!.ToLower().Trim();
				products = products
					.Where(p => p.Name.ToLower().Contains(searchQuery) && p.IsDeleted == false);
			}

			if (!string.IsNullOrEmpty(discount))
			{
				var discountId = int.Parse(discount);
				products = products.Where(p => p.DiscountId == discountId);
			}

			if (!string.IsNullOrEmpty(category))
			{
				var categoryId = int.Parse(category);
				products = products.Where(p => p.CategoryId == categoryId);
			}

			products = products.Skip((pageNumber - 1) * pageSize)
							   .Take(pageSize);

			var productModels = await products
				.Where(p => p.IsDeleted == false)
				.Select(p => new AllProductsIndexViewModel
				{
					Id = p.Id.ToString(),
					ProductName = p.Name,
					Price = p.Price,
					ImageURL = p.ImageUrl,
					CategoryName = p.Category != null ? p.Category.Name : ProductServiceUnknownCategoryValue,
					DiscountName = p.Discount != null ? p.Discount.Name : ProductServiceNoDiscountValue,
					Discount = p.Discount != null ? p.Discount.DiscountValue : 0m,
					PriceWithDiscount = p.Discount != null ? p.Price * (1 - p.Discount.DiscountValue / 100) : p.Price
				})
				.AsNoTracking()
				.ToListAsync();

			var model = new AllProductsSearchFilterModel
			{
				Products = productModels,
				Categories = categoryList,
				Discounts = discountList,
				SearchQuery = searchQuery,
				SelectedCategory = category,
				SelectedDiscount = discount
			};

			return model;
		}

		public async Task<IEnumerable<AllProductsManageViewModel>> GetAllProductsForManageAsync()
		{
			var allProductsForManage = await this._productRepository
				.GetAllAttached()
				.Where(p => p.IsDeleted == false)
				.Select(p => new AllProductsManageViewModel
				{
					Id = p.Id.ToString(),
					Name = p.Name,
					Price = p.Price,
					ImageURL = p.ImageUrl,
					CategoryName = p.Category.Name,
					Quantity = p.Quantity
				})
				.ToListAsync();

			return allProductsForManage;
		}

		public async Task<int> GetProductsCountAsync(string? searchQuery = null, string? discount = null, string? category = null)
		{
			IQueryable<Product> products = this._productRepository
										.GetAllAttached()
										.Where(p => p.IsDeleted == false);

			if (!string.IsNullOrWhiteSpace(searchQuery))
			{
				searchQuery = searchQuery!.ToLower().Trim();
				products = products.Where(p => p.Name.ToLower().Contains(searchQuery));
			}

			if (!string.IsNullOrEmpty(discount))
			{
				var discountId = int.Parse(discount);
				products = products.Where(p => p.DiscountId == discountId);
			}

			if (!string.IsNullOrEmpty(category))
			{
				var categoryId = int.Parse(category);
				products = products.Where(p => p.CategoryId == categoryId);
			}

			return await products.CountAsync();
		}

		public async Task<List<Product>> GetTopSellingProductsAsync()
		{
			return await _productRepository.GetAllAttached()
				.Where(p => !p.IsDeleted)
				.Take(4)
				.ToListAsync();
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
										 .Where(p => p.IsDeleted == false)
										 .FirstOrDefaultAsync(p => p.Id == id);

			if (product == null || product.IsDeleted)
			{
				return null;
			}

			IEnumerable<Category> categories = await this._categoriesRepository
				.GetAllAttached()
				.Where(c => c.IsDeleted == false)
				.ToListAsync();

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
