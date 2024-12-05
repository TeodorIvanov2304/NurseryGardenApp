using Microsoft.EntityFrameworkCore;
using NurseryGardenApp.Data.Data.Repositories.Interfaces;
using NurseryGardenApp.Data.Models;
using NurseryGardenApp.Services.Data.Interfaces;

namespace NurseryGardenApp.Services.Data
{
	public class ManagerService : IManagerService
	{
		private readonly IRepository<Manager, Guid> _managerRepository;

        public ManagerService(IRepository<Manager, Guid> managerRepository)
        {
			this._managerRepository = managerRepository;            
        }

		public async Task<bool> IsUserManagerAsync(string? userId)
		{
			if (String.IsNullOrWhiteSpace(userId))
			{
				return false;
			}

			bool result = await this._managerRepository
							  .GetAllAttached()
							  .AnyAsync(m => m.UserId.ToString().ToLower() == userId);

			return result;
		}
	}
}
