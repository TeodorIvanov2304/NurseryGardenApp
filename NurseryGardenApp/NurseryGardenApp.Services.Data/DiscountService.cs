using NurseryGardenApp.Data.Data.Models;
using NurseryGardenApp.Data.Data.Repositories.Interfaces;
using NurseryGardenApp.Services.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurseryGardenApp.Services.Data
{
	public class DiscountService : IDiscountService
	{	
		private readonly IRepository<Discount, int> _discountRepository;

        public DiscountService(IRepository<Discount, int> discountRepository)
        {
            this._discountRepository = discountRepository;
        }

        public async Task<IEnumerable<Discount>> GetAllDiscountsAsync()
		{
			return await this._discountRepository.GetAllAsync();
		}
	}
}
