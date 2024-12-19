namespace NurseryGardenApp.Common
{
	public static class ErrorMessages
	{

		//Database seeder
		public const string FailedToCreateRoleException = "Failed to create role:";
		public const string AdminEmailOrPasswordException = "Admin email or password is not configured properly.";
		public const string FailedToCreateAdminException = "Failed to create admin user:";
		public const string FailedToAssignAdminRoleException = "Failed to assign admin role to user:";

		//Repository
		public const string NameCannotBeEmptyException = "Name cannot be null or empty.";

		//DTO
		public const string CategoryIdCannotBeNegative = "Category ID must be greater than 0.";
		public const string DiscountIdCannotBeNegative = "Discount ID must be greater than 0.";

		public const string DtoProductQuantityMinAndMaxValueErrorMessage = "Quantity must be at least 1 and no more than 100";
		//Services
		public const string ProductServiceUnknownCategoryValue = "Unknown Category";
		public const string ProductServiceNoDiscountValue = "No Discount";
		public const string CategoryServiceNoClassValue = "No class";

		//Controllers
		public const string CannotAddCategoryErrorMessage = "Unable to add category. Please try again.";
		public const string InvalidCategoryIdErrorMessage = "Invalid Category Id";
		public const string CategoryNotFound = "Category not found.";
		public const string FailedToUpdateProductErrorMessage = "Failed to update the product.";
		public const string InvalidCategoryErrorMessage = "Invalid Category";
		public const string UnableToDeleteCategoryErrorMessage = "Unable to delete the category. Please try again later.";

		public const string UnableToAddProductErrorMessage = "Unable to add product. Please try again.";
		public const string InvalidProductIdErrorMessage = "Invalid Product Id";
		public const string ProductNotFoundErrorMessage = "Product not found.";
		public const string UnableToUpdateProductErrorMessage = "Failed to update the product.";
		public const string InvalidProductErrorMessage = "Invalid Product.";
		public const string UnableToDeleteProductErrorMessage = "Unable to delete the product. Please try again later.";

		public const string InvalidUserIdErrorMessage = "Invalid UserId";
		public const string FailedToCreateOrderErrorMessage = "Failed to create order.";

		//API Controller
		public const string OrderProductNotFound = "Order product not found or invalid input.";
		public const string ProductQuantityUpdatedSuccessfully = "Quantity updated successfully.";

		//ViewModels and Models
		public const string CategoryNameMinLengthErrorMessage = "Category name is required and must be more than 2 characters.";
		public const string CategoryNameMaxLengthErrorMessage = "Category name is required and must be less than 50 characters.";

		public const string ProductNameMinLengthErrorMessage = "The name must be at least 2 characters";
		public const string ProductNameMaxLengthErrorMessage = "The name must be less than 100 characters.";
		public const string ProductDescriptionMinLengthErrorMessage = "The description must be at least 20 characters";
		public const string ProductDescriptionMaxLengthErrorMessage = "The description must be less than 500 characters.";
		public const string ProductPriceMinAndMaxValueErrorMessage = "The price must be between 0.01 and 10,000.";
		public const string ProductUrlMinLengthErrorMessage = "The URL must be less than 500 characters.";
		public const string ProductUrlMaxLengthErrorMessage = "The URL must be less than 500 characters.";
		public const string ProductUrlAttributeErrorMessage = "Please enter a valid URL.";
		public const string ProductQuantityMinAndMaxValueErrorMessage = "The quantity must be between 1 and 1,000.";
	}
}
