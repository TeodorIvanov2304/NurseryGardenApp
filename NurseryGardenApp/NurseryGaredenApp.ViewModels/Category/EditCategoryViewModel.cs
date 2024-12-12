using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using static NurseryGardenApp.Common.EntityValidationConstants;
using static NurseryGardenApp.Common.ErrorMessages;

namespace NurseryGardenApp.ViewModels.Category
{
	public class EditCategoryViewModel
	{
		[Required]
		public int Id { get; set; }

		[Required]
		[MinLength(CategoryNameMinLength, ErrorMessage = CategoryNameMinLengthErrorMessage)]
		[MaxLength(CategoryNameMaxLength, ErrorMessage = CategoryNameMaxLengthErrorMessage)]
		public string Name { get; set; } = null!;
		public int? ClassId { get; set; }
		public string? ClassName { get; set; }
		public virtual IEnumerable<SelectListItem>? Classes { get; set; } 
	}
}
