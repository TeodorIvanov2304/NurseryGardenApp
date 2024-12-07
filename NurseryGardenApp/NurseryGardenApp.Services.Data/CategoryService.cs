﻿using Microsoft.AspNetCore.Mvc.Rendering;
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
		private readonly IClassService _classService;

        public CategoryService(IRepository<Category, int> repository, IRepository<Class, int> classRepository, IClassService classService)
        {
			this._categoryRepository = repository;
			this._classRepository = classRepository;
			this._classService = classService;
            
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

		public async Task<EditCategoryViewModel?> GetCategoryForEditByIdAsync(int? id)
		{
			Category? category = await this._categoryRepository
				.GetAllAttached()
				.FirstOrDefaultAsync(c => c.Id == id);

			if (category == null)
			{
				return null;
			}

			EditCategoryViewModel modelForEdit = new EditCategoryViewModel
			{
				Id = category.Id,
				Name = category.Name,
				ClassId = category.ClassId,
				ClassName = category?.Class?.Name
			};
			var classes = await this._classService.GetAllClassesAsync();
			modelForEdit.Classes = classes.Select(c => new SelectListItem
			{
				Value = c.Id.ToString(),
				Text = c.Name,
				Selected = modelForEdit.ClassId == c.Id
			});

			return modelForEdit;
		}

		public async Task<bool> EditCategoryAsync(EditCategoryViewModel model)
		{	

			Category? categoryForEdit = await this._categoryRepository
				                        .GetAllAttached()
										.FirstOrDefaultAsync(c => c.Id == model.Id);

			if (categoryForEdit == null)
			{
				return false;
			}

			categoryForEdit.Id = model.Id;
			categoryForEdit.Name = model.Name;
			categoryForEdit.ClassId = model.ClassId;

			await this._categoryRepository.SaveChangesAsync();

			return true;
		}

		public async Task<bool> DoesCategoryExistAsync(int id)
		{
			return await this._categoryRepository.GetAllAttached().AnyAsync(c => c.Id == id);
		}
	}
}
