using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using static NurseryGardenApp.Common.EntityValidationConstants;
using static NurseryGardenApp.Common.ErrorMessages;

namespace NurseryGardenApp.ViewModels.Category
{
	public class CategoryCreateViewModel
	{
		[Required]
		[MinLength(CategoryNameMinLength, ErrorMessage = CategoryNameMinLengthErrorMessage)]
		[MaxLength(CategoryNameMaxLength,ErrorMessage = CategoryNameMaxLengthErrorMessage)]
		public string Name { get; set; } = null!;

		public int? ClassId { get; set; }

		public List<SelectListItem> Classes { get; set; } = new List<SelectListItem>();
	}
}
