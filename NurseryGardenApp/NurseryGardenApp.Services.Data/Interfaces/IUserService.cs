﻿using NurseryGardenApp.ViewModels.Admin.UserManagement;

namespace NurseryGardenApp.Services.Data.Interfaces
{
	public interface IUserService
	{
		Task<IEnumerable<AllUsersViewModel>> GetAllUserAsync();
		Task<bool> UserExistsByIdAsync(string userId);
		Task<bool> AssignUserToRoleAsync(string userId, string roleName);
		Task<bool> RemoveUserRoleAsync(string userId,string roleName);
		Task<bool> DeleteUserAsync(string userId);
	}
}
