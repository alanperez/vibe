using Microsoft.Extensions.Logging;
using NightVibe.API.Features.Events.DTOs;
using NightVibe.API.Features.Events.Models;
using NightVibe.API.Features.Events.Repositories;

namespace NightVibe.API.Features.Events.Services;

// Business logic implementation for Events
public class EventService : IEventService
{
    private readonly ILogger<EventService> _logger;
    private readonly IEventRepository _eventRepository;

    public EventService(IEventRepository eventRepository, ILogger<EventService> logger)
    {
        _eventRepository = eventRepository;
        _logger = logger;
    }

    public async Task<IEnumerable<EventDto>> GetAllEventsAsync()
    {
        _logger.LogInformation("Fetching all events");
        var events = await _eventRepository.GetAllEventsAsync();

        return events.Select(e => new EventDto
        {
            Id = e.Id,
            Title = e.Title,
            Genre = e.Genre,
            Location = e.Location,
            DateTime = e.DateTime,
            ImageUrl = e.ImageUrl
        });
    }

    public async Task<EventDto> GetEventByIdAsync(int id)
    {
        var ev = await _eventRepository.GetEventByIdAsync(id);
        if (ev == null) return null;

        return new EventDto
        {
            Id = ev.Id,
            Title = ev.Title,
            Genre = ev.Genre,
            Location = ev.Location,
            DateTime = ev.DateTime,
            ImageUrl = ev.ImageUrl
        };
    }

    public async Task AddEventAsync(CreateEventDto dto)
    {
        _logger.LogInformation("Creating a new event titled: {Title}", dto.Title);
        var newEvent = new Event
        {
            Title = dto.Title,
            Genre = dto.Genre,
            Location = dto.Location,
            DateTime = dto.DateTime,
            ImageUrl = dto.ImageUrl
        };

        await _eventRepository.AddEventAsync(newEvent);
        await _eventRepository.SaveChangesAsync();

        _logger.LogInformation("Event created successfully");
    }
}