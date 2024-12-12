using NurseryGardenApp.Data.Data.Models;

namespace NurseryGardenApp.Services.Data.Interfaces
{
	public interface IDiscountService
	{
		Task<IEnumerable<Discount>> GetAllDiscountsAsync();
	}
}
