/*
Създали сме приложението с Individual Identity, добавили сме Connection String в User Secrets.
Скафолдваме модела на Identity-то.
Създаваме папка Models в папка Data и правим клас ApplicationUser, който наследява IdentityUser.
После отиваме на Program.cs и на 
builder.Services.AddDefaultIdentity<IdentityUser>(options => {
	options.SignIn.RequireConfirmedAccount = true;
	options.Password.RequireDigit = true;
	options.Password.RequireUppercase = true;
	options.Password.RequireLowercase = true;
	options.Password.RequireNonAlphanumeric = true;
})

променяме IdentityUser на ApplicationUser, и така добавяме нови пропъртита към IdentityUser. В NurseryGardenDbContext добавяме, че налседява  IdentityDbContext<ApplicationUser>
public class NurseryGardenDbContext : IdentityDbContext<ApplicationUser>
Ъпдейтваме базата за да се добавят FirstName и LastName

Пример за добавяне на Navigation Property към User в друг клас, например Order

[Required]
[Comment("The user who plased the order")]
[MaxLength(450)]
public string UserId {get;set;} = null!;

[ForeignKey(nameof(UserId))]
public ApplicationUser User {get;set;} = null!

ВНИМАНИЕ! ЦЯЛАТА ПАПКА ДАТА ТРЯБВА ДА СЕ ИЗМЕСТИ В ОТДЕЛЕН СЛОЙ, НАПРАВЕН ЧРЕЗ НОВ ПРОЕКТ CLASS LIBRARY, В КОЙТО ЩЕ СТОЯТ ВСИЧКИТЕ МОДЕЛИ НА БАЗАТА

Добавяме .AddUserManager<ApplicationUser>() и .AddRoleManager<IdentityRole>()  към  builder.Services.AddDefaultIdentity<ApplicationUser> в Program.cs

Съответно UserManager се използва да достъпваме User DB непряко, за да не я прецакаме. UserManager se инжектира в конструктора (например HomeControler)
 
 Отиваме на Areas/Identity/Pages/Account/Register.cshtml и подменяме всички IdentityUser с ApplicationUser
 
 Отиваме на Models/Views/Shared/LoginPartial и заместваме IdentityUser с ApplicationUser
Отиваме на _ViewImports и добавяме @using NurseryGardenApp.Data.Models
ТОЗИ ПЪТ ЩЕ СЕ СМЕНИ, КОГАТО ПРЕМСТИМ DATA
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 */