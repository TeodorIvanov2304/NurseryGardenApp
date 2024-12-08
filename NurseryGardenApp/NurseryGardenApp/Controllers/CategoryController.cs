﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NurseryGardenApp.Data.Data.Models;
using NurseryGardenApp.Services.Data.Interfaces;
using NurseryGardenApp.ViewModels.Category;
using NurseryGardenApp.ViewModels.Product;
using System.ClientModel.Primitives;

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
		[ValidateAntiForgeryToken]
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

			EditCategoryViewModel? categoryToEditModel = await this._categoryService.GetCategoryForEditByIdAsync(id);

			if (categoryToEditModel == null)
			{
				return RedirectToAction("Custom404", "Error", new { message = "Category not found." });
			}

			return View(categoryToEditModel);
		}

		[HttpPost]
		[Authorize]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(EditCategoryViewModel model, int id)
		{
			var userId = this.GetCurrentUserId();
			bool isManager = await this._managerService.IsUserManagerAsync(userId);

			if (isManager == false)
			{
				return this.RedirectToAction("Index", "Home");
			}

			if (ModelState.IsValid == false)
			{
				return this.View(model);
			}

			bool isValid = this.IsIdValid(id);

			if (!isValid)
			{
				return this.RedirectToAction("Custom404", "Error", new { message = "Invalid Category Id" });
			}

			bool isCategoryExisting = await this._categoryService.DoesCategoryExistAsync(model.Id);

			if (!isCategoryExisting)
			{
				return this.RedirectToAction("Custom404", "Error", new { message = "Category not found." });
			}

			model.Id = id;

			bool result = await this._categoryService.EditCategoryAsync(model);

			if (result == false)
			{
				return this.RedirectToAction("Custom500", "Error", new { message = "Failed to update the product." });
			}

			return RedirectToAction(nameof(Index));
		}

		[HttpGet]
		[Authorize]
		public async Task<IActionResult> Delete(int? id)
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
				return this.RedirectToAction("Custom404", "Error", new { message = "Invalid Category" });
			}

			DeleteCategoryViewModel? modelToDelete = await this._categoryService.GetCategoryToDeleteByIdAsync(id);

			if (modelToDelete == null)
			{
				return this.RedirectToAction("Custom404", "Error", new { message = "Category not found" });
			}

			return this.View(modelToDelete);

		}

		[HttpPost]
		[Authorize]
		[AutoValidateAntiforgeryToken]
		public async Task<IActionResult> DeleteConfirmed(DeleteCategoryViewModel model)
		{
			var userId = this.GetCurrentUserId();
			bool isManager = await this._managerService.IsUserManagerAsync(userId);

			if (isManager == false)
			{
				return this.RedirectToAction("Index", "Home");
			}

			bool isValid = this.IsIdValid(model.Id);

			if (!isValid)
			{
				return this.RedirectToAction("Custom404", "Error", new { message = "Invalid Category" });
			}

			bool isDeleted = await this._categoryService.DeleteCategoryAsync(model.Id);

			if (!isDeleted)
			{
				ModelState.AddModelError("", "Unable to delete the category. Please try again later.");
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
				return this.RedirectToAction("Index", "Home");
			}

			IEnumerable<AllCategoriesIndexViewModel> categories = await this._categoryService.GetAllCategoriesForManageAsync();

			return this.View(categories);
		}
	}
}
