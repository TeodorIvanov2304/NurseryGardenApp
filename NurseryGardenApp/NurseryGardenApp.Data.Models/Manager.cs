using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static NurseryGardenApp.Common.EntityValidationConstants;

namespace NurseryGardenApp.Data.Models
{
	public class Manager
	{
		[Key]
		[Required]
		public Guid Id { get; set; }

		[Required]
		[ForeignKey(nameof(User))]
		public string UserId { get; set; } = null!;

		[Required]
		[MinLength(ManagerWorkPhoneNumberMinValue)]
		[MaxLength(ManagerWorkPhoneNumberMaxValue)]
		[Phone]
		public string WorkPhoneNumber { get; set; } = null!;

		public virtual ApplicationUser User { get; set; } = null!;

		[Required]
		[MinLength(DepartmentNameMinValue)]
		[MaxLength(DepartmentNameMaxValue)]
		public string Department { get; set; } = null!;

		public DateTime CreatedAt { get; set; } = DateTime.UtcNow; 
	}
}
