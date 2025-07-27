using Microsoft.EntityFrameworkCore;
using NightVibe.API.Data;
using NightVibe.API.Features.Events.Models;

namespace NightVibe.API.Features.Events.Repositories;

// This class implements the DB logic using Entity Framework Core
public class EventRepository : IEventRepository
{
    private readonly AppDbContext _context;

    public EventRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Event>> GetAllEventsAsync()
    {
        return await _context.Events.ToListAsync();
    }

    public async Task<Event> GetEventByIdAsync(int id)
    {
        return await _context.Events.FindAsync(id);
    }
    public async Task AddEventAsync(Event ev)
    {
        await _context.Events.AddAsync(ev);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}