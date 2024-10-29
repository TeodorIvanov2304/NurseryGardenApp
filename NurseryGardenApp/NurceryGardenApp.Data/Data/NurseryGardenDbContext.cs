using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NurseryGardenApp.Data.Data.Models;
using NurseryGardenApp.Data.Models;
using System.Reflection.Emit;

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


		protected override void OnModelCreating(ModelBuilder builder)
		{
			//Price precision

			builder.Entity<Product>()
		   .Property(p => p.Price)
		   .HasColumnType("decimal")
		   .HasPrecision(18, 2);

			builder.Entity<Order>()
		   .Property(o => o.Price)
		   .HasColumnType("decimal")
		   .HasPrecision(18, 2);

			builder.Entity<Discount>()
		   .Property(d => d.DiscountValue)
		   .HasColumnType("decimal")
		   .HasPrecision(18, 2);

			base.OnModelCreating(builder);
		}
	}
}
