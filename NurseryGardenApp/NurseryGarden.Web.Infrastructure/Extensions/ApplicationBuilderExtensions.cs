using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NurseryGardenApp.Data;

namespace NurseryGardenApp.Web.Infrastructure.Extensions
{
	public static class ApplicationBuilderExtensions
	{
		public static async Task<IApplicationBuilder> ApplyMigrations(this IApplicationBuilder app)
		{
			using IServiceScope serviceScope = app.ApplicationServices.CreateAsyncScope();

			NurseryGardenDbContext dbContext = serviceScope.ServiceProvider.GetRequiredService<NurseryGardenDbContext>()!;

			await dbContext.Database.MigrateAsync();

			return app;
		}
	}
}
