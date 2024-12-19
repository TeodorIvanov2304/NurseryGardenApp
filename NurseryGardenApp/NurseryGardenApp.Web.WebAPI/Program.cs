
using Microsoft.EntityFrameworkCore;
using NurseryGardenApp.Data;
using NurseryGardenApp.Data.Data.Repositories.Interfaces;
using NurseryGardenApp.Data.Data.Repositories;
using NurseryGardenApp.Services.Data;
using NurseryGardenApp.Services.Data.Interfaces;

namespace NurseryGardenApp.Web.WebAPI
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);
			var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

			// Add services to the container.

			builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			builder
				.Services
				.AddDbContext<NurseryGardenDbContext>(options =>
				{
					options.UseSqlServer(connectionString);
				});

			//Register repository
			builder.Services.AddScoped(typeof(IRepository<,>), typeof(BaseRepository<,>));

			builder.Services.AddScoped<IOrderService, OrderService>();

			//Add CORS
			builder.Services.AddCors(options =>
			{
				options.AddPolicy("AllowAll", builder =>
				{
					builder
						.AllowAnyOrigin()
						.AllowAnyMethod()
						.AllowAnyHeader();
				});
			});

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			//CORS
			app.UseCors("AllowAll");

			app.UseHttpsRedirection();

			app.UseAuthorization();


			app.MapControllers();

			app.Run();
		}
	}
}
