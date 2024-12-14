namespace NurseryGardenApp.ViewModels.Order
{
	public class OrderViewModel
	{
		public Guid Id { get; set; }
		public string Picture { get; set; } = null!;
        public DateTime OrderDate { get; set; }
		public decimal Price { get; set; }
		public string ClientName { get; set; } = null!;
        public decimal TotalPrice { get; set; }
        public IEnumerable<string> ProductNames { get; set; } = new List<string>();
	}
}
