
using Microsoft.AspNetCore.Mvc;
using NightVibe.API.Features.Events.DTOs;
using NightVibe.API.Features.Events.Services;


namespace NightVibe.API.Features.Events.Controllers;

// controller listens to API calls like: GET /api/events
[Route("api/[controller]")]
[ApiController]
public class EventsController : ControllerBase
{
    private readonly IEventService _eventService;

    public EventsController(IEventService eventService)
    {
        _eventService = eventService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var events = await _eventService.GetAllEventsAsync();
        return Ok(events);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateEventDto dto)
    {
        await _eventService.AddEventAsync(dto);
        return Ok(new { message = "Event created" });
    } 
}