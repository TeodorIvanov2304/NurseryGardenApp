using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using static NurseryGardenApp.Common.EntityValidationConstants;
namespace NurseryGardenApp.ViewModels.Product
{
	public class ProductCreateViewModel
	{
		[Required]
		[MinLength(ProductNameMinLength, ErrorMessage = "The name must be less than 100 characters.")]
		[MaxLength(ProductNameMaxLength,ErrorMessage ="The name must be at least 2 characters")]

		public string Name { get; set; } = null!;

		[Required]
		[MinLength(ProductDescriptionMinLength,ErrorMessage = "The description must be at least 20 characters")]
		[MaxLength(ProductDescriptionMaxLength,ErrorMessage = "The description must be less than 500 characters.")]
		public string Description { get; set; } = null!;

		[Required]
		[Range(0.01, 10000, ErrorMessage = "The price must be between 0.01 and 10,000.")]
		public decimal Price { get; set; }

		[Required]
		[MaxLength(ProductUrlMaxLength,ErrorMessage = "The URL must be less than 500 characters.")]
		[Url(ErrorMessage = "Please enter a valid URL.")]
		public string ImageUrl { get; set; } = null!;

		[Required]
		[Range(ProductQuantityMinValue, ProductQuantityMaxValue, ErrorMessage = "The quantity must be between 1 and 1,000.")]
		public int Quantity { get; set; }

		[Required]
		public int CategoryId { get; set; }

		public int? DiscountId { get; set; }

		public IEnumerable<SelectListItem> Categories { get; set; } = new List<SelectListItem>();
		public IEnumerable<SelectListItem> Discounts { get; set; } = new List<SelectListItem>();
	}
}
