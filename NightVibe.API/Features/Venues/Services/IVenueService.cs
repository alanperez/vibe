using NightVibe.API.Features.Venues.DTOs;

namespace NightVibe.API.Features.Venues.Services;

public interface IVenueService
{
    Task<IEnumerable<VenueDto>> GetAllVenuesAsync();
    Task<VenueDto> CreateVenueAsync(CreateVenueDto dto);
    Task<IEnumerable<VenueDto>> GetVenuesByNeighborhoodSlugAsync(string slug);
    Task<VenueDto?> GetVenueByIdAsync(Guid id);
}