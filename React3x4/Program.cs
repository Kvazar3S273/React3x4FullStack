using DataLib;
using DataLib.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using React3x4.Models;
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
using React3x4.Seeder;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.HttpOverrides;
using React3x4.Validation;
using React3x4.Mapper;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddDbContext<AppEFContext>(options =>
         options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

//how use interfaces
builder.Services.AddScoped<IJWTConfig, JWTConfig>();

// For Identity
builder.Services.AddIdentity<AppUser, AppRole>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 4;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
    options.User.AllowedUserNameCharacters = "àáâãäåºæçè³¿éêëìíîïğñòóôõö÷øùüşÿÀÁÂÃÄÅªÆÇÈ²¯ÉÊËÌÍÎÏĞÑÒÓÔÕÖ×ØÙÜŞß";
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
    //options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuerSigningKey = true,
        ValidateIssuer = false,
        ValidateAudience = false,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["AppSetting:Key"]))
    };
});

// Add services to the container.
builder.Services.AddControllersWithViews().AddFluentValidation();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddTransient<IValidator<RegisterViewModel>, AccountValidator>();
builder.Services.AddAutoMapper(typeof(PhotoProfile));
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
//builder.Services.AddCors();

var app = builder.Build();

app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
});

app.UseSwagger();

app.UseSwaggerUI((SwaggerUIOptions c) =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "3x4 example");
});

app.UseStaticFiles();

//app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

//Add data into database
await app.SeedData();

app.FndSeedData();
app.PhotoPrintSeedData();
app.PhotoScanSeedData();
app.PhotoDuplicateSeedData();
app.PhotoPictureSeedData();
app.PhotoBottleSeedData();

app.XeroxSeedData();
app.BlackPrintSeedData();
app.ColorPrintSeedData();
app.ScanningSeedData();
app.LaminateSeedData();
app.BinderSeedData();
app.UsbFlashSeedData();
app.DiscprintSeedData();
app.EmailSeedData();

app.VisitcardSeedData();

app.TestSeedData();

app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller}/{action=Index}/{id?}");
});

app.MapControllerRoute(
    name: "defaultlocal",
    pattern: "{lang=uk}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();