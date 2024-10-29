using Microsoft.EntityFrameworkCore;
using NurseryGardenApp.Data.Models;
using System.ComponentModel.DataAnnotations;
using static NurseryGardenApp.Common.EntityValidationConstants;

namespace NurseryGardenApp.Data.Data.Models
{
	public class Discount
	{
		[Key]
		[Required]
        public int Id { get; set; }

		[Required]
		[Comment("Discount name")]
		[MaxLength(DiscountNameMaxLength)]
		public string Name { get; set; } = null!;

		[Required]
		[Comment("Discount value")]
		[Range((double)DiscountMinValue,(double)DiscountMaxValue)]
        public decimal DiscountValue { get; set; }

		[Required]
		[Comment("Discount period start date")]
        public DateTime StartDate { get; set; }

		[Required]
		[Comment("Discount period end date")]
		public DateTime EndDate { get; set; }
		public virtual ICollection<Product> Products { get; set; } = new List<Product>();
	}
}
