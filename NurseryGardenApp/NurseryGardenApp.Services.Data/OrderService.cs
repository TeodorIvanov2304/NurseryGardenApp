using Microsoft.EntityFrameworkCore;
using NurseryGardenApp.Data.Data.Repositories.Interfaces;
using NurseryGardenApp.Data.Models;
using NurseryGardenApp.Services.Data.Interfaces;
using NurseryGardenApp.ViewModels.Order;
using NurseryGardenApp.Web.WebAPI.DTOs;

namespace NurseryGardenApp.Services.Data
{
	public class OrderService : IOrderService
	{
		private readonly IRepository<Order, Guid> _orderRepository;
		private readonly IRepository<Product, Guid> _productRepository;

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

		public decimal GetAllPrices(IEnumerable<OrderViewModel> orders)
		{
			decimal prices = 0;

			foreach (var price in orders.Select(o => o.Price))
			{
				prices += price;
			}

			return prices;

		}

		public async Task<IEnumerable<OrderViewModel>> GetOrdersByClientIdAsync(Guid clientGuid)
		{


			List<OrderViewModel> orders = await _orderRepository
			   .GetAllAttached()
			   .Where(o => o.ClientId == clientGuid.ToString() && o.IsDeleted == false)
			   .Select(o => new OrderViewModel
			   {
				   Id = o.Id,
				   Picture = o.OrderProducts.Select(op => op.Product.ImageUrl).FirstOrDefault(),
				   OrderDate = o.OrderDate,
				   Price = o.Price,
				   ClientName = o.Client.FirstName,
				   TotalPrice = o.OrderProducts.Sum(op => op.Quantity * op.Product.Price),
				   OrderProducts = o.OrderProducts
					   .Select(op => new OrderProductViewModel
					   {
						   ProductId = op.ProductId,
						   Quantity = op.Quantity
					   })
					   .ToList(),
				   ProductNames = o.OrderProducts.Select(op => op.Product.Name).ToList()
			   })
			   .ToListAsync();

			
			return orders;
		}

		public async Task<bool> UpdateOrderProductQuantityAsync(UpdateQuantityDto updateDto)
		{

			var orderProduct = await _orderRepository
				 .GetAllAttached()
			     .SelectMany(order => order.OrderProducts)
				 .Include(o => o.Order)
				 .Include(p => p.Product)
				 .Where(order => order.IsDeleted == false)
			     .FirstOrDefaultAsync(op => op.OrderId == updateDto.OrderId && op.ProductId == updateDto.ProductId);

			if (orderProduct == null)
			{
				return false;
			}

			if (orderProduct.Product == null || orderProduct.Order == null )
			{
				return false;
			}

			orderProduct.Order.Price = orderProduct.Order.OrderProducts
				.Where(op => op.IsDeleted == false)
				.Sum(op => op.Quantity * op.Product.Price);

			orderProduct.Quantity = updateDto.Quantity;

			await _orderRepository.SaveChangesAsync();

			return true;
		}
	}
}
