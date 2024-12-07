using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NurseryGardenApp.Data.Data.Models;
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

			CategoryCreateViewModel categoryModel = await this._categoryService.GetAddCategoryAsync();

			return this.View(categoryModel);

		}

		[HttpGet]
		[Authorize]
		public async Task<IActionResult> Edit(int? id)
		{
			var userId = this.GetCurrentUserId();
			bool isManager = await this._managerService.IsUserManagerAsync(userId);

			if (isManager == false)
			{
				return this.RedirectToAction("Index", "Home");
			}

			bool isValid = this.IsIdValid(id);

			if (!isValid)
			{
				return this.RedirectToAction("Custom404", "Error", new { message = "Invalid Category Id" });
			}

			EditCategoryViewModel? categoryToEdit = await this._categoryService.GetCategoryForEditByIdAsync(id);

			if (categoryToEdit == null)
			{
				return RedirectToAction("Custom404", "Error", new { message = "Category not found." });
			}

			return View(categoryToEdit);
		}


		public async Task<IActionResult> Create(CategoryCreateViewModel model)
		{
			var userId = this.GetCurrentUserId();
			bool isManager = await this._managerService.IsUserManagerAsync(userId);

			if (isManager == false)
			{
				return this.RedirectToAction("Index", "Home");
			}

			if (!ModelState.IsValid)
			{
				var classes = await this._classService.GetAllClassesAsync();
				return View(model);
			}

			bool result = await this._categoryService.AddCategoryAsync(model);

			if (result == false)
			{
				ModelState.AddModelError(string.Empty, "Unable to add category. Please try again.");
				var classes = await this._classService.GetAllClassesAsync();
				return View(model);
			}

			return RedirectToAction(nameof(Index));
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
