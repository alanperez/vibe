using NightVibe.API.Features.Events.Models;

namespace NightVibe.API.Features.Events.Repositories;

// defines contract for interacting with the DB for Events
public interface IEventRepository
{
        Task<IEnumerable<Event>> GetAllEventsAsync();
        Task<Event> GetEventByIdAsync(int id);
        Task AddEventAsync(Event ev);
        Task SaveChangesAsync();
}