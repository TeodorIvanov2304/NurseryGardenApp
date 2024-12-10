using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NurseryGardenApp.Data.Models;
using NurseryGardenApp.Services.Data.Interfaces;
using NurseryGardenApp.ViewModels.Admin.UserManagement;

namespace NurseryGardenApp.Services.Data
{
	public class UserService : IUserService
	{	
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly RoleManager<IdentityRole> _roleManager;
        public UserService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this._userManager = userManager;
			this._roleManager = roleManager;
        }

		public async Task<bool> AssignUserToRoleAsync(string userId, string roleName)
		{
			ApplicationUser? user = await this._userManager.FindByIdAsync(userId);

			bool roleExists = await this._roleManager.RoleExistsAsync(roleName);

			if(user == null || !roleExists)
			{
				return false;
			}

			bool alreadyInRole = await this._userManager.IsInRoleAsync(user, roleName);

			if (!alreadyInRole)
			{ 
				IdentityResult? result =  await this._userManager.AddToRoleAsync(user, roleName);

				if (!result.Succeeded)
				{
					return false;
				}
			}

			return true;
		}

		public async Task<bool> DeleteUserAsync(string userId)
		{
			ApplicationUser? user = await this._userManager.FindByIdAsync(userId);
			
			if (user == null)
			{
				return false;
			}

			IdentityResult? result = await this._userManager.DeleteAsync(user);

			if (result.Succeeded)
			{
				return false;
			}

			return true;
		}

		public async Task<IEnumerable<AllUsersViewModel>> GetAllUserAsync()
		{

			IEnumerable<AllUsersViewModel> allUsers = await this._userManager.Users
				.Select(u => new AllUsersViewModel
				{
					Id = u.Id,
					Email = u.Email,
					Roles = new List<string>()
				})
				.ToArrayAsync();


			foreach (AllUsersViewModel user in allUsers)
			{
				ApplicationUser? appUser = await _userManager.FindByIdAsync(user.Id);

				if (appUser == null)
				{
					user.Roles = new List<string>();
				}
				else
				{
					user.Roles = await this._userManager.GetRolesAsync(appUser);
				}
			}

			return allUsers;

		}

		public async Task<bool> RemoveUserRoleAsync(string userId, string roleName)
		{
			ApplicationUser? user = await this._userManager.FindByIdAsync(userId);

			bool roleExists = await this._roleManager.RoleExistsAsync(roleName);

			if (user == null || !roleExists)
			{
				return false;
			}

			bool alreadyInRole = await this._userManager.IsInRoleAsync(user, roleName);

			if (alreadyInRole)
			{
				IdentityResult? result = await this._userManager.RemoveFromRoleAsync(user, roleName);

				if (!result.Succeeded)
				{
					return false;
				}
			}

			return true;
		}

		public async Task<bool> UserExistsByIdAsync(string userId)
		{
			ApplicationUser? user = await this._userManager.FindByIdAsync(userId);

			if (user == null)
			{
				return false;
			}

			return true;
		}
	}
}
