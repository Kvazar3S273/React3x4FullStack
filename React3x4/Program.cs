using DataLib;
using DataLib.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using React3x4.Models;
using System.Globalization;
using Microsoft.AspNetCore.Localization;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppEFContext>((DbContextOptionsBuilder options) =>
//options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllersWithViews().AddFluentValidation();
builder.Services.AddTransient<IValidator<RegisterViewModel>, AccountValidator>();

builder.Services.AddControllers().AddNewtonsoftJson(options=>
{
    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
    options.SerializerSettings.DefaultValueHandling = DefaultValueHandling.Include;
    options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
});
builder.Services.AddSwaggerGen((SwaggerGenOptions o) =>
{
    o.SwaggerDoc("v1", new OpenApiInfo
    {
        Description = "Swagger",
        Version = "v1",
        Title = "3x4 example"
    });
});

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI((SwaggerUIOptions c) =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Player");
});

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller}/{action=Index}/{id?}");
});


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

builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");
builder.Services.AddControllersWithViews().AddViewLocalization();

//var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
}

var supportedCultures = new[]
            {
                new CultureInfo("en"),
                new CultureInfo("uk")
            };

app.UseRequestLocalization(new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture("uk"),
    SupportedCultures = supportedCultures,
    SupportedUICultures = supportedCultures
});


app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "defaultlocal",
    pattern: "{lang=uk}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
