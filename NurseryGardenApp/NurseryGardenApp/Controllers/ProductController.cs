﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NurseryGardenApp.Services.Data.Interfaces;
using NurseryGardenApp.ViewModels.Product;
using static NurseryGardenApp.Common.Utility;
using static NurseryGardenApp.Common.ErrorMessages;

namespace NurseryGardenApp.Controllers
{
	public class ProductController : BaseController
	{
		private readonly ICategoryService _categoryService;
		private readonly IDiscountService _discountService;
		private readonly IProductService _productService;
		private readonly IManagerService _managerService;
		public ProductController(ICategoryService categoryService, IDiscountService discountService, IProductService productService, IManagerService _managerService)
		{
			this._categoryService = categoryService;
			this._discountService = discountService;
			this._productService = productService;
			this._managerService = _managerService;
		}

		[HttpGet]
		public async Task<IActionResult> Index(string? searchQuery = null,
			string ? discount = null, 
			string? category = null,
			int pageNumber = 1,
			int pageSize = 10)
		{
			var model = await this._productService.GetAllProductsAsync(searchQuery, discount, category, pageNumber, pageSize);

			int filteredProductsCount = await this._productService.GetProductsCountAsync(searchQuery, discount, category);

			model.TotalPages = (int)Math.Ceiling((double)filteredProductsCount / model.EntitiesPerPage);
			model.CurrentPage = pageNumber;

			return View(model);
		}

		[HttpGet]
		[Authorize]
		public async Task<IActionResult> Create()
		{
			var userId = this.GetCurrentUserId();
			bool isManager = await this._managerService.IsUserManagerAsync(userId);

			if (isManager == false)
			{
				return this.RedirectToAction("Index", "Home");
			}

			var categories = await _categoryService.GetAllCategoriesAsync();

			var discounts = await _discountService.GetAllDiscountsAsync();

			var model = await _productService.GetAddProductCreateAsync();

			return View(model);
		}

		[HttpPost]
		[Authorize]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(ProductCreateViewModel viewModel)
		{
			var userId = this.GetCurrentUserId();
			bool isManager = await this._managerService.IsUserManagerAsync(userId);

			if (isManager == false)
			{
				return this.RedirectToAction("Index", "Home");
			}

			if (ModelState.IsValid == false)
			{
				return View(viewModel);
			}

			var categories = await this._categoryService.GetAllCategoriesAsync();
			var discounts = await this._discountService.GetAllDiscountsAsync();

			bool result = await this._productService.AddProductAsync(viewModel);

			if (result == false)
			{
				ModelState.AddModelError(string.Empty, UnableToAddProductErrorMessage);
				categories = await this._categoryService.GetAllCategoriesAsync();
				discounts = await this._discountService.GetAllDiscountsAsync();
				return View(viewModel);
			}

			return RedirectToAction(nameof(Index));
		}

		[HttpGet]
		[Authorize]
		public async Task<IActionResult> Edit(string? id)
		{
			var userId = this.GetCurrentUserId();
			bool isManager = await this._managerService.IsUserManagerAsync(userId);

			if (isManager == false)
			{
				return this.RedirectToAction("Index", "Home");
			}

			Guid productGuid = Guid.Empty;
			bool isValid = IsGuidValid(id, ref productGuid);

			if (!isValid)
			{
				return this.RedirectToAction("Custom404","Error",new { message = InvalidProductIdErrorMessage });
			}


			EditProductViewModel? productForEdit = await this._productService.GetProductForEditByIdAsync(productGuid);

			if (productForEdit == null)
			{
				return RedirectToAction("Custom404", "Error", new { message = ProductNotFoundErrorMessage });
			}

			return View(productForEdit);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		[Authorize]
		public async Task<IActionResult> Edit(string id, EditProductViewModel viewModel)
		{
			var userId = this.GetCurrentUserId();
			bool isManager = await this._managerService.IsUserManagerAsync(userId);

			if (isManager == false)
			{
				return this.RedirectToAction("Index", "Home");
			}

			if (ModelState.IsValid == false)
			{
				return this.View(viewModel);
			}

			Guid productGuid = Guid.Empty;
			bool isValid = IsGuidValid(id, ref productGuid);

			if (!isValid)
			{
				return this.RedirectToAction("Custom404", "Error", new { message = InvalidProductIdErrorMessage });
			}

			bool result = await this._productService.EditProductAsync(viewModel);

			if (result == false)
			{				
					return this.RedirectToAction("Custom500", "Error", new { message = UnableToUpdateProductErrorMessage });	
			}

			return RedirectToAction(nameof(Index));

		}

		[HttpGet]
		public async Task<IActionResult> Details(string? id)
		{
			Guid productGuid = Guid.Empty;
			bool isValid = IsGuidValid(id, ref productGuid);

			if (!isValid)
			{
				return this.RedirectToAction("Custom404", "Error", new { message = InvalidProductIdErrorMessage });
			}

			ProductDetailsViewModel? modelDetailed = await this._productService.GetProductDetailsByIdAsync(productGuid);

			if (modelDetailed == null)
			{
				return RedirectToAction("Custom404", "Error", new { message = ProductNotFoundErrorMessage });
			}

			return View(modelDetailed);
		}

		[HttpGet]
		[Authorize]
		public async Task<IActionResult> Delete(string? id)
		{
			var userId = this.GetCurrentUserId();
			bool isManager = await this._managerService.IsUserManagerAsync(userId);

			if (isManager == false)
			{
				return this.RedirectToAction("Index", "Home");
			}

			Guid productGuid = Guid.Empty;
			bool isValid = IsGuidValid(id,ref productGuid);

			if (!isValid) 
			{
				return this.RedirectToAction("Custom404", "Error", new { message = InvalidProductErrorMessage });
			}

			DeleteProductViewModel? modelToDelete = await this._productService.GetProductToDeleteByIdAsync(productGuid);

			if(modelToDelete == null)
			{
				return this.RedirectToAction("Custom404", "Error", new { message = ProductNotFoundErrorMessage });
			}

			return this.View(modelToDelete);
		}

		[HttpPost]
		[Authorize]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(DeleteProductViewModel model)
		{
			var userId = this.GetCurrentUserId();
			bool isManager = await this._managerService.IsUserManagerAsync(userId);

			if (isManager == false)
			{
				return this.RedirectToAction("Index", "Home");
			}

			Guid productGuid = Guid.Empty;
			bool isValid = IsGuidValid(model.Id, ref productGuid);

			if (!isValid)
			{
				return this.RedirectToAction("Custom404", "Error", new { message = InvalidProductErrorMessage });
			}

			bool isDeleted = await this._productService.DeleteProductAsync(productGuid);

			if (!isDeleted) 
			{
				ModelState.AddModelError("", UnableToDeleteProductErrorMessage);
				return this.View(model);
			}

			return this.RedirectToAction(nameof(Index));
		}

		[HttpGet]
		[Authorize]
		public async Task<IActionResult> Manage()
		{
			var userId = this.GetCurrentUserId();
			bool isManager = await this._managerService.IsUserManagerAsync(userId);

			if (isManager == false)
			{
				return this.RedirectToAction("Index","Home");
			}

			IEnumerable<AllProductsManageViewModel> products = await this._productService.GetAllProductsForManageAsync();

			return this.View(products);
		}
	}
}