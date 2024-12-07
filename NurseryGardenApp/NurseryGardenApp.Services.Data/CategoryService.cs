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
		private readonly IRepository<Category, int> _categoryRepository;
		private readonly IRepository<Class, int> _classRepository;

        public CategoryService(IRepository<Category, int> repository, IRepository<Class, int> classRepository)
        {
			this._categoryRepository = repository;
			this._classRepository = classRepository;
            
        }

		public async Task<bool> AddCategoryAsync(CategoryCreateViewModel viewModel)
		{
			if (viewModel == null)
			{
				return false;
			}

			if (await _classRepository.FindByNameAsync(viewModel.Name))
			{
				return false;
			}
			
			Category category = new Category 
			{ 
				Name = viewModel.Name,
				ClassId = viewModel.ClassId,
			};

			await this._categoryRepository.AddAsync(category);
			await this._categoryRepository.SaveChangesAsync();

			return true;

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
			return await _categoryRepository.GetAllAsync();
		}

		public async Task<IEnumerable<AllCategoriesIndexViewModel>> GetAllCategoriesForManageAsync()
		{
			var categoriesForManage = await this._categoryRepository
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
			List<AllCategoriesIndexViewModel> allCategories = await this._categoryRepository
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
