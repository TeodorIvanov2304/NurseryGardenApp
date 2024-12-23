﻿namespace NurseryGardenApp.ViewModels.Product
{
	public class ProductDetailsViewModel
	{
		public string Id { get; set; } = null!;
		public string ProductName { get; set; } = null!;
        public string Description { get; set; } = null!;
		public decimal Price { get; set; }
		public string ImageURL { get; set; } = null!;
		public string CategoryName { get; set; } = null!;
		public string? DiscountName { get; set; }
	}
}
