using NurseryGardenApp.Data.Models;
using NurseryGardenApp.ViewModels.Category;

namespace NurseryGardenApp.Services.Data.Interfaces
{
	public interface ICategoryService
	{
		Task<IEnumerable<Category>> GetAllCategoriesAsync();
		Task<IEnumerable<AllCategoriesIndexViewModel>> GetAllCategoriesIndexAsync();
		Task<IEnumerable<AllCategoriesIndexViewModel>> GetAllCategoriesForManageAsync();
		Task<CategoryCreateViewModel> GetAddCategoryAsync();
		Task<bool> AddCategoryAsync(CategoryCreateViewModel viewModel);
		Task<EditCategoryViewModel?> GetCategoryForEditByIdAsync(int? id);
		Task<bool> EditCategoryAsync(EditCategoryViewModel model);
		Task<bool> DoesCategoryExistAsync(int id);
	}
}
