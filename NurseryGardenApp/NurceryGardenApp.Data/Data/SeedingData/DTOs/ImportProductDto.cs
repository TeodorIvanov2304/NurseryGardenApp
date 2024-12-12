using System.ComponentModel.DataAnnotations;
using static NurseryGardenApp.Common.EntityValidationConstants;
using static NurseryGardenApp.Common.ErrorMessages;

namespace NurseryGardenApp.Data.Data.SeedingData.DTOs
{
	public class ImportProductDto
	{
		[Required]
		[MinLength(ProductIdMinLength)]
		[MaxLength(ProductIdMaxLength)]
		public Guid Id { get; set; }

		[Required]
		[MinLength(ProductNameMinLength)]
		[MaxLength(ProductNameMaxLength)]
		public string Name { get; set; } = null!;

		[Required]
		[MinLength(ProductNameMinLength)]
		[MaxLength(ProductNameMaxLength)]
        public string Description { get; set; } = null!;

        [Required]
        public decimal Price { get; set; }

		[Required]
		[MaxLength(ProductUrlMaxLength)]
		public string ImageUrl { get; set; } = null!;

		[Required]
		[Range(ProductQuantityMinValue, ProductQuantityMaxValue)]
		public int Quantity { get; set; }

		[Required]
		public bool IsDeleted { get; set; }

		[Required]
		[Range(1, int.MaxValue, ErrorMessage = CategoryIdCannotBeNegative)]
		public int CategoryId { get; set; }

		[Range(DiscountIdMinValue, int.MaxValue, ErrorMessage = DiscountIdCannotBeNegative)]
		public int? DiscountId { get; set; }
	}
}
