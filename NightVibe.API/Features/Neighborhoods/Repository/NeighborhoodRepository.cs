using Microsoft.EntityFrameworkCore;
using NightVibe.API.Data;
using NightVibe.API.Features.Neighborhoods.Models;


namespace NightVibe.API.Features.Neighborhoods.Repositories;

public class NeighborhoodRepository : INeighborhoodRepository
{
    private readonly AppDbContext _context;

    public NeighborhoodRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Neighborhood>> GetAllNeighborhoodsAsync()
    {
        return await _context.Neighborhoods.ToListAsync();
    }

    public async Task<Neighborhood?> GetNeighborhoodBySlugAsync(string slug)
    {
        return await _context.Neighborhoods
            .FirstOrDefaultAsync(n => n.Slug == slug);
    }

    public async Task<Neighborhood> CreateNeighborhoodAsync(Neighborhood neighborhood)
    {
        _context.Neighborhoods.Add(neighborhood);
        await _context.SaveChangesAsync();
        return neighborhood;
    }
}