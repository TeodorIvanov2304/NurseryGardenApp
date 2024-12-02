using NurseryGardenApp.Data.Models;

namespace NurseryGardenApp.Services.Data.Interfaces
{
	public interface ICategoryService
	{
		Task<IEnumerable<Category>> GetAllCategoriesAsync();
	}
}
