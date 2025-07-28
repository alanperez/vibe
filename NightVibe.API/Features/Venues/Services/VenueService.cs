using Microsoft.EntityFrameworkCore;
using NightVibe.API.Data;
using NightVibe.API.Features.Venues.DTOs;
using NightVibe.API.Features.Venues.Models;
using NightVibe.API.Features.Venues.Repositories;

namespace NightVibe.API.Features.Venues.Services;

public class VenueService : IVenueService
{
    private readonly IVenueRepository _repository;

    public VenueService(IVenueRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<VenueDto>> GetAllVenuesAsync()
    {
        var venues = await _repository.GetAllAsync();

        return venues.Select(v => new VenueDto
        {
            Id = v.Id,
            Name = v.Name,
            Address = v.Address,
            Latitude = v.Latitude,
            Longitude = v.Longitude,
            Description = v.Description,
            ImageUrl = v.ImageUrl
        });
    }

    public async Task<VenueDto> CreateVenueAsync(CreateVenueDto dto)
    {
        var venue = new Venue
        {
            Id = Guid.NewGuid(),
            Name = dto.Name,
            Address = dto.Address,
            Latitude = dto.Latitude,
            Longitude = dto.Longitude,
            Description = dto.Description,
            ImageUrl = dto.ImageUrl
        };

        var result = await _repository.CreateAsync(venue);

        return new VenueDto
        {
            Id = result.Id,
            Name = result.Name,
            Address = result.Address,
            Latitude = result.Latitude,
            Longitude = result.Longitude,
            Description = result.Description,
            ImageUrl = result.ImageUrl
        };
    }
}