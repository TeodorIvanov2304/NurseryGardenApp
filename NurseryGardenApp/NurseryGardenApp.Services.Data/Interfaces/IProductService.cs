using NurseryGardenApp.ViewModels.Product;

namespace NurseryGardenApp.Services.Data.Interfaces
{
	public interface IProductService
	{
		Task<ProductCreateViewModel> GetAddProductCreateAsync();
		Task<bool> AddProductAsync(ProductCreateViewModel viewModel);
		Task<AllProductsSearchFilterModel> GetAllProductsAsync(string? searchQuery = null, string? discount = null, string? category = null);
		Task<IEnumerable<AllProductsManageViewModel>> GetAllProductsForManageAsync();
		Task<EditProductViewModel?> GetProductForEditByIdAsync(Guid id);
		Task<bool> EditProductAsync(EditProductViewModel viewModel);
		Task<ProductDetailsViewModel?> GetProductDetailsByIdAsync(Guid id);
		Task<DeleteProductViewModel?> GetProductToDeleteByIdAsync(Guid id);
		Task<bool> DeleteProductAsync(Guid id);
	}
}
