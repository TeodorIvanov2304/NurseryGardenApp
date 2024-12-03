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
        public ProductController(ICategoryService categoryService, IDiscountService discountService, IProductService productService)
        {
            this._categoryService = categoryService;
			this._discountService = discountService;
			this._productService = productService;
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
			var categories = await _categoryService.GetAllCategoriesAsync();
			var discounts = await _discountService.GetAllDiscountsAsync();

			var model = new ProductCreateViewModel
			{
				Categories = categories.Select(c => new SelectListItem
				{
					Value = c.Id.ToString(),
					Text = c.Name
				}).ToList(),
				Discounts = discounts.Select(d => new SelectListItem
				{
					Value = d.Id.ToString(),
					Text = d.Name
				}).ToList()
			};

			return View(model);
		}

		[HttpPost]
		[Authorize]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(ProductCreateViewModel viewModel)
		{
			if (ModelState.IsValid == false) 
			{
				return View(viewModel);
			}

			var categories =  await this._categoryService.GetAllCategoriesAsync();
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
	}
}
