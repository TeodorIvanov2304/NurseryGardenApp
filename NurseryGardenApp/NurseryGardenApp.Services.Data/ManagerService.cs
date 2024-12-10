using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NurseryGardenApp.Data.Data.Repositories.Interfaces;
using NurseryGardenApp.Data.Models;
using NurseryGardenApp.Services.Data.Interfaces;

namespace NurseryGardenApp.Services.Data
{
	public class ManagerService : IManagerService
	{
		private readonly IRepository<Manager, Guid> _managerRepository;
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly RoleManager<IdentityRole> _roleManager;
		public ManagerService(IRepository<Manager, Guid> managerRepository, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
			this._managerRepository = managerRepository;       
			this._userManager = userManager;
			this._roleManager = roleManager;
        }

		public async Task<bool> IsUserManagerAsync(string? userId)
		{
			if (String.IsNullOrWhiteSpace(userId))
			{
				return false;
			}

			var user = await _userManager.FindByIdAsync(userId);
			if (user == null)
			{
				return false;
			}

			var roles = await _userManager.GetRolesAsync(user);

			if (roles.Contains("Manager"))
			{
				return true;
			}

			return false;
		}
	}
}
