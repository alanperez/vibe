using Microsoft.AspNetCore.Mvc;
using NightVibe.API.Features.Neighborhoods.DTOs;
using NightVibe.API.Features.Neighborhoods.Services;

namespace NightVibe.API.Features.Neighborhoods.Controllers;

[ApiController]
[Route("api/neighborhoods")]
public class NeighborhoodsController : ControllerBase
{
    private readonly INeighborhoodService _service;

    public NeighborhoodsController(INeighborhoodService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var items = await _service.GetAllNeighborhoodsAsync();
        return Ok(items);
    }

    [HttpGet("{slug}")]
    public async Task<IActionResult> GetBySlug(string slug)
    {
        var bySlug = await _service.GetNeighborhoodBySlugAsync(slug);
        if (bySlug == null) return NotFound(); // 404 status
        return Ok(bySlug);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateNeighborhoodDto dto)
    {
        if (ModelState.IsValid) return BadRequest(ModelState); // status 400

        var created = await _service.CreateNeighborhoodAsync(dto);
        return CreatedAtAction(nameof(GetBySlug), new { slug = created.Slug }, created); // 201
    }
}