using Microsoft.AspNetCore.Identity.UI.Services;

namespace NurseryGardenApp.Services.Data
{
	public class NullEmailSender : IEmailSender
	{
		public  Task SendEmailAsync(string email, string subject, string htmlMessage)
		{
			return Task.CompletedTask;
		}
	}
}
