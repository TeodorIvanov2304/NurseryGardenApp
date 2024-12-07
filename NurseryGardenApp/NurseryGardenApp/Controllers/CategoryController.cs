using Microsoft.AspNetCore.Mvc;
using NurseryGardenApp.Services.Data.Interfaces;

namespace NurseryGardenApp.Controllers
{
	public class CategoryController : Controller
	{
		private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this._categoryService = categoryService;
        }

		[HttpGet]
        public async Task<IActionResult> Index()
		{
			var model = await this._categoryService.GetAllCategoriesIndexAsync();

			return View(model);
		}
	}
}
