using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NurseryGardenApp.Data.Models;

namespace NurseryGardenApp.Data.Data.Configuration
{
	public static class DatabaseSeeder
	{
		public static void SeedRoles(IServiceProvider serviceProvider)
		{
			var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

			string[] roles = { "Admin", "Manager", "User" };

			foreach (var role in roles)
			{
				var roleExists = roleManager.RoleExistsAsync(role).GetAwaiter().GetResult();
				if (!roleExists)
				{
					var result = roleManager.CreateAsync(new IdentityRole { Name = role }).GetAwaiter().GetResult();
					if (!result.Succeeded)
					{
						throw new Exception($"Failed to create role: {role}");
					}
				}
			}
		}

		public static void AssignAdminRole(IServiceProvider serviceProvider)
		{
			var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

			var configuration = serviceProvider.GetRequiredService<IConfiguration>();

			string? adminEmail = configuration["AdminUser:Email"];
			string? adminPassword = configuration["AdminUser:Password"];

			if (string.IsNullOrEmpty(adminEmail) || string.IsNullOrEmpty(adminPassword))
			{
				throw new Exception("Admin email or password is not configured properly.");
			}

			var adminUser = userManager.FindByEmailAsync(adminEmail).GetAwaiter().GetResult();
			if (adminUser == null)
			{
				adminUser = new ApplicationUser
				{
					UserName = adminEmail,
					Email = adminEmail
				};
				var createUserResult = userManager.CreateAsync(adminUser, adminPassword).GetAwaiter().GetResult();
				if (!createUserResult.Succeeded)
				{
					throw new Exception($"Failed to create admin user: {adminEmail}");
				}
			}

			var isInRole = userManager.IsInRoleAsync(adminUser, "Admin").GetAwaiter().GetResult();
			if (!isInRole)
			{
				var addRoleResult = userManager.AddToRoleAsync(adminUser, "Admin").GetAwaiter().GetResult();
				if (!addRoleResult.Succeeded)
				{
					throw new Exception($"Failed to assign admin role to user: {adminEmail}");
				}
			}
		}
	}
}
