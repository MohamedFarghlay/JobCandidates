using Application;
using Infrastructure;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMemoryCache();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();


var app = builder.Build();

// Apply migrations
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    try
    {
        var dbContext = services.GetRequiredService<ApplicationDbContext>();
        await dbContext.Database.MigrateAsync();
    }
    catch (Exception ex)
    {
        // Log or handle the exception as needed
        Console.WriteLine($"An error occurred while applying migrations: {ex.Message}");
        throw; // You can choose to rethrow the exception or handle it gracefully
    }
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
