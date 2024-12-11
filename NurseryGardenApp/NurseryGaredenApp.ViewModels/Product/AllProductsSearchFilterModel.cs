using Microsoft.AspNetCore.Mvc.Rendering;

namespace NurseryGardenApp.ViewModels.Product
{
	public class AllProductsSearchFilterModel
	{
		public IEnumerable<AllProductsIndexViewModel>? Products { get; set; }

		public string? SearchQuery { get; set; }
		public string? SelectedDiscount { get; set; }
		public string? SelectedCategory { get; set; }
		public IEnumerable<SelectListItem>? Categories { get; set; } = new List<SelectListItem>();
		public IEnumerable<SelectListItem>? Discounts { get; set; } = new List<SelectListItem> ();
	}
}
