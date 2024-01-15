using Microsoft.EntityFrameworkCore;
using CarApi.Data;
using CarApi.Models;
using CarApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<CarContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CarDatabase")));

builder.Services.AddScoped<ICarService, CarService>();

builder.Services.AddHttpClient();

// Add support for controllers (This is the missing part)
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Use routing and endpoints (This enables MVC controllers)
app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();  // This line maps controller routes
});

app.Run();
