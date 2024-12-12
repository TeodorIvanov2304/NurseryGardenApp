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
		public const int ProductIdMinLength = 10;
		public const int ProductIdMaxLength = 10;
		public const int ProductNameMinLength = 2;
		public const int ProductNameMaxLength = 100;
		public const int ProductDescriptionMinLength = 20;
		public const int ProductDescriptionMaxLength = 500;
		public const int ProductQuantityMinValue = 1;
		public const int ProductQuantityMaxValue = 1000;
		public const decimal ProductPriceMinValue = 0.1m;
		public const decimal ProductPriceMaxValue = 10_000m;
		public const int ProductUrlMinLength = 1;
		public const int ProductUrlMaxLength = 500;

		//Category
		public const int CategoryNameMinLength = 2;
		public const int CategoryNameMaxLength = 50;
		public const int CategoryIdMinValue = 1;

		//Class
		public const int ClassNameMinLength = 2;
		public const int ClassNameMaxLength = 50;

		//Discount
		public const int DiscountIdMinValue = 1;
		public const int DiscountNameMinLength = 2;
		public const int DiscountNameMaxLength = 50;
		public const decimal DiscountMinValue = 0.0m;
		public const decimal DiscountMaxValue = 100.0m;

		//Order
		public const decimal OrderPriceMinValue = 0.1m;
		public const decimal OrderPriceMaxValue = 10_000m;


		//Manager
		public const int ManagerWorkPhoneNumberMinValue = 3;
		public const int ManagerWorkPhoneNumberMaxValue = 20;
		public const int DepartmentNameMinValue = 2;
		public const int DepartmentNameMaxValue = 50;

		//Date format
		public const string AllDateFormat = "yyyy-MM-dd H:mm";
	}
}
