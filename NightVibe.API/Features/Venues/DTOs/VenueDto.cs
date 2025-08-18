using NightVibe.API.Features.Neighborhoods.DTOs;

namespace NightVibe.API.Features.Venues.DTOs;

public class VenueDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public string Address { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }

    public string? ImageUrl { get; set; }

    public NeighborhoodDto? Neighborhood { get; set; }
}