using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static NurseryGardenApp.Common.EntityValidationConstants;

namespace NurseryGardenApp.Data.Models
{
	[PrimaryKey(nameof(OrderId), nameof(ProductId))]
	public class OrderProduct
	{
		[Required]
		[Comment("Order identifier")]
		public Guid OrderId { get; set; }

		[ForeignKey(nameof(OrderId))]
		public Order Order { get; set; } = null!;

		[Required]
		[Comment("Product identifier")]
		public Guid ProductId { get; set; }

		[ForeignKey(nameof(ProductId))]
		public Product Product { get; set; } = null!;

		[Required]
		[Range(ProductQuantityMinValue, ProductQuantityMaxValue)] 
		[Comment("Quantity of the product in the order")]
		public int Quantity { get; set; } 

		[Comment("Is deleted flag")]
		public bool IsDeleted { get; set; }
	}
}
