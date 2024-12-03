using NurseryGardenApp.ViewModels.Product;

namespace NurseryGardenApp.Services.Data.Interfaces
{
	public interface IProductService
	{
		Task<bool> AddProductAsync(ProductCreateViewModel viewModel);
		Task<IEnumerable<AllProductsIndexViewModel>> GetAllProductsAsync();
	}
}
