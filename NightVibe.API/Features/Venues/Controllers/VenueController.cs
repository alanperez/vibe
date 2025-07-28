using Microsoft.AspNetCore.Mvc;
using NightVibe.API.Features.Venues.DTOs;
using NightVibe.API.Features.Venues.Services;

namespace NightVibe.API.Features.Venues.Controllers;

[ApiController]
[Route("api/venues")]
public class VenueController : ControllerBase
{
    private readonly IVenueService _service;

    public VenueController(IVenueService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<VenueDto>>> GetAll()
    {
        var venues = await _service.GetAllVenuesAsync();
        return Ok(venues);
    }

    [HttpPost]
    public async Task<ActionResult<VenueDto>> Create(CreateVenueDto dto)
    {
        var venue = await _service.CreateVenueAsync(dto);
        return CreatedAtAction(nameof(GetAll), new { id = venue.Id }, venue);
    }
}