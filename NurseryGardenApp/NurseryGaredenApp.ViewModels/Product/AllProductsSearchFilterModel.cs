namespace NurseryGardenApp.ViewModels.Product
{
	public class AllProductsSearchFilterModel
	{
		public IEnumerable<AllProductsIndexViewModel>? Products { get; set; }
        public string? SearchQuery { get; set; }
        public string? DiscountFilter { get; set; }
		public IEnumerable<string>? AllDiscounts { get; set; }
        public string? CategoryFilter { get; set; }
		public IEnumerable<string>? AllCategories { get; set; }
	}
}
