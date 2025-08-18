// Bootstraps the web app, pulls in the config files, logging, etc.
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using NightVibe.API.Data;
using NightVibe.API.Features.Events.Repositories;
using NightVibe.API.Features.Events.Services;
using NightVibe.API.Features.Venues.Repositories;
using NightVibe.API.Features.Venues.Services;
using NightVibe.API.Features.Neighborhoods.Repositories;
using NightVibe.API.Features.Neighborhoods.Services;
var builder = WebApplication.CreateBuilder(args);

// Register services
builder.Services.AddControllers();
builder.Services.AddScoped<IEventService, EventService>();
builder.Services.AddScoped<IEventRepository, EventRepository>();
builder.Services.AddScoped<IVenueRepository, VenueRepository>();
builder.Services.AddScoped<IVenueService, VenueService>();
builder.Services.AddScoped<INeighborhoodService, NeighborhoodService>();
builder.Services.AddScoped<INeighborhoodRepository, NeighborhoodRepository>();
// Registers the AppDbContext so EF Core can communicate with SQL Server using the connection string from AppSettings.
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Enables API endpoint discovery for Swagger
builder.Services.AddEndpointsApiExplorer();

// Registers Swagger UI to test API visually
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "NightVibe API", Version = "v1" });
});

// Builds the web app with all registered services and middleware
var app = builder.Build();

// Apply migrations and seed the database
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate(); // applies any pending migrations
    DbSeeder.Seed(db); // seed if empty
}

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


if (args.Contains("--seed"))
{
    using var scope = app.Services.CreateScope();
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
    DbSeeder.Seed(db);

    Console.WriteLine("Database seeded successfully.");

    return;
}

// starts the app and listens for the HTTP requests
app.Run();