using NurseryGardenApp.ViewModels.Order;

namespace NurseryGardenApp.Services.Data.Interfaces
{
	public interface IOrderService
	{
		Task<IEnumerable<OrderViewModel>> GetOrdersByClientIdAsync(Guid clientGuid);
		Task<bool> CreateOrderAsync(Guid clientGuid, Guid productGuid);
		decimal GetAllPrices(IEnumerable<OrderViewModel> orders);
	}
}
