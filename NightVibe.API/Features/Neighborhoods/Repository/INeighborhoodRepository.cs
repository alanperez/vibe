using NightVibe.API.Features.Neighborhoods.Models;

namespace NightVibe.API.Features.Neighborhoods.Repositories;

public interface INeighborhoodRepository
{
    Task<IEnumerable<Neighborhood>> GetAllNeighborhoodsAsync();
    Task<Neighborhood?> GetNeighborhoodBySlugAsync(string slug);
    Task<Neighborhood> CreateNeighborhoodAsync(Neighborhood neighborhood);

}