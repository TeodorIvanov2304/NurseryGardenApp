using Microsoft.AspNetCore.Mvc;

namespace NurseryGardenApp.Controllers
{
	public class ErrorController : BaseController
	{
		[Route("Error/Custom404")]
		public IActionResult Custom404(string message)
		{
			ViewData["ErrorMessage"] = message;
			return View();
		}
	}
}
