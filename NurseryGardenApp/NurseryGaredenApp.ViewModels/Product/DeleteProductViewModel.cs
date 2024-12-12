namespace NurseryGardenApp.ViewModels.Product
{
	public class DeleteProductViewModel
	{
		public string Id { get; set; } = null!; 
		public string Name { get; set; } = null!; 
		public string Description { get; set; } = null!; 
		public decimal Price { get; set; }
		public string ImageUrl { get; set; } = null!; 
		public string CategoryName { get; set; } = null!; 
		public string? DiscountName { get; set; } 
		public bool IsDeleted { get; set; }
	}
}
