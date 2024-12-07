using NurseryGardenApp.Data.Data.Repositories.Interfaces;
using NurseryGardenApp.Data.Models;
using NurseryGardenApp.Services.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurseryGardenApp.Services.Data
{
	public class ClassService : IClassService
	{
		private readonly IRepository<Class, int> _classRepository;

        public ClassService(IRepository<Class, int> classRepository)
        {
            this._classRepository = classRepository;
        }
        public async Task<IEnumerable<Class>> GetAllClassesAsync()
		{
			return await this._classRepository.GetAllAsync();
		}
	}
}
