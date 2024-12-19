using System.ComponentModel.DataAnnotations;
using static NurseryGardenApp.Common.EntityValidationConstants;
using static NurseryGardenApp.Common.ErrorMessages;

namespace NurseryGardenApp.Web.WebAPI.DTOs
{
	public class UpdateQuantityDto
	{
		[Required]
		public Guid OrderId { get; set; }
		[Required]
		public Guid ProductId { get; set; }

		[Range(ProductQuantityMinValue, ProductQuantityMaxValue,ErrorMessage = DtoProductQuantityMinAndMaxValueErrorMessage)]
		public int Quantity { get; set; }
	}
}
