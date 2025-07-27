using NightVibe.API.Features.Events.DTOs;

// using NightVibe.API.Features.Events.Services;

// Business logic contract for Events
public interface IEventService
{
    Task<IEnumerable<EventDto>> GetAllEventsAsync();
    Task<EventDto> GetEventByIdAsync(int id);
    Task AddEventAsync(CreateEventDto dto);
}