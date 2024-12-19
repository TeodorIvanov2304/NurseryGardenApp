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
        public int Quantity { get; set; }
        public List<string> ProductNames { get; set; } = new List<string>();
		public List<OrderProductViewModel> OrderProducts { get; set; } = new ();
	}
}
