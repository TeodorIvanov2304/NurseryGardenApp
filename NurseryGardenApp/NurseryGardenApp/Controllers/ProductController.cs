using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NurseryGardenApp.ViewModels.Product;

namespace NurseryGardenApp.Controllers
{
	public class ProductController : BaseController
	{
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


		}
	}
}
