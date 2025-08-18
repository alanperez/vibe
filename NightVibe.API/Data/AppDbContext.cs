using Microsoft.EntityFrameworkCore;
using NightVibe.API.Features.Events.Models;
using NightVibe.API.Features.Neighborhoods.Models;
using NightVibe.API.Features.Venues.Models;

namespace NightVibe.API.Data;

// AppDbContext inherits from EF cores DbContext
// acts as a bridge between the C# models and the SQL database tables
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<Event> Events { get; set; }
    public DbSet<Venue> Venues { get; set; }
    public DbSet<Neighborhood> Neighborhoods { get; set; }
}