using Microsoft.EntityFrameworkCore;
using Shop.Server.Models;
using Shop.Server.Services;
using Shop.Server.ServicesContracts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Our services to the container
builder.Services.AddScoped<IProductService, ProductService>();


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
