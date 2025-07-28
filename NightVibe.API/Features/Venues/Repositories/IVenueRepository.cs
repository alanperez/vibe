
using NightVibe.API.Features.Venues.Models;

namespace NightVibe.API.Features.Venues.Repositories;

public interface IVenueRepository
{
    Task<IEnumerable<Venue>> GetAllAsync();
    Task<Venue> CreateAsync(Venue venue);
}