using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

	}
}
