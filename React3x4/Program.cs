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
using React3x4.Services.Abstractions;
using React3x4.Services.Implements;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppEFContext>((DbContextOptionsBuilder options) =>
//options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllersWithViews().AddFluentValidation();
builder.Services.AddTransient<IValidator<RegisterViewModel>, AccountValidator>();

//how use interfaces
builder.Services.AddScoped<IJWTConfig, JWTConfig>();

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

//Configuration from AppSettings
var appSettingSection = configuration.GetSection("AppSetting");
builder.Services.Configure<AppSettings>(appSettingSection);

// Adding Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
// Adding Jwt Bearer

.AddJwtBearer(options =>
{
    options.SaveToken = false;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuerSigningKey = true,
        ValidateIssuer = false,
        ValidateAudience = false,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["AppSetting:Key"]))
    };
});


builder.Services.AddControllers().AddNewtonsoftJson(options =>
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
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "3x4 example");
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

builder.Services.AddControllers().AddNewtonsoftJson(options =>
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
        Title = "Video player example"
    });
});
builder.Services.AddCors();


//if (app.Environment.IsDevelopment())
//{

app.UseSwagger();
app.UseSwaggerUI((SwaggerUIOptions c) =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Player");
});
//}


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
}


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
