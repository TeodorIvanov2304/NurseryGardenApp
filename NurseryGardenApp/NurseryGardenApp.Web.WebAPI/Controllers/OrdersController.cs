using Microsoft.AspNetCore.Mvc;
using NurseryGardenApp.Services.Data.Interfaces;
using NurseryGardenApp.Web.WebAPI.DTOs;
using static NurseryGardenApp.Common.ErrorMessages;

namespace NurseryGardenApp.Web.WebAPI.Controllers
{
	[ApiController]
	[Route("[controller]/")]
	public class OrdersController : ControllerBase
	{
		private readonly IOrderService _orderService;

		public OrdersController(IOrderService orderService)
		{
			this._orderService = orderService;
		}

		[HttpPost("update-quantity")]
        public async Task<IActionResult> UpdateQuantity([FromBody] UpdateQuantityDto dto)
		{	

			Console.WriteLine("Reached UpdateQuantity API");
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			bool isUpdated = await _orderService.UpdateOrderProductQuantityAsync(dto);

			if (!isUpdated)
			{
				return BadRequest(new { message = OrderProductNotFound });
			}

			return Ok(new { message = ProductQuantityUpdatedSuccessfully });
		}

	}
}
