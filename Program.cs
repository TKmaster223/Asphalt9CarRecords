using Asphalt9CarRecords.Models; // Using the Models namespace
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore; // Using Entity Framework Core for database operations
using Microsoft.Extensions.Logging; // Using logging functionality

var builder = WebApplication.CreateBuilder(args); // Creating a builder for the web application

builder.Services.AddControllers(); // Adding controller services to the container
builder.Services.AddEndpointsApiExplorer(); // Adding endpoints API explorer
builder.Services.AddSwaggerGen(); // Adding Swagger for API documentation
builder.Services.AddDbContext<CarContext>(options =>
{
    options.UseInMemoryDatabase("CarDatabase"); // Configuring an in-memory database
});
builder.Services.AddScoped<ICarService, CarService>(); // Registering CarService as a scoped service
builder.Services.AddAutoMapper(typeof(Program)); // Adding AutoMapper for object mapping

builder.Logging.ClearProviders(); // Clearing default logging providers
builder.Logging.AddConsole(); // Adding console logging provider

var app = builder.Build(); // Building the web application

if (app.Environment.IsDevelopment()) // If the environment is development
{
    app.UseSwagger(); // Use Swagger for API documentation
    app.UseSwaggerUI(); // Use Swagger UI
}

app.UseHttpsRedirection(); // Use HTTPS redirection
app.UseAuthorization(); // Use authorization middleware

app.MapControllers(); // Map controllers to endpoints

using (var scope = app.Services.CreateScope()) // Creating a scope for the service provider
{
    var context = scope.ServiceProvider.GetRequiredService<CarContext>(); // Getting the CarContext service
    await DataSeeder.SeedDataAsync(context); // Seeding initial data
}

app.Run(); // Running the web application
