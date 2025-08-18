using NightVibe.API.Features.Neighborhoods.DTOs;

namespace NightVibe.API.Features.Neighborhoods.Services;


public interface INeighborhoodService
{
    Task<IEnumerable<NeighborhoodDto>> GetAllNeighborhoodsAsync();
    Task<NeighborhoodDto?> GetNeighborhoodBySlugAsync(string slug);
    Task<NeighborhoodDto> CreateNeighborhoodAsync(CreateNeighborhoodDto dto);
}