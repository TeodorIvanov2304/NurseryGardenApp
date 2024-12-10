using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using NurseryGardenApp.Data.Data.SeedingData.DTOs;
using NurseryGardenApp.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.Text;
using static NurseryGardenApp.Common.Utility;

namespace NurseryGardenApp.Data.Data.SeedingData
{
	public static class DbSeeder
	{
		public static async Task SeedProductsJsonAsync(IServiceProvider services, string jsonPath)
		{

			await using NurseryGardenDbContext dbContext =  services.GetRequiredService<NurseryGardenDbContext>();

			IEnumerable<Product> allProducts = await dbContext.Products.ToArrayAsync();

			try
			{
				string jsonInput = await File
				  .ReadAllTextAsync(jsonPath, Encoding.ASCII, CancellationToken.None);
				ImportProductDto[]? productsToImport = JsonConvert.DeserializeObject<ImportProductDto[]>(jsonInput);

				foreach (ImportProductDto dto in productsToImport!)
				{
					if (!IsValid(dto))
					{
						continue;
					}

					Guid productGuid = Guid.Empty;

					if (!IsGuidValid(dto.Id.ToString(), ref productGuid))
					{
						continue;
					}

					if (allProducts.Any(p => p.Id == productGuid))
					{
						continue;
					}

					Product product = new Product
					{
						Id = productGuid,
						Name = dto.Name,
						Description = dto.Description,
						Price = dto.Price,
						ImageUrl = dto.ImageUrl,
						Quantity = dto.Quantity,
						IsDeleted = false,
						CategoryId = dto.CategoryId,
						DiscountId = dto.DiscountId,
					};

					await dbContext.Products.AddAsync(product);
				}

				await dbContext.SaveChangesAsync();
			}
			catch
			{
                Console.WriteLine("Error while trying to save the product in the DB");
			}
		}

		private static bool IsValid(object obj)
		{	
			List<ValidationResult> validationResults = new List<ValidationResult>();
			var context = new ValidationContext(obj);
			var isValid = Validator.TryValidateObject(obj, context,validationResults);

			return isValid;
		}
	}
}
