/*
@if (User.IsInRole("Admin"))
{
    <li class="nav-item">
        <a class="nav-link" asp-controller="Product" asp-action="Create">Add Product</a>
    </li>
}

ВНИМАНИЕ! ЦЯЛАТА ПАПКА ДАТА ТРЯБВА ДА СЕ ИЗМЕСТИ В ОТДЕЛЕН СЛОЙ, НАПРАВЕН ЧРЕЗ НОВ ПРОЕКТ CLASS LIBRARY, В КОЙТО ЩЕ СТОЯТ ВСИЧКИТЕ МОДЕЛИ НА БАЗАТА

Добавяме .AddUserManager<ApplicationUser>() и .AddRoleManager<IdentityRole>()  към  builder.Services.AddDefaultIdentity<ApplicationUser> в Program.cs

Съответно UserManager се използва да достъпваме User DB непряко, за да не я прецакаме. UserManager se инжектира в конструктора (например HomeControler)
 
 Отиваме на Areas/Identity/Pages/Account/Register.cshtml и подменяме всички IdentityUser с ApplicationUser
 
 Отиваме на Models/Views/Shared/LoginPartial и заместваме IdentityUser с ApplicationUser
Отиваме на _ViewImports и добавяме @using NurseryGardenApp.Data.Models
ТОЗИ ПЪТ ЩЕ СЕ СМЕНИ, КОГАТО ПРЕМСТИМ DATA
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 */