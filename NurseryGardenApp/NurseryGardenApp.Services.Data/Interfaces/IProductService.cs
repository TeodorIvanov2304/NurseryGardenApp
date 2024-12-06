using NurseryGardenApp.ViewModels.Product;

namespace NurseryGardenApp.Services.Data.Interfaces
{
	public interface IProductService
	{
		Task<bool> AddProductAsync(ProductCreateViewModel viewModel);
		Task<IEnumerable<AllProductsIndexViewModel>> GetAllProductsAsync();
		Task<IEnumerable<AllProductsManageViewModel>> GetAllProductsForManageAsync();
		Task<EditProductViewModel?> GetProductForEditByIdAsync(Guid id);
		Task<bool> EditProductAsync(EditProductViewModel viewModel);
		Task<ProductDetailsViewModel?> GetProductDetailsByIdAsync(Guid id);
		Task<DeleteProductViewModel?> GetProductToDeleteByIdAsync(Guid id);
		Task<bool> DeleteProductAsync(Guid id);
	}
}
