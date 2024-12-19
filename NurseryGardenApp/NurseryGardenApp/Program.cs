using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using NurseryGardenApp.Data;
using NurseryGardenApp.Data.Data.Configuration;
using NurseryGardenApp.Data.Data.Repositories;
using NurseryGardenApp.Data.Data.Repositories.Interfaces;
using NurseryGardenApp.Data.Data.SeedingData;
using NurseryGardenApp.Data.Models;
using NurseryGardenApp.Services.Data;
using NurseryGardenApp.Services.Data.Interfaces;
using static NurseryGardenApp.Web.Infrastructure.Extensions.ApplicationBuilderExtensions;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
string jsonPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, builder.Configuration.GetValue<string>("Seed:ProductsJson")!);


//Add DbContext
builder.Services.AddDbContext<NurseryGardenDbContext>(options =>
	options.UseSqlServer(connectionString));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

//Add Identity
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
	options.SignIn.RequireConfirmedAccount = false;
	options.Password.RequireDigit = true;
	options.Password.RequireUppercase = true;
	options.Password.RequireLowercase = true;
	options.Password.RequireNonAlphanumeric = true;
})
.AddRoles<IdentityRole>()  // Add role management
.AddEntityFrameworkStores<NurseryGardenDbContext>() // Link DbContext to Identity
.AddSignInManager<SignInManager<ApplicationUser>>()
.AddUserManager<UserManager<ApplicationUser>>()
.AddDefaultTokenProviders();


builder.Services.ConfigureApplicationCookie(options =>
{
	options.LoginPath = "/Identity/Account/Login";
});


//Register repository
builder.Services.AddScoped(typeof(IRepository<,>), typeof(BaseRepository<,>));

//Register services
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IDiscountService, DiscountService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IManagerService, ManagerService>();
builder.Services.AddScoped<IClassService, ClassService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IOrderService, OrderService>();

builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient("WebAPI", client =>
{
	var baseUrl = builder.Configuration["WebAPI:BaseUrl"];
	client.BaseAddress = new Uri(baseUrl!);
});

builder.Services.AddTransient<IEmailSender, NullEmailSender>();

builder.Services.AddRazorPages();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
	var services = scope.ServiceProvider;
	DatabaseSeeder.SeedRoles(services);
	DatabaseSeeder.AssignAdminRole(services);

	var logger = services.GetRequiredService<ILogger<Program>>();
	await DbSeeder.SeedProductsJsonAsync(services, jsonPath);

}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseMigrationsEndPoint();
}
else
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

//Configure middleware for status codes 400
//app.UseStatusCodePagesWithReExecute("/Error/Custom404");

//Configure middleware for server errors
//app.UseExceptionHandler("/Error/Custom500");

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.Use((context, next) =>
{
	if (context.User.Identity?.IsAuthenticated == true && context.Request.Path == "/")
	{
		if (context.User.IsInRole("Admin"))
		{
			context.Response.Redirect("/Admin/Home/Index");
			return Task.CompletedTask;
		}
	}
	return next();
});

app.UseAuthorization();

app.MapControllerRoute(
	name: "areas",
	pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

await app.ApplyMigrations();

app.Run();
