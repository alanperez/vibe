using Microsoft.EntityFrameworkCore;
using NightVibe.API.Data;
using NightVibe.API.Features.Venues.Models;

namespace NightVibe.API.Features.Venues.Repositories;

public class VenueRepository : IVenueRepository
{
    private readonly AppDbContext _context;

    public VenueRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Venue>> GetAllAsync()
    {
        return await _context.Venues.ToListAsync();
    }

    public async Task<Venue> CreateAsync(Venue venue)
    {
        _context.Venues.Add(venue);
        await _context.SaveChangesAsync();
        return venue;
    }

    public async Task<IEnumerable<Venue>> GetVenuesByNeighborhoodSlugAsync(string slug)
    {
        return await _context.Venues
            .Include(v => v.Neighborhood) 
            .Where(v => v.Neighborhood != null && v.Neighborhood.Slug == slug)
            .ToListAsync();
    }
    public async Task<Venue?> GetByIdAsync(Guid id) {

        return await _context.Venues.Include(v => v.Neighborhood).FirstOrDefaultAsync(v => v.Id == id);
    }

}