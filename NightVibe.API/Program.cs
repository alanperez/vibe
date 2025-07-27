// Bootstraps the web app, pulls in the config files, logging, etc.
using Microsoft.EntityFrameworkCore;
using NightVibe.API.Data;
using NightVibe.API.Features.Events.Repositories;
using NightVibe.API.Features.Events.Services;

var builder = WebApplication.CreateBuilder(args);

// Register services
builder.Services.AddControllers();
builder.Services.AddScoped<IEventService, EventService>();
builder.Services.AddScoped<IEventRepository, EventRepository>();

// Registers the AppDbContext so EF Core can communicate with SQL Server using the connection string from AppSettings.
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Enables API endpoint discovery for Swagger
builder.Services.AddEndpointsApiExplorer();

// Registers Swagger UI to test API visually
builder.Services.AddSwaggerGen();

// Builds the web app with all registered services and middleware
var app = builder.Build();

// Enable Swagger only during development
if (app.Environment.IsDevelopment())
{
    // Generates Swagger JSON
    app.UseSwagger();

    // Enables Swagger UI
    app.UseSwaggerUI();
}

// Redirect HTTP to HTTPS
app.UseHttpsRedirection();

// Enables roles/permission checking
app.UseAuthorization();

// map route requests to controler endpoints
app.MapControllers();

// starts the app and listens for the HTTP requests
app.Run();