using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using static NurseryGardenApp.Common.EntityValidationConstants;
namespace NurseryGardenApp.ViewModels.Category
{
	public class EditCategoryViewModel
	{
		[Required]
		public int Id { get; set; }

		[Required]
		[MinLength(CategoryNameMinLength, ErrorMessage = "Category name is required and must be more than 2 characters.")]
		[MaxLength(CategoryNameMaxLength, ErrorMessage = "Category name is required and must be less than 50 characters.")]
		public string Name { get; set; } = null!;

		public int? ClassId { get; set; }
		public string? ClassName { get; set; }
		public virtual IEnumerable<SelectListItem>? Classes { get; set; } 
	}
}
