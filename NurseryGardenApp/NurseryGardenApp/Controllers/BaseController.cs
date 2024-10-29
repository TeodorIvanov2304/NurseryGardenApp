using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace NurseryGardenApp.Controllers
{
	[Authorize]
	public class BaseController : Controller
	{
		protected string? GetCurrentUserId()
		{
			if (User != null)
			{
				return User?.FindFirstValue(ClaimTypes.NameIdentifier);
			}

			return string.Empty;
		}
	}
}
