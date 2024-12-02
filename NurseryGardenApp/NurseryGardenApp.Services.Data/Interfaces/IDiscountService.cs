using NurseryGardenApp.Data.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurseryGardenApp.Services.Data.Interfaces
{
	public interface IDiscountService
	{
		Task<IEnumerable<Discount>> GetAllDiscountsAsync();
	}
}
