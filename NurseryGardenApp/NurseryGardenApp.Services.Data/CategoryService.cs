using Microsoft.EntityFrameworkCore;
using NurseryGardenApp.Data.Data.Repositories.Interfaces;
using NurseryGardenApp.Data.Models;
using NurseryGardenApp.Services.Data.Interfaces;
using NurseryGardenApp.ViewModels.Category;

namespace NurseryGardenApp.Services.Data
{
	public class CategoryService : ICategoryService
	{	
		private readonly IRepository<Category, int> _repository;


        public CategoryService(IRepository<Category, int> repository)
        {
			this._repository = repository;
            
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
		{
			return await _repository.GetAllAsync();
		}

		public async Task<IEnumerable<AllCategoriesIndexViewModel>> GetAllCategoriesIndexAsync()
		{
			List<AllCategoriesIndexViewModel> allCategories = await this._repository
				.GetAllAttached()
				.Select(c => new AllCategoriesIndexViewModel
				{
					Id = c.Id,
					Name = c.Name,
					ClassId = c.ClassId,
					ClassName = c.Class.Name ?? "No class"
				})
				.ToListAsync();

			return allCategories;
		}
	}
}
