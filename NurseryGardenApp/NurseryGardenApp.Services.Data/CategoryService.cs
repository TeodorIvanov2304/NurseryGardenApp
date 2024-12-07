using Microsoft.AspNetCore.Mvc.Rendering;
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
		private readonly IRepository<Class, int> _classRepository;

        public CategoryService(IRepository<Category, int> repository, IRepository<Class, int> classRepository)
        {
			this._repository = repository;
			this._classRepository = classRepository;
            
        }

		public async Task<CategoryCreateViewModel> GetAddCategoryAsync()
		{
			var model = new CategoryCreateViewModel
			{
				Classes = await this._classRepository.GetAllAttached().Select(c => new SelectListItem
				{
					Value = c.Id.ToString(),
					Text = c.Name
				}).ToListAsync()
			};

			return model;
		}

		public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
		{
			return await _repository.GetAllAsync();
		}

		public async Task<IEnumerable<AllCategoriesIndexViewModel>> GetAllCategoriesForManageAsync()
		{
			var categoriesForManage = await this._repository
				.GetAllAttached()
				.AsNoTracking()
				.Select(c => new AllCategoriesIndexViewModel
				{
					Id = c.Id,
					Name = c.Name,
					ClassId = c.ClassId,
					ClassName = c.Class!.Name ?? "No class"
				})
				.ToListAsync();

			return categoriesForManage;
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
					ClassName = c.Class!.Name ?? "No class"
				})
				.ToListAsync();

			return allCategories;
		}
	}
}
