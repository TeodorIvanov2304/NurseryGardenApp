using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using static NurseryGardenApp.Common.EntityValidationConstants;
using static NurseryGardenApp.Common.ErrorMessages;

namespace NurseryGardenApp.ViewModels.Product
{
	public class ProductCreateViewModel
	{
		[Required]
		[MinLength(ProductNameMinLength, ErrorMessage = ProductNameMinLengthErrorMessage)]
		[MaxLength(ProductNameMaxLength, ErrorMessage = ProductNameMaxLengthErrorMessage)]

		public string Name { get; set; } = null!;

		[Required]
		[MinLength(ProductDescriptionMinLength, ErrorMessage = ProductDescriptionMinLengthErrorMessage)]
		[MaxLength(ProductDescriptionMaxLength, ErrorMessage = ProductDescriptionMaxLengthErrorMessage)]
		public string Description { get; set; } = null!;

		[Required]
		[Range((double)ProductPriceMinValue, (double)ProductPriceMaxValue, ErrorMessage = ProductPriceMinAndMaxValueErrorMessage)]
		public decimal Price { get; set; }

		[Required]
		[MinLength(ProductUrlMinLength, ErrorMessage = ProductUrlMinLengthErrorMessage)]
		[MaxLength(ProductUrlMaxLength, ErrorMessage = ProductUrlMaxLengthErrorMessage)]
		[Url(ErrorMessage = ProductUrlAttributeErrorMessage)]
		public string ImageUrl { get; set; } = null!;

		[Required]
		[Range(ProductQuantityMinValue, ProductQuantityMaxValue, ErrorMessage = ProductQuantityMinAndMaxValueErrorMessage)]
		public int Quantity { get; set; }

		[Required]
		public int CategoryId { get; set; }

		public int? DiscountId { get; set; }

		public IEnumerable<SelectListItem> Categories { get; set; } = new List<SelectListItem>();
		public IEnumerable<SelectListItem> Discounts { get; set; } = new List<SelectListItem>();
	}
}
