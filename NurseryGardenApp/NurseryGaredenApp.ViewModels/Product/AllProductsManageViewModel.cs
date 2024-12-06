namespace NurseryGardenApp.ViewModels.Product
{
	public class AllProductsManageViewModel
	{
		public string Id { get; set; } = null!;
		public string Name { get; set; } = null!;
		public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string ImageURL { get; set; } = null!;
		public string CategoryName { get; set; } = null!;
	}
}
