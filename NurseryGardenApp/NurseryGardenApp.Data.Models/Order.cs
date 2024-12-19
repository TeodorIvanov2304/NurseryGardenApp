using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static NurseryGardenApp.Common.EntityValidationConstants;

namespace NurseryGardenApp.Data.Models
{
	public class Order
	{
		[Key]
		[Required]
		[Comment("Order unique identifier")]
		public Guid Id { get; set; }

		[Required]
		[Comment("Date of the order")]
		public DateTime OrderDate { get; set; }

		[Required]
		[Comment("Total price of the order")]
		[Range((double)OrderPriceMinValue,(double)OrderPriceMaxValue)]
		public decimal Price { get; set; }

		[Required]
		[Comment("Client identifier")]
		public string ClientId { get; set; } = null!;

		[Required]
		[ForeignKey(nameof(ClientId))]
		public ApplicationUser Client { get; set; } = null!;

		[Required]
		[Comment("Is this order deleted?")]
		public bool IsDeleted { get; set; }
		public virtual ICollection<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();
	}
}