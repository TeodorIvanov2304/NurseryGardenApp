using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static NurseryGardenApp.Common.EntityValidationConstants;

namespace NurseryGardenApp.Data.Models
{
	public class Category
	{
		[Key]
		[Required]
		[Comment("Category identifier")]
        public int Id { get; set; }

		[Required]
		[Comment("Category name")]
		[MaxLength(CategoryNameMaxLength)]
		public string Name { get; set; } = null!;
		[Comment("Is category deleted or not")]
		public bool IsDeleted { get; set; }

		[Comment("Class identifier")]
        public int? ClassId { get; set; }

		[ForeignKey(nameof(ClassId))]
        public Class? Class { get; set; }
		public virtual ICollection<Product> Products { get; set; } = new List<Product>();
	}
}