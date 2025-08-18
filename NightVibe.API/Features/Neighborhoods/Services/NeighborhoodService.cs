using Microsoft.EntityFrameworkCore;
using NightVibe.API.Data;
using NightVibe.API.Features.Neighborhoods.DTOs;
using NightVibe.API.Features.Neighborhoods.Models;
using NightVibe.API.Features.Neighborhoods.Repositories;

namespace NightVibe.API.Features.Neighborhoods.Services;

public class NeighborhoodService : INeighborhoodService
{
    private readonly INeighborhoodRepository _repository;

    public NeighborhoodService(INeighborhoodRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<NeighborhoodDto>> GetAllNeighborhoodsAsync()
    {
        var neighborhoods = await _repository.GetAllNeighborhoodsAsync();
        return neighborhoods.Select(n => new NeighborhoodDto
        {
            Id = n.Id,
            Name = n.Name,
            Slug = n.Slug
        });
    }

    public async Task<NeighborhoodDto?> GetNeighborhoodBySlugAsync(string slug)
    {
        var n = await _repository.GetNeighborhoodBySlugAsync(slug);
        if (n == null) return null;

        return new NeighborhoodDto
        {
            Id = n.Id,
            Name = n.Name,
            Slug = n.Slug
        };
    }

    public async Task<NeighborhoodDto> CreateNeighborhoodAsync(CreateNeighborhoodDto dto)
    {
        var neighborhood = new Neighborhood
        {
            Id = Guid.NewGuid(),
            Name = dto.Name,
            Slug = dto.Name.ToLower().Replace(" ", "-")
        };

        var created = await _repository.CreateNeighborhoodAsync(neighborhood);
        return new NeighborhoodDto
        {
            Id = created.Id,
            Name = created.Name,
            Slug = created.Slug
        };
    }
}