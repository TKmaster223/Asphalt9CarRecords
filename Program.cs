using Asphalt9CarRecords.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Add support for endpoint exploration and API documentation
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure Entity Framework Core to use an in-memory database
builder.Services.AddDbContext<CarContext>(options =>
{
    options.UseInMemoryDatabase("CarDatabase");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

// Log seed data
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<CarContext>();
    context.Database.EnsureDeleted();
    context.Database.EnsureCreated();
    Console.WriteLine("Database has been initialized and seeded.");
}

app.Run();
