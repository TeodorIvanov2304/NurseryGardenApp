using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static NurseryGardenApp.Common.EntityValidationConstants;

namespace NurseryGardenApp.Data.Models
{
	public class Class
	{
		[Key]
		[Required]
		[Comment("Class identifier")]
        public int Id { get; set; }

		[Required]
		[Comment("Class name")]
		[MaxLength(ClassNameMaxLength)]
		public string Name { get; set; } = null!;
		public virtual ICollection<Category> Categories { get; set; } = new List<Category>();
	}
}