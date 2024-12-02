using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NurseryGardenApp.Services.Data.Interfaces;
using NurseryGardenApp.ViewModels.Product;

namespace NurseryGardenApp.Controllers
{
	public class ProductController : BaseController
	{
		private readonly ICategoryService _categoryService;
		private readonly IDiscountService _discountService;

        public ProductController(ICategoryService categoryService, IDiscountService discountService)
        {
            this._categoryService = categoryService;
			this._discountService = discountService;
        }

        public async Task<IActionResult> Index()
		{
			return View();
		}

		[HttpGet]
		[Authorize]
		public async Task<IActionResult> Create()
		{
			return View();
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
		}
	}
}
