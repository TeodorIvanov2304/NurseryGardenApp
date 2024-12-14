using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static NurseryGardenApp.Common.Utility;
using static NurseryGardenApp.Common.ErrorMessages;
using NurseryGardenApp.Services.Data.Interfaces;
using NurseryGardenApp.ViewModels.Order;

namespace NurseryGardenApp.Controllers
{
	[Authorize]
	public class OrderController : BaseController
	{	
		private readonly IOrderService _orderService;
		private readonly IProductService _productService;

        public OrderController(IOrderService orderService, IProductService productService)
        {
            this._orderService = orderService;
			this._productService = productService;
        }

		[HttpPost]
		public async Task<IActionResult> CreateOrder(Guid productGuid)
		{
			var userId = this.GetCurrentUserId();

			if (string.IsNullOrEmpty(userId))
			{
				return RedirectToAction("Login", "Account");
			}

			Guid userGuid = Guid.Empty;

			if (!IsGuidValid(userId, ref userGuid))
			{
				return RedirectToAction("Custom404", "Error", new { message = InvalidUserIdErrorMessage });
			}

			bool isOrdered = await this._orderService.CreateOrderAsync(userGuid, productGuid);

			if (!isOrdered)
			{
				TempData["ErrorMessage"] = FailedToCreateOrderErrorMessage;
				return RedirectToAction("Index", "Product");
			}

			TempData["SuccessMessage"] = "Order created successfully.";
			return RedirectToAction(nameof(MyOrders));
		}

		[HttpGet]
		public async Task<IActionResult> MyOrders()
		{	
			var userId = this.GetCurrentUserId();

			if (string.IsNullOrEmpty(userId))
			{
				return RedirectToAction("Login", "Account");
			}


			Guid clientGuid = Guid.Empty;
			bool isValid = IsGuidValid(userId, ref clientGuid);

			if (!isValid)
			{
				return this.RedirectToAction("Custom404", "Error", new { message = InvalidUserIdErrorMessage });
			}

			IEnumerable<OrderViewModel> orders = await this._orderService.GetOrdersByClientIdAsync(clientGuid);

			
			

			return View(orders);
		}
	}
}
