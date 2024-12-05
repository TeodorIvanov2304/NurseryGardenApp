using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NurseryGardenApp.Data.Data.Models;
using NurseryGardenApp.Data.Models;
using System.Reflection;

namespace NurseryGardenApp.Data
{
	public class NurseryGardenDbContext : IdentityDbContext<ApplicationUser>
	{
		public NurseryGardenDbContext(DbContextOptions<NurseryGardenDbContext> options)
			: base(options)
		{
		}

		public virtual DbSet<Category> Categories { get; set; }
		public virtual DbSet<Class> Classes { get; set; }
		public virtual DbSet<Discount> Discounts { get; set; }
		public virtual DbSet<Order> Orders { get; set; }
		public virtual DbSet<OrderProduct> OrdersProducts { get; set; }
		public virtual DbSet<Product> Products { get; set; }
		public virtual DbSet<Manager> Managers { get; set; }



		protected override void OnModelCreating(ModelBuilder builder)
		{

			base.OnModelCreating(builder);

			builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
		}
	}
}
