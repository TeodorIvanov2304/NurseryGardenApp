﻿using Microsoft.EntityFrameworkCore;
using NurseryGardenApp.Data.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static NurseryGardenApp.Common.EntityValidationConstants;

namespace NurseryGardenApp.Data.Models
{
	public class Product
	{
		[Key]
		[Required]
		[Comment("Product identifier")]
		[MaxLength(ProductIdMaxLength)]
        public Guid Id { get; set; }

		[Required]
		[Comment("Product name")]
		[MaxLength(ProductNameMaxLength)]
		public string Name { get; set; } = null!;

		[Required]
		[Comment("Product description")]
		[MaxLength(ProductDescriptionMaxLength)]
		public string Description { get; set; } = null!;

		[Required]
		[Range((double)ProductPriceMinValue, (double)ProductPriceMaxValue)]
        public decimal Price { get; set; }

		[Required]
		[Comment("URL of the image")]
		[MaxLength(ProductUrlMaxLength)]
		public string ImageUrl { get; set; } = null!;

		[Required]
		[Comment("Product quantity")]
		[Range(ProductQuantityMinValue, ProductQuantityMaxValue)]
        public int Quantity { get; set; }

		[Required]
		[Comment("Is product deleted or not")]
        public bool IsDeleted { get; set; }

		[Required]
		[Comment("Product Category identifier")]
        public int CategoryId { get; set; }

		[Required]
		[ForeignKey(nameof(CategoryId))]
		public Category Category { get; set; } = null!;

		[Comment("Discount identifier")]
		public int? DiscountId { get; set; }

		[ForeignKey(nameof(DiscountId))]
		public Discount? Discount { get; set; }

		public virtual ICollection<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();
	}
}
