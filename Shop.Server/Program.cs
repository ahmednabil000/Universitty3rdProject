using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Shop.Server.Models;
using Shop.Server.Services;
using Shop.Server.ServicesContracts;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Add Our services to the container
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IShoppingCartService, ShoppingCartService>();
builder.Services.AddScoped<IAccountService, AccountService>();

// Add authentication service
builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
	options.Password.RequireNonAlphanumeric = false;
	options.Password.RequireDigit = true;
	options.Password.RequireLowercase = true;
	options.Password.RequireUppercase = true;
})
  .AddEntityFrameworkStores<DbAa7408UniversityprojectContext>();

builder.Services.AddAuthentication().AddJwtBearer(options =>
{
	var issuer = builder.Configuration["JWT:Issuer"];
	var key = builder.Configuration["JWT:Key"];
	options.TokenValidationParameters = new TokenValidationParameters
	{
		ValidateIssuer = true,
		ValidateAudience = false,
		ValidateLifetime = true,
		ValidateIssuerSigningKey = true,
		ValidIssuer = issuer,
		IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key))
	};
});
// Configure Ef core

builder.Services.AddDbContext<DbAa7408UniversityprojectContext>(options =>
{
	options.UseSqlServer("Data Source=SQL6031.site4now.net;Initial Catalog=db_aa7408_universityproject;User Id=db_aa7408_universityproject_admin;Password=ahmed3400");
});


var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
