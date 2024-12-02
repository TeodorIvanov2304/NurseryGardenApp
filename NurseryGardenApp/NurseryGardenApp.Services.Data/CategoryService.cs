using NurseryGardenApp.Data.Data.Repositories.Interfaces;
using NurseryGardenApp.Data.Models;
using NurseryGardenApp.Services.Data.Interfaces;

namespace NurseryGardenApp.Services.Data
{
	public class CategoryService : ICategoryService
	{	
		private readonly IRepository<Category, int> _repository;


        public CategoryService(IRepository<Category, int> repository)
        {
			_repository = repository;
            
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
		{
			return await _repository.GetAllAsync();
		}
	}
}
