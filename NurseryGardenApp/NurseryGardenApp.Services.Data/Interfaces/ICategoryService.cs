using NurseryGardenApp.Data.Models;
using NurseryGardenApp.ViewModels.Category;

namespace NurseryGardenApp.Services.Data.Interfaces
{
	public interface ICategoryService
	{
		Task<IEnumerable<Category>> GetAllCategoriesAsync();
		Task<IEnumerable<AllCategoriesIndexViewModel>> GetAllCategoriesIndexAsync();
	}
}
