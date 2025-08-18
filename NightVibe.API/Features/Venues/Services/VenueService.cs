using Microsoft.EntityFrameworkCore;
using NightVibe.API.Data;
using NightVibe.API.Features.Venues.DTOs;
using NightVibe.API.Features.Venues.Models;
using NightVibe.API.Features.Venues.Repositories;
using NightVibe.API.Features.Neighborhoods.DTOs; 
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

    public async Task<IEnumerable<VenueDto>> GetVenuesByNeighborhoodSlugAsync(string slug)
    {
        var venues = await _repository.GetVenuesByNeighborhoodSlugAsync(slug);
        return venues.Select(v => new VenueDto
        {
            Id = v.Id,
            Name = v.Name,
            Address = v.Address,
            Latitude = v.Latitude,
            Longitude = v.Longitude,
            Description = v.Description,
            ImageUrl = v.ImageUrl,
            Neighborhood = v.Neighborhood != null
                ? new NeighborhoodDto
                {
                    Id = v.Neighborhood.Id,
                    Name = v.Neighborhood.Name,
                    Slug = v.Neighborhood.Slug
                }
                : null
        });
    }

    public async Task<VenueDto?> GetVenueByIdAsync(Guid id)
    {
        var venue = await _repository.GetByIdAsync(id);
        return venue is null ? null : new VenueDto
        {
            Id = venue.Id,
            Name = venue.Name,
            Address = venue.Address,
            Latitude = venue.Latitude,
            Longitude = venue.Longitude,
            Description = venue.Description,
            ImageUrl = venue.ImageUrl,
            Neighborhood = venue.Neighborhood is not null ? new NeighborhoodDto
            {
                Id = venue.Neighborhood.Id,
                Name = venue.Neighborhood.Name,
                Slug = venue.Neighborhood.Slug
            } : null
        };
    }
}