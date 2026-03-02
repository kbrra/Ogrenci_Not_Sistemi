using Microsoft.EntityFrameworkCore;
using Ogrenci_Not_Kayit_Sistemi.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); 
    options.Cookie.HttpOnly = true;
});

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.UseSession(); 
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}"); 

app.Run();