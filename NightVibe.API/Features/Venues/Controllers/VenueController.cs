using Microsoft.AspNetCore.Mvc;
using NightVibe.API.Features.Venues.DTOs;
using NightVibe.API.Features.Venues.Services;

namespace NightVibe.API.Features.Venues.Controllers;

[ApiController]
[Route("api/venues")]
public class VenueController : ControllerBase
{
    private readonly IVenueService _service;
    public VenueController(IVenueService service) => _service = service;

    // GET /api/venues?neighborhood=deep-ellum
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] string? neighborhood)
    {
        if (!string.IsNullOrWhiteSpace(neighborhood))
        {
            var filtered = await _service.GetVenuesByNeighborhoodSlugAsync(neighborhood);
            return Ok(filtered);
        }
        var all = await _service.GetAllVenuesAsync();
        return Ok(all);
    }

    // GET /api/venues/{id}
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var venue = await _service.GetVenueByIdAsync(id);
        if (venue is null) return NotFound();
        return Ok(venue);
    }

    // POST /api/venues
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateVenueDto dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var venue = await _service.CreateVenueAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = venue.Id }, venue);
    }
}
