using DataLib;
using DataLib.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using React3x4.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppEFContext>((DbContextOptionsBuilder options) =>
//options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllersWithViews().AddFluentValidation();
builder.Services.AddTransient<IValidator<RegisterViewModel>, AccountValidator>();

builder.Services.AddIdentity<AppUser, AppRole>(options =>
 {
     options.Password.RequireDigit = false;
     options.Password.RequiredLength = 4;
     options.Password.RequireNonAlphanumeric = false;
     options.Password.RequireUppercase = false;
     options.Password.RequireLowercase = false;
 })
    .AddEntityFrameworkStores<AppEFContext>()
    .AddDefaultTokenProviders();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
}

app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
