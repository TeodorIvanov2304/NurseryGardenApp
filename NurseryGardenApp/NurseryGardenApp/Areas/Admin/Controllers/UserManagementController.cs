using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NurseryGardenApp.Services.Data.Interfaces;
using NurseryGardenApp.ViewModels.Admin.UserManagement;
using System.Data;

namespace NurseryGardenApp.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles ="Admin")]	
	public class UserManagementController : Controller
	{
		private readonly IUserService _userService;

		public UserManagementController(IUserService userService)
		{
			this._userService = userService;
		}

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			IEnumerable<AllUsersViewModel> users = await this._userService.GetAllUserAsync();
			return View(users);
		}

		[HttpPost]
		public async Task<IActionResult> AssignRole(string userId, string role)
		{
			bool userExists = await this._userService.UserExistsByIdAsync(userId);

			if (!userExists) 
			{
				return this.RedirectToAction(nameof(Index));
			}

			bool assignResult = await this._userService.AssignUserToRoleAsync(userId,role);

			if (!assignResult)
			{
				return this.RedirectToAction(nameof(Index));
			}

			return this.RedirectToAction(nameof(Index));
		}

		[HttpPost]
		public async Task<IActionResult> RemoveRole(string userId, string role)
		{
			bool userExists = await this._userService.UserExistsByIdAsync(userId);

			if (!userExists)
			{
				return this.RedirectToAction(nameof(Index));
			}

			bool removeResult = await this._userService.RemoveUserRoleAsync(userId, role);

			if (!removeResult)
			{
				return this.RedirectToAction(nameof(Index));
			}

			return this.RedirectToAction(nameof(Index));
		}

		[HttpPost]
		public async Task<IActionResult> DeleteUser(string userId)
		{
			bool userExists = await this._userService.UserExistsByIdAsync(userId);

			if (!userExists)
			{
				return this.RedirectToAction(nameof(Index));
			}

			bool removeResult = await this._userService.DeleteUserAsync(userId);

			if (!removeResult)
			{
				return this.RedirectToAction(nameof(Index));
			}

			return this.RedirectToAction(nameof(Index));

		}
	}
}
