using System.ComponentModel.DataAnnotations;

namespace NightVibe.API.Features.Neighborhoods.DTOs;


public class CreateNeighborhoodDto
{
    [Required]
    public string Name { get; set; }
}
