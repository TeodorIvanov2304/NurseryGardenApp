namespace NurseryGardenApp.Common
{
	public static class EntityValidationConstants
	{
		//Application user
		public const int ApplicationUserFirstNameMinLength = 2;
		public const int ApplicationUserFirstNameMaxLength = 250;
		public const int ApplicationUserLastNameMinLength = 2;
		public const int ApplicationUserLastNameMaxLength = 250;

		//Product
		public const int ProductNameMinLength = 2;
		public const int ProductNameMaxLength = 100;
		public const int ProductDescriptionMinLength = 20;
		public const int ProductDescriptionMaxLength = 500;
		public const int ProductQuantityMinValue = 1;
		public const int ProductQuantityMaxValue = 1000;
		public const decimal ProductPriceMinValue = 0.1m;
		public const decimal ProductPriceMaxValue = 10_000m;

		//Category
		public const int CategoryNameMinLength = 2;
		public const int CategoryNameMaxLength = 50;

		//Class
		public const int ClassNameMinLength = 2;
		public const int ClassNameMaxLength = 50;

		//Discount
		public const int DiscountNameMinLength = 2;
		public const int DiscountNameMaxLength = 50;
		public const decimal DiscountMinValue = 0.0m;
		public const decimal DiscountMaxValue = 100.0m;

		//Order
		public const decimal OrderPriceMinValue = 0.1m;
		public const decimal OrderPriceMaxValue = 10_000m;


		//Date format
		public const string AllDateFormat = "yyyy-MM-dd H:mm";
	}
}
