using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NurseryGardenApp.Models;
using NurseryGardenApp.Services.Data.Interfaces;
using System.Diagnostics;

namespace NurseryGardenApp.Controllers
{
	[AllowAnonymous]
	public class HomeController : Controller
	{

		private readonly IProductService _productService;
		private readonly ICategoryService _categoryService;

		public HomeController(IProductService productService, ICategoryService categoryService)
		{
			_productService = productService;
			_categoryService = categoryService;
		}
		public async Task<IActionResult> Index()
		{
			var categories = await _categoryService.GetAllCategoriesAsync();
			var products = await _productService.GetTopSellingProductsAsync();

			ViewData["Categories"] = categories;
			ViewData["TopProducts"] = products;

			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
