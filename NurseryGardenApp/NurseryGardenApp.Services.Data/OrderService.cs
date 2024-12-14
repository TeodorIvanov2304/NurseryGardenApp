using Microsoft.EntityFrameworkCore;
using NurseryGardenApp.Data.Data.Repositories.Interfaces;
using NurseryGardenApp.Data.Models;
using NurseryGardenApp.Services.Data.Interfaces;
using NurseryGardenApp.ViewModels.Order;

namespace NurseryGardenApp.Services.Data
{
	public class OrderService : IOrderService
	{	
		private readonly IRepository<Order,Guid> _orderRepository;
		private readonly IRepository<Product,Guid> _productRepository;

        public OrderService(IRepository<Order, Guid> orderRepository, IRepository<Product, Guid> productRepository)
        {
            this._orderRepository = orderRepository;
			this._productRepository = productRepository;
        }

		public async Task<bool> CreateOrderAsync(Guid clientGuid, Guid productGuid)
		{

			Product? product = await this._productRepository.GetByIdAsync(productGuid);

			if (product == null)
			{
				return false;
			}

			decimal price = product.Discount?.DiscountValue != null
						? product.Price * (1 - product.Discount.DiscountValue / 100)
						: product.Price;


			bool orderExists = await this._orderRepository
				.GetAllAttached()
				.AnyAsync(o => o.ClientId == clientGuid.ToString()
				&& o.OrderProducts.Any(op => op.ProductId == productGuid));

			if (orderExists)
			{
				return false;
			}

			var orderId = Guid.NewGuid();

			Order order = new Order() 
			{
				Id = orderId,
				OrderDate = DateTime.UtcNow,
				ClientId = clientGuid.ToString(),
				Price = price,
				OrderProducts = new List<OrderProduct>()
				{
					new OrderProduct
					{
						OrderId = orderId,
						ProductId = productGuid,
					}
				}
			};

			await this._orderRepository.AddAsync(order);
			await this._orderRepository.SaveChangesAsync();

			return true;
		}

		public async Task<IEnumerable<OrderViewModel>> GetOrdersByClientIdAsync(Guid clientGuid)
		{
			var orders = await this._orderRepository
				.GetAllAttached()
				.Where(o => o.ClientId == clientGuid.ToString())
				.Select(o => new OrderViewModel
				{
					Id = o.Id,
					Picture = o.OrderProducts.Select(p => p.Product.ImageUrl).First(),
					OrderDate = o.OrderDate,
					Price = o.Price,
					ClientName = o.Client.FirstName!,
					ProductNames = o.OrderProducts.Select(op => op.Product.Name).ToList()
				}).ToListAsync();

			return orders;
		}
	}
}
