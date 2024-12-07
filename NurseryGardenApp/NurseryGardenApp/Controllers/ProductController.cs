using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NurseryGardenApp.Services.Data.Interfaces;
using NurseryGardenApp.ViewModels.Product;
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
		public async Task<IActionResult> Index()
		{
			IEnumerable<AllProductsIndexViewModel> models = await this._productService.GetAllProductsAsync();

			return View(models);
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
				ModelState.AddModelError(string.Empty, "Unable to add product. Please try again.");
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
			bool isValid = this.IsGuidValid(id, ref productGuid);

			if (!isValid)
			{
				return this.RedirectToAction("Custom404","Error",new { message = "Invalid Product Id"});
			}


			EditProductViewModel? productForEdit = await this._productService.GetProductForEditByIdAsync(productGuid);

			if (productForEdit == null)
			{
				return RedirectToAction("Custom404", "Error", new { message = "Product not found." });
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
			bool isValid = this.IsGuidValid(id, ref productGuid);

			if (!isValid)
			{
				return this.RedirectToAction("Custom404", "Error", new { message = "Invalid Product Id" });
			}

			bool result = await this._productService.EditProductAsync(viewModel);

			if (result == false)
			{
				{
					return this.RedirectToAction("Custom500", "Error", new { message = "Failed to update the product." });
				}
			}

			return RedirectToAction(nameof(Index));

		}

		[HttpGet]
		public async Task<IActionResult> Details(string? id)
		{
			Guid productGuid = Guid.Empty;
			bool isValid = this.IsGuidValid(id, ref productGuid);

			if (!isValid)
			{
				return this.RedirectToAction("Custom404", "Error", new { message = "Invalid Product Id" });
			}

			ProductDetailsViewModel? modelDetailed = await this._productService.GetProductDetailsByIdAsync(productGuid);

			if (modelDetailed == null)
			{
				return RedirectToAction("Custom404", "Error", new { message = "Product not found." });
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
			bool isValid = this.IsGuidValid(id,ref productGuid);

			if (!isValid) 
			{
				return this.RedirectToAction("Custom404", "Error", new { message = "Invalid Product" });
			}

			DeleteProductViewModel? modelToDelete = await this._productService.GetProductToDeleteByIdAsync(productGuid);

			if(modelToDelete == null)
			{
				return this.RedirectToAction("Custom404", "Error", new { message = "Product not found" });
			}

			return this.View(modelToDelete);
		}

		[HttpPost]
		[Authorize]
		public async Task<IActionResult> DeleteConfirmed(DeleteProductViewModel model)
		{
			var userId = this.GetCurrentUserId();
			bool isManager = await this._managerService.IsUserManagerAsync(userId);

			if (isManager == false)
			{
				return this.RedirectToAction("Index", "Home");
			}

			Guid productGuid = Guid.Empty;
			bool isValid = this.IsGuidValid(model.Id, ref productGuid);

			if (!isValid)
			{
				return this.RedirectToAction("Custom404", "Error", new { message = "Invalid Product" });
			}

			bool isDeleted = await this._productService.DeleteProductAsync(productGuid);

			if (!isDeleted) 
			{
				ModelState.AddModelError("", "Unable to delete the product. Please try again later.");
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