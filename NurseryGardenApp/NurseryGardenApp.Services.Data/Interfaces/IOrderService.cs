using NurseryGardenApp.ViewModels.Order;
using NurseryGardenApp.Web.WebAPI.DTOs;


namespace NurseryGardenApp.Services.Data.Interfaces
{
	public interface IOrderService
	{
		Task<IEnumerable<OrderViewModel>> GetOrdersByClientIdAsync(Guid clientGuid);
		Task<bool> CreateOrderAsync(Guid clientGuid, Guid productGuid);
		decimal GetAllPrices(IEnumerable<OrderViewModel> orders);
		Task<bool> UpdateOrderProductQuantityAsync(UpdateQuantityDto updateDto);
	}
}
