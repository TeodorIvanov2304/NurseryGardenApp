using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NurseryGardenApp.Services.Data.Interfaces;
using NurseryGardenApp.ViewModels.Category;
using NurseryGardenApp.ViewModels.Product;

namespace NurseryGardenApp.Controllers
{
	public class CategoryController : BaseController
	{
		private readonly ICategoryService _categoryService;
		private readonly IManagerService _managerService;
		private readonly IClassService _classService;
        public CategoryController(ICategoryService categoryService, IManagerService managerService, IClassService classService)
        {
            this._categoryService = categoryService;
			this._managerService = managerService;
			this._classService = classService;
        }

		[HttpGet]
        public async Task<IActionResult> Index()
		{
			var model = await this._categoryService.GetAllCategoriesIndexAsync();

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

			var classes = await this._classService.GetAllClassesAsync();

			var categoryModel = await this._categoryService.GetAddCategoryAsync();

			return this.View(categoryModel);

		}


		[HttpGet]
		[Authorize]
		public async Task<IActionResult> Manage()
		{
			var userId = this.GetCurrentUserId();
			bool isManager = await this._managerService.IsUserManagerAsync(userId);

			if (isManager == false)
			{
				return this.RedirectToAction("Index", "Home");
			}

			IEnumerable<AllCategoriesIndexViewModel> categories = await this._categoryService.GetAllCategoriesForManageAsync();

			return this.View(categories);
		}
	}
}
