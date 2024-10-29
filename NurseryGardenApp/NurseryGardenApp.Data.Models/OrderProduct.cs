using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NurseryGardenApp.Data.Models
{
	[PrimaryKey(nameof(OrderId),nameof(ClientId))]
	public class OrderProduct
	{
		[Required]
		[Comment("Order identifier")]
		public Guid OrderId { get; set; }

		[Required]
		[ForeignKey(nameof(OrderId))]
		public Order Order { get; set; } = null!;

		[Required]
		[Comment("Client identifier")]
		public string ClientId { get; set; } = null!;

		[Required]
		[ForeignKey(nameof(ClientId))]
		public ApplicationUser Client { get; set; } = null!;

		[Required]
        public bool IsDeleted { get; set; }
    }
}
